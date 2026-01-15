using System.Data.SqlClient;

namespace BlogManagementSystem.Data
{
    public static class Database
    {
        private static readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=|DataDirectory|\MyDatabase.mdf;
              Integrated Security=True;
              Connect Timeout=30";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

