using Microsoft.Data.SqlClient;
namespace Control_de_Inventarol.Control_de_inventario.services
{
    public class ConexionDB
    {
        private string cadenaConexion =
    @"Server=(localdb)\MSSQLLocalDB;
      Database=AutoRepuestoDB;
      Integrated Security=True;
      TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            return conexion;
        }
    }
}
