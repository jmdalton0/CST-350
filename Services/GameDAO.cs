using CST350.Models;
using Microsoft.Data.SqlClient;

namespace CST350.Services
{
    public class GameDAO
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cst350;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<GameModel> AllGames()
        {
            List<GameModel> games = new List<GameModel>();

            string sql = "SELECT * FROM dbo.Games";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string cells = reader.GetString(1);

                            games.Add(new GameModel(id, cells));
                        }
                    }
                }
            }
            return games;
        }

        public GameModel GetById(int id)
        {
            string sql = "SELECT * FROM dbo.Games WHERE id = @Id";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                    conn.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            string cells = reader.GetString(1);

                            return new GameModel(id, cells);
                        }
                    }
                }
            }
            return null;
        }

        public void Create(GameModel gameModel)
        {
            string sql = "INSERT INTO dbo.Games (cells) VALUES (@Cells)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    string cells = gameModel.Serialize();

                    comm.Parameters.Add("@Cells", System.Data.SqlDbType.NVarChar).Value = cells;

                    conn.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {

                    }
                }
            }
        }

        public void Update(GameModel gameModel)
        {
            string sql = "UPDATE Games SET cells = @Cells WHERE id = @Id";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    string cells = gameModel.Serialize();

                    comm.Parameters.Add("@Cells", System.Data.SqlDbType.NVarChar).Value = cells;
                    comm.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = gameModel.id;

                    conn.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {

                    }
                }
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Games WHERE id = @Id";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                    conn.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {

                    }
                }
            }
        }
    }
}
