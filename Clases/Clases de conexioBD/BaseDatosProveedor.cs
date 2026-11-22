using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;
using System.Data;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class BaseDatosProveedor
    {
        private readonly ConexionBD _conexionBD;

        // Prepara la clase usando la conexión predeterminada.
        public BaseDatosProveedor()
            : this(new ConexionBD())
        {
        }

        // Permite proporcionar una instancia de conexión.
        public BaseDatosProveedor(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        // Registra un proveedor y devuelve el ID generado.
        public int Registrar(Proveedor proveedor)
        {
            ArgumentNullException.ThrowIfNull(proveedor);

            const string consulta = @"
                INSERT INTO dbo.Proveedores (Codigo, Nombre, Telefono, Correo, Direccion, Estado)
                OUTPUT INSERTED.IdProveedor
                VALUES (@Codigo, @Nombre, @Telefono, @Correo, @Direccion, @Estado);";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            AgregarParametrosProveedor(comando, proveedor);

            conexion.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar());
            proveedor.IdProveedor = id;
            return id;
        }

        // Devuelve los proveedores, con opción de incluir solo los activos.
        public List<Proveedor> Listar(bool soloActivos = false)
        {
            const string consulta = @"
                SELECT IdProveedor, Codigo, Nombre, Telefono, Correo, Direccion, Estado
                FROM dbo.Proveedores
                WHERE @SoloActivos = 0 OR Estado = 1
                ORDER BY Nombre;";

            List<Proveedor> proveedores = new List<Proveedor>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@SoloActivos", SqlDbType.Bit).Value = soloActivos;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                proveedores.Add(LeerProveedor(lector));
            }

            return proveedores;
        }

        // Busca un proveedor por su ID.
        public Proveedor? ObtenerPorId(int idProveedor)
        {
            const string consulta = @"
                SELECT IdProveedor, Codigo, Nombre, Telefono, Correo, Direccion, Estado
                FROM dbo.Proveedores
                WHERE IdProveedor = @IdProveedor;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = idProveedor;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            return lector.Read() ? LeerProveedor(lector) : null;
        }

        // Busca proveedores cuyo nombre contenga el texto recibido.
        public List<Proveedor> BuscarPorNombre(string nombre)
        {
            ArgumentNullException.ThrowIfNull(nombre);

            const string consulta = @"
                SELECT IdProveedor, Codigo, Nombre, Telefono, Correo, Direccion, Estado
                FROM dbo.Proveedores
                WHERE Nombre LIKE @Nombre
                ORDER BY Nombre;";

            List<Proveedor> proveedores = new List<Proveedor>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 102).Value = $"%{nombre}%";
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                proveedores.Add(LeerProveedor(lector));
            }

            return proveedores;
        }

        // Busca un proveedor por su código propio.
        public Proveedor? ObtenerPorCodigo(string codigo)
        {
            ArgumentNullException.ThrowIfNull(codigo);
            const string consulta = @"
                SELECT IdProveedor, Codigo, Nombre, Telefono, Correo, Direccion, Estado
                FROM dbo.Proveedores
                WHERE Codigo = @Codigo;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 30).Value = codigo;
            conexion.Open();
            using SqlDataReader lector = comando.ExecuteReader();
            return lector.Read() ? LeerProveedor(lector) : null;
        }

        // Modifica los datos del proveedor; devuelve false si no existe.
        public bool Modificar(Proveedor proveedor)
        {
            ArgumentNullException.ThrowIfNull(proveedor);

            const string consulta = @"
                UPDATE dbo.Proveedores
                SET Codigo = @Codigo,
                    Nombre = @Nombre,
                    Telefono = @Telefono,
                    Correo = @Correo,
                    Direccion = @Direccion,
                    Estado = @Estado
                WHERE IdProveedor = @IdProveedor;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            AgregarParametrosProveedor(comando, proveedor);
            comando.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = proveedor.IdProveedor;

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Desactiva un proveedor sin borrar las compras relacionadas.
        public bool Desactivar(int idProveedor)
        {
            return CambiarEstado(idProveedor, false);
        }

        // Reactiva un proveedor previamente desactivado.
        public bool Activar(int idProveedor)
        {
            return CambiarEstado(idProveedor, true);
        }

        // Agrega al comando los datos del proveedor.
        private static void AgregarParametrosProveedor(SqlCommand comando, Proveedor proveedor)
        {
            comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 30).Value = proveedor.Codigo;
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = proveedor.Nombre;
            comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = (object?)proveedor.Telefono ?? DBNull.Value;
            comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 100).Value = (object?)proveedor.Correo ?? DBNull.Value;
            comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = (object?)proveedor.Direccion ?? DBNull.Value;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = proveedor.Estado;
        }

        // Cambia el estado activo del proveedor.
        private bool CambiarEstado(int idProveedor, bool estado)
        {
            const string consulta = @"
                UPDATE dbo.Proveedores
                SET Estado = @Estado
                WHERE IdProveedor = @IdProveedor;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = estado;
            comando.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = idProveedor;

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Convierte la fila actual del lector en un objeto Proveedor.
        private static Proveedor LeerProveedor(SqlDataReader lector)
        {
            return new Proveedor(
                lector.GetInt32(lector.GetOrdinal("IdProveedor")),
                lector.GetString(lector.GetOrdinal("Nombre")),
                LeerTextoNullable(lector, "Telefono"),
                LeerTextoNullable(lector, "Correo"),
                LeerTextoNullable(lector, "Direccion"),
                lector.GetBoolean(lector.GetOrdinal("Estado")),
                lector.GetString(lector.GetOrdinal("Codigo")));
        }

        // Devuelve null si la columna de texto contiene SQL NULL.
        private static string? LeerTextoNullable(SqlDataReader lector, string columna)
        {
            int ordinal = lector.GetOrdinal(columna);
            return lector.IsDBNull(ordinal) ? null : lector.GetString(ordinal);
        }
    }
}
