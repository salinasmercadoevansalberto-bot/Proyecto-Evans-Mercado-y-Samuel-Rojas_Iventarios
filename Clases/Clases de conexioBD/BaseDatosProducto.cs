using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;
using System.Data;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class BaseDatosProducto
    {
        private readonly ConexionBD _conexionBD;

        // Prepara la clase usando la conexión predeterminada.
        public BaseDatosProducto()
            : this(new ConexionBD())
        {
        }

        // Permite proporcionar una instancia de conexión.
        public BaseDatosProducto(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        // Registra un producto y devuelve el ID generado.
        public int Registrar(Producto producto)
        {
            ArgumentNullException.ThrowIfNull(producto);
            const string consulta = @"
                INSERT INTO dbo.Productos
                    (IdCategoria, Codigo, Nombre, PrecioCosto, PrecioVenta, Existencias, Estado)
                OUTPUT INSERTED.IdProducto
                VALUES
                    (@IdCategoria, @Codigo, @Nombre, @PrecioCosto, @PrecioVenta, @Existencias, @Estado);";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            AgregarParametrosProducto(comando, producto);
            conexion.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar());
            producto.IdProducto = id;
            return id;
        }

        // Devuelve productos con el nombre de su categoría para mostrarlos en el DataGridView.
        public List<Producto> Listar(bool soloActivos = false)
        {
            const string consulta = @"
                SELECT p.IdProducto, p.IdCategoria, c.Nombre AS NombreCategoria,
                       p.Codigo, p.Nombre, p.PrecioCosto, p.PrecioVenta, p.Existencias, p.Estado
                FROM dbo.Productos AS p
                INNER JOIN dbo.Categorias AS c ON c.IdCategoria = p.IdCategoria
                WHERE @SoloActivos = 0 OR p.Estado = 1
                ORDER BY p.Nombre;";

            List<Producto> productos = new List<Producto>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@SoloActivos", SqlDbType.Bit).Value = soloActivos;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read()) productos.Add(LeerProducto(lector));
            return productos;
        }

        // Busca un producto por su ID.
        public Producto? ObtenerPorId(int idProducto)
        {
            const string consulta = @"
                SELECT p.IdProducto, p.IdCategoria, c.Nombre AS NombreCategoria,
                       p.Codigo, p.Nombre, p.PrecioCosto, p.PrecioVenta, p.Existencias, p.Estado
                FROM dbo.Productos AS p
                INNER JOIN dbo.Categorias AS c ON c.IdCategoria = p.IdCategoria
                WHERE p.IdProducto = @IdProducto;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();
            return lector.Read() ? LeerProducto(lector) : null;
        }

        // Busca productos cuyo nombre contenga el texto recibido.
        public List<Producto> BuscarPorNombre(string nombre, bool soloActivos = false)
        {
            ArgumentNullException.ThrowIfNull(nombre);
            const string consulta = @"
                SELECT p.IdProducto, p.IdCategoria, c.Nombre AS NombreCategoria,
                       p.Codigo, p.Nombre, p.PrecioCosto, p.PrecioVenta, p.Existencias, p.Estado
                FROM dbo.Productos AS p
                INNER JOIN dbo.Categorias AS c ON c.IdCategoria = p.IdCategoria
                WHERE p.Nombre LIKE @Nombre
                  AND (@SoloActivos = 0 OR p.Estado = 1)
                ORDER BY p.Nombre;";

            List<Producto> productos = new List<Producto>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 102).Value = $"%{nombre}%";
            comando.Parameters.Add("@SoloActivos", SqlDbType.Bit).Value = soloActivos;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read()) productos.Add(LeerProducto(lector));
            return productos;
        }

        // Busca un producto por su código.
        public Producto? ObtenerPorCodigo(string codigo)
        {
            ArgumentNullException.ThrowIfNull(codigo);
            const string consulta = @"
                SELECT p.IdProducto, p.IdCategoria, c.Nombre AS NombreCategoria,
                       p.Codigo, p.Nombre, p.PrecioCosto, p.PrecioVenta, p.Existencias, p.Estado
                FROM dbo.Productos AS p
                INNER JOIN dbo.Categorias AS c ON c.IdCategoria = p.IdCategoria
                WHERE p.Codigo = @Codigo;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 30).Value = codigo;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();
            return lector.Read() ? LeerProducto(lector) : null;
        }

        // Modifica los datos del producto; devuelve false si no existe.
        public bool Modificar(Producto producto)
        {
            ArgumentNullException.ThrowIfNull(producto);
            const string consulta = @"
                UPDATE dbo.Productos
                SET IdCategoria = @IdCategoria, Codigo = @Codigo, Nombre = @Nombre,
                    PrecioCosto = @PrecioCosto, PrecioVenta = @PrecioVenta,
                    Existencias = @Existencias, Estado = @Estado
                WHERE IdProducto = @IdProducto;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            AgregarParametrosProducto(comando, producto);
            comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = producto.IdProducto;
            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Desactiva un producto sin borrar sus detalles de compra o venta.
        public bool Desactivar(int idProducto) => CambiarEstado(idProducto, false);

        // Reactiva un producto previamente desactivado.
        public bool Activar(int idProducto) => CambiarEstado(idProducto, true);

        // Agrega al comando los campos del producto.
        private static void AgregarParametrosProducto(SqlCommand comando, Producto producto)
        {
            comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = producto.IdCategoria;
            comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 30).Value = producto.Codigo;
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto.Nombre;
            comando.Parameters.Add("@PrecioCosto", SqlDbType.Decimal).Value = producto.PrecioCosto;
            comando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = producto.PrecioVenta;
            comando.Parameters.Add("@Existencias", SqlDbType.Int).Value = producto.Existencias;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = producto.Estado;
        }

        // Cambia el estado activo del producto.
        private bool CambiarEstado(int idProducto, bool estado)
        {
            const string consulta = @"
                UPDATE dbo.Productos SET Estado = @Estado WHERE IdProducto = @IdProducto;";
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = estado;
            comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Convierte la fila actual del lector en un objeto Producto.
        private static Producto LeerProducto(SqlDataReader lector)
        {
            return new Producto(
                lector.GetInt32(lector.GetOrdinal("IdProducto")),
                lector.GetInt32(lector.GetOrdinal("IdCategoria")),
                lector.GetString(lector.GetOrdinal("Codigo")),
                lector.GetString(lector.GetOrdinal("Nombre")),
                lector.GetDecimal(lector.GetOrdinal("PrecioCosto")),
                lector.GetDecimal(lector.GetOrdinal("PrecioVenta")),
                lector.GetInt32(lector.GetOrdinal("Existencias")),
                lector.GetBoolean(lector.GetOrdinal("Estado")))
            {
                NombreCategoria = lector.GetString(lector.GetOrdinal("NombreCategoria"))
            };
        }
    }
}
