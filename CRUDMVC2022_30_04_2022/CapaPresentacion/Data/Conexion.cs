using System.Data.SqlClient;

namespace CapaPresentacion.Data
{
    public class Conexion
    {
        private string con = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            con = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public string getCadenaSQL()
        {
            return con;
        }
    }
}
