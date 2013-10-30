using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace NewsGenerator
{
    public class DBUtil
    {
        private string connectionString;

        public DBUtil()
        {
            var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
            var uri = new Uri(uriString);
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
            }.ConnectionString;
        }

        public DataSet GetNews()
        {
            string query = "SELECT * FROM News";
            SqlCommand cmd = new SqlCommand(query);
            return FillDataSet(cmd, "News");
        }

        public DataSet GetLeague()
        {
            string query = "SELECT * FROM League";
            SqlCommand cmd = new SqlCommand(query);
            return FillDataSet(cmd, "League");
        }

        public DataSet GetOpponent()
        {
            string query = "SELECT * FROM Opponent";
            SqlCommand cmd = new SqlCommand(query);
            return FillDataSet(cmd, "Opponent");
        }

        public DataSet GetPlayer()
        {
            string query = "SELECT * FROM Player";
            SqlCommand cmd = new SqlCommand(query);
            return FillDataSet(cmd, "Player");
        }

        public DataSet GetWins()
        {
            string query = "SELECT * FROM Wins";
            SqlCommand cmd = new SqlCommand(query);
            return FillDataSet(cmd, "Wins");
        }

        public DataSet GetText(string cat)
        {
            string query = "SELECT * FROM News where Category = @Cat;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Cat", cat);
            return FillDataSet(cmd, "Text");
        }

        private DataSet FillDataSet(SqlCommand cmd, string tableName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            cmd.Connection = con;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            try
            {
                con.Open();
                adapter.Fill(ds, tableName);
            }
            finally { con.Close(); }
            return ds;
        }

    }
}
