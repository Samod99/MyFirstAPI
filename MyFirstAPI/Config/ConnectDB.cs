using System.Data.SqlClient;

namespace MyFirstAPI.Config
{
    public class ConnectDB
    {
        public static string getConnectionString()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = @"MSI\SQLEXPRESS";
            csb.InitialCatalog = "University";
            csb.IntegratedSecurity = true;

            return csb.ToString();
        }
    }
}
