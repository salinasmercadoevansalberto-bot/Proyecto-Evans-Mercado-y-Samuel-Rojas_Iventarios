using Microsoft.Data.SqlClient;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    public class ConexionBD
    {
        private const string CadenaConexion =
            @"Server=Evans-PC\SQLEXPRESS;
              Initial Catalog=SistemaInventarioVentas;
              Integrated Security=True;
              TrustServerCertificate=True;";

        // Crea una conexión nueva a la base de datos.
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        // Comprueba si se puede abrir la conexión.
        public bool ProbarConexion()
        {
            try
            {
                using SqlConnection conexion = ObtenerConexion();
                conexion.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
