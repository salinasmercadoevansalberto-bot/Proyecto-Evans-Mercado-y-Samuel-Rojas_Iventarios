using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;
using System.Data;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class BaseDatosCompra
    {
        private readonly ConexionBD _conexionBD;

        // Prepara la clase usando la conexión predeterminada.
        public BaseDatosCompra()
            : this(new ConexionBD())
        {
        }

        // Permite proporcionar una instancia de conexión.
        public BaseDatosCompra(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        // Registra la compra, sus detalles y el aumento de existencias en una transacción.
        public int Registrar(Compra compra)
        {
            ArgumentNullException.ThrowIfNull(compra);
            if (compra.Detalles.Count == 0)
            {
                throw new ArgumentException("La compra debe tener al menos un detalle.", nameof(compra));
            }

            const string consultaCompra = @"
                INSERT INTO dbo.Compras (IdProveedor, FechaCompra, Total, Estado)
                OUTPUT INSERTED.IdCompra
                VALUES (@IdProveedor, @FechaCompra, @Total, @Estado);";
            const string consultaDetalle = @"
                INSERT INTO dbo.DetalleCompra (IdCompra, IdProducto, Cantidad, PrecioCosto, Subtotal)
                VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioCosto, @Subtotal);";
            const string actualizarExistencias = @"
                UPDATE dbo.Productos
                SET Existencias = Existencias + @Cantidad
                WHERE IdProducto = @IdProducto;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            conexion.Open();
            using SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                int idCompra;
                using (SqlCommand comando = new SqlCommand(consultaCompra, conexion, transaccion))
                {
                    comando.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = compra.IdProveedor;
                    comando.Parameters.Add("@FechaCompra", SqlDbType.DateTime2).Value = compra.FechaCompra;
                    SqlParameter total = comando.Parameters.Add("@Total", SqlDbType.Decimal);
                    total.Precision = 12;
                    total.Scale = 2;
                    total.Value = compra.Total;
                    comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = compra.Estado;
                    idCompra = Convert.ToInt32(comando.ExecuteScalar());
                }

                foreach (DetalleCompra detalle in compra.Detalles)
                {
                    if (detalle.Cantidad <= 0 || detalle.PrecioCosto < 0)
                    {
                        throw new ArgumentException("Cada detalle debe tener cantidad positiva y precio no negativo.", nameof(compra));
                    }

                    using (SqlCommand comando = new SqlCommand(consultaDetalle, conexion, transaccion))
                    {
                        comando.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                        comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;
                        comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                        SqlParameter precio = comando.Parameters.Add("@PrecioCosto", SqlDbType.Decimal);
                        precio.Precision = 10;
                        precio.Scale = 2;
                        precio.Value = detalle.PrecioCosto;
                        SqlParameter subtotal = comando.Parameters.Add("@Subtotal", SqlDbType.Decimal);
                        subtotal.Precision = 12;
                        subtotal.Scale = 2;
                        subtotal.Value = detalle.Subtotal;
                        comando.ExecuteNonQuery();
                    }

                    using (SqlCommand comando = new SqlCommand(actualizarExistencias, conexion, transaccion))
                    {
                        comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                        comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;
                        if (comando.ExecuteNonQuery() == 0)
                        {
                            throw new InvalidOperationException($"No existe el producto con ID {detalle.IdProducto}.");
                        }
                    }
                }

                transaccion.Commit();
                compra.IdCompra = idCompra;
                return idCompra;
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }

        // Devuelve las compras con proveedor y detalles para mostrar sus datos y total.
        public List<Compra> Listar()
        {
            return Consultar(null);
        }

        // Busca una compra por su ID, incluyendo sus detalles.
        public Compra? ObtenerPorId(int idCompra)
        {
            return Consultar(idCompra).FirstOrDefault();
        }

        // Consulta compras y detalles, opcionalmente limitando el resultado a un ID.
        private List<Compra> Consultar(int? idCompra)
        {
            const string consulta = @"
                SELECT c.IdCompra, c.IdProveedor, p.Nombre AS NombreProveedor,
                       c.FechaCompra, c.Estado,
                       dc.IdDetalleCompra, dc.IdProducto, pr.Nombre AS NombreProducto,
                       dc.Cantidad, dc.PrecioCosto
                FROM dbo.Compras AS c
                INNER JOIN dbo.Proveedores AS p ON p.IdProveedor = c.IdProveedor
                LEFT JOIN dbo.DetalleCompra AS dc ON dc.IdCompra = c.IdCompra
                LEFT JOIN dbo.Productos AS pr ON pr.IdProducto = dc.IdProducto
                WHERE @IdCompra IS NULL OR c.IdCompra = @IdCompra
                ORDER BY c.FechaCompra DESC, c.IdCompra, dc.IdDetalleCompra;";

            List<Compra> compras = new List<Compra>();
            Dictionary<int, Compra> comprasPorId = new Dictionary<int, Compra>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdCompra", SqlDbType.Int).Value = (object?)idCompra ?? DBNull.Value;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                int id = lector.GetInt32(lector.GetOrdinal("IdCompra"));
                if (!comprasPorId.TryGetValue(id, out Compra? compra))
                {
                    compra = new Compra(
                        lector.GetInt32(lector.GetOrdinal("IdProveedor")),
                        lector.GetDateTime(lector.GetOrdinal("FechaCompra")))
                    {
                        IdCompra = id,
                        NombreProveedor = lector.GetString(lector.GetOrdinal("NombreProveedor")),
                        Estado = lector.GetString(lector.GetOrdinal("Estado"))
                    };
                    comprasPorId.Add(id, compra);
                    compras.Add(compra);
                }

                int ordinalDetalle = lector.GetOrdinal("IdDetalleCompra");
                if (!lector.IsDBNull(ordinalDetalle))
                {
                    compra.Detalles.Add(new DetalleCompra(
                        lector.GetInt32(lector.GetOrdinal("IdProducto")),
                        lector.IsDBNull(lector.GetOrdinal("NombreProducto"))
                            ? null
                            : lector.GetString(lector.GetOrdinal("NombreProducto")),
                        lector.GetInt32(lector.GetOrdinal("Cantidad")),
                        lector.GetDecimal(lector.GetOrdinal("PrecioCosto")))
                    {
                        IdDetalleCompra = lector.GetInt32(ordinalDetalle),
                        IdCompra = id
                    });
                }
            }

            return compras;
        }
    }
}
