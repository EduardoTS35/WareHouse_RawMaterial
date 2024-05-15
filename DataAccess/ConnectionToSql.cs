using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Data Source=SQL5053.site4now.net;Initial Catalog=db_aa6c2e_smateriaprima;User Id=db_aa6c2e_smateriaprima_admin;Password=Prueba12";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        //smateriaprima1 Prueba12
    }
}
