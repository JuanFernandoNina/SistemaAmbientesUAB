using System.Configuration;
using System.Data.SqlClient;

namespace SistemaAmbientesUAB
{
    public class Conexion
    {
        private static string cadena = ConfigurationManager
            .ConnectionStrings["Conexion"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}