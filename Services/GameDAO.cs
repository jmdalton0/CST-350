using CST350.Models;
using Microsoft.Data.SqlClient;

namespace CST350.Services
{
    public class GameDAO
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cst350;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool Create(BoardModel model)
        {
            string sql = "INSERT INTO dbo.Games (game)";
            sql += "VALUES (@Game);";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@Game", model.ToString());
                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {

                }
            }
            return true;
        }
    }
}
