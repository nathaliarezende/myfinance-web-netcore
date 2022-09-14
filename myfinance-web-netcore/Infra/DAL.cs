using System.Data.SqlClient;
using System.Data;

namespace myfinance_web_netcore.Infra
{
    public class DAL
    {
        private SqlConnection conn;
        private string connectionString;
        public static IConfiguration? Configuration;
        private static DAL? Instance;

        public static DAL getInstance
        {
            get {
                if (Instance == null)
                    Instance = new();
                return Instance;
            }
        }

        private DAL() 
        {
            connectionString = Configuration.GetValue<string>("ConnectionString");
        }

        public void  Conect() 
        {
            conn = new();
            conn.ConnectionString = connectionString;
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }

        //SELECT
        public DataTable ReturnDataTable(string sql)
        {
            var dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dataTable);
            return dataTable;
        }

        //INSERT, UPDATE, DELETE
        public void ExecuteSQLCommand(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }
    }
}