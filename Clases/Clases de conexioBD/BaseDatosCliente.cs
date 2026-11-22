using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;
using System.Data;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class BaseDatosCliente
    {
        private readonly ConexionBD _conexionBD;

        // Prepara la clase usando la conexión predeterminada.
        public BaseDatosCliente()
            : this(new ConexionBD())
        {
        }

        // Permite proporcionar una instancia de conexión.
        public BaseDatosCliente(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        // Registra un cliente y devuelve el ID generado.
        public int Registrar(Cliente cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);

            const string consulta = @"
                INSERT INTO dbo.Clientes (Nombre, Cedula, Telefono, Correo, Direccion, Estado)
                OUTPUT INSERTED.IdCliente
                VALUES (@Nombre, @Cedula, @Telefono, @Correo, @Direccion, @Estado);";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            AgregarParametrosCliente(comando, cliente);

            conexion.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar());
            cliente.IdCliente = id;
            return id;
        }

        // Devuelve los clientes, con opción de incluir solo los activos.
        public List<Cliente> Listar(bool soloActivos = false)
        {
            const string consulta = @"
                SELECT IdCliente, Nombre, Cedula, Telefono, Correo, Direccion, Estado
                FROM dbo.Clientes
                WHERE @SoloActivos = 0 OR Estado = 1
                ORDER BY Nombre;";

            List<Cliente> clientes = new List<Cliente>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@SoloActivos", SqlDbType.Bit).Value = soloActivos;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                clientes.Add(LeerCliente(lector));
            }

            return clientes;
        }

        // Busca un cliente por su ID.
        public Cliente? ObtenerPorId(int idCliente)
        {
            const string consulta = @"
                SELECT IdCliente, Nombre, Cedula, Telefono, Correo, Direccion, Estado
                FROM dbo.Clientes
                WHERE IdCliente = @IdCliente;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            return lector.Read() ? LeerCliente(lector) : null;
        }

        // Busca clientes cuyo nombre contenga el texto recibido.
        public List<Cliente> BuscarPorNombre(string nombre)
        {
            ArgumentNullException.ThrowIfNull(nombre);

            const string consulta = @"
                SELECT IdCliente, Nombre, Cedula, Telefono, Correo, Direccion, Estado
                FROM dbo.Clientes
                WHERE Nombre LIKE @Nombre
                ORDER BY Nombre;";

            List<Cliente> clientes = new List<Cliente>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 102).Value = $"%{nombre}%";
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                clientes.Add(LeerCliente(lector));
            }

            return clientes;
        }

        // Modifica los datos del cliente; devuelve false si no existe.
        public bool Modificar(Cliente cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);

            const string consulta = @"
                UPDATE dbo.Clientes
                SET Nombre = @Nombre,
                    Cedula = @Cedula,
                    Telefono = @Telefono,
                    Correo = @Correo,
                    Direccion = @Direccion,
                    Estado = @Estado
                WHERE IdCliente = @IdCliente;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            AgregarParametrosCliente(comando, cliente);
            comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = cliente.IdCliente;

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Desactiva un cliente sin borrar sus registros relacionados.
        public bool Desactivar(int idCliente)
        {
            return CambiarEstado(idCliente, false);
        }

        // Reactiva un cliente previamente desactivado.
        public bool Activar(int idCliente)
        {
            return CambiarEstado(idCliente, true);
        }

        // Agrega al comando los campos de cliente, convirtiendo nulos a DBNull.
        private static void AgregarParametrosCliente(SqlCommand comando, Cliente cliente)
        {
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = cliente.Nombre;
            comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 30).Value = (object?)cliente.Cedula ?? DBNull.Value;
            comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = (object?)cliente.Telefono ?? DBNull.Value;
            comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 100).Value = (object?)cliente.Correo ?? DBNull.Value;
            comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = (object?)cliente.Direccion ?? DBNull.Value;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = cliente.Estado;
        }

        // Cambia el estado activo del cliente.
        private bool CambiarEstado(int idCliente, bool estado)
        {
            const string consulta = @"
                UPDATE dbo.Clientes
                SET Estado = @Estado
                WHERE IdCliente = @IdCliente;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = estado;
            comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Convierte la fila actual del lector en un objeto Cliente.
        private static Cliente LeerCliente(SqlDataReader lector)
        {
            return new Cliente(
                lector.GetInt32(lector.GetOrdinal("IdCliente")),
                lector.GetString(lector.GetOrdinal("Nombre")),
                LeerTextoNullable(lector, "Cedula"),
                LeerTextoNullable(lector, "Telefono"),
                LeerTextoNullable(lector, "Correo"),
                LeerTextoNullable(lector, "Direccion"),
                lector.GetBoolean(lector.GetOrdinal("Estado")));
        }

        // Devuelve null si la columna de texto contiene SQL NULL.
        private static string? LeerTextoNullable(SqlDataReader lector, string columna)
        {
            int ordinal = lector.GetOrdinal(columna);
            return lector.IsDBNull(ordinal) ? null : lector.GetString(ordinal);
        }
    }
}
