using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;
using System.Data;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class BaseDatosVenta
    {
        private readonly ConexionBD _conexionBD;

        // Prepara la clase usando la conexión predeterminada.
        public BaseDatosVenta()
            : this(new ConexionBD())
        {
        }

        // Permite proporcionar una instancia de conexión.
        public BaseDatosVenta(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        // Registra la venta, sus detalles y el descuento de existencias en una transacción.
        public int Registrar(Venta venta)
        {
            ArgumentNullException.ThrowIfNull(venta);
            if (venta.Detalles.Count == 0)
            {
                throw new ArgumentException("La venta debe tener al menos un detalle.", nameof(venta));
            }

            foreach (DetalleVenta detalle in venta.Detalles)
            {
                if (detalle.Cantidad <= 0 || detalle.PrecioUnitario < 0)
                {
                    throw new ArgumentException("Cada detalle debe tener cantidad positiva y precio no negativo.", nameof(venta));
                }
            }

            const string consultaVenta = @"
                INSERT INTO dbo.Ventas (IdCliente, FechaVenta, Total, Estado)
                OUTPUT INSERTED.IdVenta
                VALUES (@IdCliente, @FechaVenta, @Total, @Estado);";
            const string consultaDetalle = @"
                INSERT INTO dbo.DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal)
                VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal);";
            const string actualizarExistencias = @"
                UPDATE dbo.Productos
                SET Existencias = Existencias - @Cantidad
                WHERE IdProducto = @IdProducto
                  AND Estado = 1
                  AND Existencias >= @Cantidad;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            conexion.Open();
            using SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                int idVenta;
                using (SqlCommand comando = new SqlCommand(consultaVenta, conexion, transaccion))
                {
                    comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = (object?)venta.IdCliente ?? DBNull.Value;
                    comando.Parameters.Add("@FechaVenta", SqlDbType.DateTime2).Value = venta.FechaVenta;
                    SqlParameter total = comando.Parameters.Add("@Total", SqlDbType.Decimal);
                    total.Precision = 12;
                    total.Scale = 2;
                    total.Value = venta.Total;
                    comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = venta.Estado;
                    idVenta = Convert.ToInt32(comando.ExecuteScalar());
                }

                foreach (DetalleVenta detalle in venta.Detalles)
                {
                    using (SqlCommand comando = new SqlCommand(actualizarExistencias, conexion, transaccion))
                    {
                        comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                        comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;
                        if (comando.ExecuteNonQuery() == 0)
                        {
                            throw new InvalidOperationException(
                                $"El producto con ID {detalle.IdProducto} no existe, está inactivo o no tiene existencias suficientes.");
                        }
                    }

                    using (SqlCommand comando = new SqlCommand(consultaDetalle, conexion, transaccion))
                    {
                        comando.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                        comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;
                        comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                        SqlParameter precio = comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
                        precio.Precision = 10;
                        precio.Scale = 2;
                        precio.Value = detalle.PrecioUnitario;
                        SqlParameter subtotal = comando.Parameters.Add("@Subtotal", SqlDbType.Decimal);
                        subtotal.Precision = 12;
                        subtotal.Scale = 2;
                        subtotal.Value = detalle.Subtotal;
                        comando.ExecuteNonQuery();
                    }
                }

                transaccion.Commit();
                venta.IdVenta = idVenta;
                return idVenta;
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }

        // Devuelve las ventas con cliente y detalles para consultar el total.
        public List<Venta> Listar()
        {
            return Consultar(null);
        }

        // Busca una venta por su ID, incluyendo sus detalles.
        public Venta? ObtenerPorId(int idVenta)
        {
            return Consultar(idVenta).FirstOrDefault();
        }

        // Consulta ventas y detalles, opcionalmente limitando el resultado a un ID.
        private List<Venta> Consultar(int? idVenta)
        {
            const string consulta = @"
                SELECT v.IdVenta, v.IdCliente, c.Nombre AS NombreCliente,
                       v.FechaVenta, v.Estado,
                       dv.IdDetalleVenta, dv.IdProducto, p.Nombre AS NombreProducto,
                       dv.Cantidad, dv.PrecioUnitario
                FROM dbo.Ventas AS v
                LEFT JOIN dbo.Clientes AS c ON c.IdCliente = v.IdCliente
                LEFT JOIN dbo.DetalleVenta AS dv ON dv.IdVenta = v.IdVenta
                LEFT JOIN dbo.Productos AS p ON p.IdProducto = dv.IdProducto
                WHERE @IdVenta IS NULL OR v.IdVenta = @IdVenta
                ORDER BY v.FechaVenta DESC, v.IdVenta, dv.IdDetalleVenta;";

            List<Venta> ventas = new List<Venta>();
            Dictionary<int, Venta> ventasPorId = new Dictionary<int, Venta>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdVenta", SqlDbType.Int).Value = (object?)idVenta ?? DBNull.Value;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                int id = lector.GetInt32(lector.GetOrdinal("IdVenta"));
                if (!ventasPorId.TryGetValue(id, out Venta? venta))
                {
                    int ordinalCliente = lector.GetOrdinal("IdCliente");
                    int? idCliente = lector.IsDBNull(ordinalCliente)
                        ? null
                        : lector.GetInt32(ordinalCliente);
                    int ordinalNombreCliente = lector.GetOrdinal("NombreCliente");

                    venta = new Venta(idCliente, lector.GetDateTime(lector.GetOrdinal("FechaVenta")))
                    {
                        IdVenta = id,
                        NombreCliente = lector.IsDBNull(ordinalNombreCliente)
                            ? null
                            : lector.GetString(ordinalNombreCliente),
                        Estado = lector.GetString(lector.GetOrdinal("Estado"))
                    };
                    ventasPorId.Add(id, venta);
                    ventas.Add(venta);
                }

                int ordinalDetalle = lector.GetOrdinal("IdDetalleVenta");
                if (!lector.IsDBNull(ordinalDetalle))
                {
                    venta.Detalles.Add(new DetalleVenta(
                        lector.GetInt32(lector.GetOrdinal("IdProducto")),
                        lector.IsDBNull(lector.GetOrdinal("NombreProducto"))
                            ? null
                            : lector.GetString(lector.GetOrdinal("NombreProducto")),
                        lector.GetInt32(lector.GetOrdinal("Cantidad")),
                        lector.GetDecimal(lector.GetOrdinal("PrecioUnitario")))
                    {
                        IdDetalleVenta = lector.GetInt32(ordinalDetalle),
                        IdVenta = id
                    });
                }
            }

            return ventas;
        }
    }
}
