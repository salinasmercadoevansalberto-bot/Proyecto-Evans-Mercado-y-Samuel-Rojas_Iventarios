using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class BaseDatosCategoria
    {
        private readonly ConexionBD _conexionBD;

        // Prepara la clase usando la conexión predeterminada.
        public BaseDatosCategoria()
            : this(new ConexionBD())
        {
        }

        // Permite proporcionar una instancia de conexión.
        public BaseDatosCategoria(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        // Registra una categoría y devuelve el ID generado.
        public int Registrar(Categoria categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);

            const string consulta = @"
                INSERT INTO dbo.Categorias (Nombre, Descripcion)
                OUTPUT INSERTED.IdCategoria
                VALUES (@Nombre, @Descripcion);";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 80).Value = categoria.Nombre;
            comando.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 200).Value =
                (object?)categoria.Descripcion ?? DBNull.Value;

            conexion.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar());
            categoria.IdCategoria = id;
            return id;
        }

        // Devuelve todas las categorías ordenadas por nombre.
        public List<Categoria> Listar()
        {
            const string consulta = @"
                SELECT IdCategoria, Nombre, Descripcion
                FROM dbo.Categorias
                ORDER BY Nombre;";

            List<Categoria> categorias = new List<Categoria>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                categorias.Add(new Categoria(
                    lector.GetInt32(lector.GetOrdinal("IdCategoria")),
                    lector.GetString(lector.GetOrdinal("Nombre")),
                    lector.IsDBNull(lector.GetOrdinal("Descripcion"))
                        ? null
                        : lector.GetString(lector.GetOrdinal("Descripcion"))));
            }

            return categorias;
        }

        // Busca una categoría por su ID.
        public Categoria? ObtenerPorId(int idCategoria)
        {
            const string consulta = @"
                SELECT IdCategoria, Nombre, Descripcion
                FROM dbo.Categorias
                WHERE IdCategoria = @IdCategoria;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdCategoria", System.Data.SqlDbType.Int).Value = idCategoria;
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            if (!lector.Read())
            {
                return null;
            }

            int ordinalDescripcion = lector.GetOrdinal("Descripcion");
            return new Categoria(
                lector.GetInt32(lector.GetOrdinal("IdCategoria")),
                lector.GetString(lector.GetOrdinal("Nombre")),
                lector.IsDBNull(ordinalDescripcion) ? null : lector.GetString(ordinalDescripcion));
        }

        // Busca categorías cuyo nombre contenga el texto recibido.
        public List<Categoria> BuscarPorNombre(string nombre)
        {
            ArgumentNullException.ThrowIfNull(nombre);

            const string consulta = @"
                SELECT IdCategoria, Nombre, Descripcion
                FROM dbo.Categorias
                WHERE Nombre LIKE @Nombre
                ORDER BY Nombre;";

            List<Categoria> categorias = new List<Categoria>();
            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 82).Value = $"%{nombre}%";
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                int ordinalDescripcion = lector.GetOrdinal("Descripcion");
                categorias.Add(new Categoria(
                    lector.GetInt32(lector.GetOrdinal("IdCategoria")),
                    lector.GetString(lector.GetOrdinal("Nombre")),
                    lector.IsDBNull(ordinalDescripcion) ? null : lector.GetString(ordinalDescripcion)));
            }

            return categorias;
        }

        // Modifica el nombre y la descripción de una categoría.
        public bool Modificar(Categoria categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);

            const string consulta = @"
                UPDATE dbo.Categorias
                SET Nombre = @Nombre,
                    Descripcion = @Descripcion
                WHERE IdCategoria = @IdCategoria;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 80).Value = categoria.Nombre;
            comando.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 200).Value =
                (object?)categoria.Descripcion ?? DBNull.Value;
            comando.Parameters.Add("@IdCategoria", System.Data.SqlDbType.Int).Value = categoria.IdCategoria;

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }

        // Elimina una categoría si no tiene productos asociados.
        public bool Eliminar(int idCategoria)
        {
            const string consulta = @"
                DELETE FROM dbo.Categorias
                WHERE IdCategoria = @IdCategoria;";

            using SqlConnection conexion = _conexionBD.ObtenerConexion();
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@IdCategoria", System.Data.SqlDbType.Int).Value = idCategoria;

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }
    }
}
