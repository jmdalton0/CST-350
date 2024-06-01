using CST350.Models;
using Microsoft.Data.SqlClient;

namespace CST350.Services
{
    public class SecurityDAO
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cst350;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool Create(RegistrationViewModel model)
        {
            string sql = "INSERT INTO dbo.Users (firstname, lastname, sex, age, state, email, username, password)";
            sql += "VALUES ('@FIRSTNAME', '@LASTNAME', '@SEX', '@AGE', '@STATE', '@EMAIL', '@USERNAME', '@PASSWORD');";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand comm = new SqlCommand(sql, conn);

                /*
                comm.Parameters.Add("@FIRSTNAME", System.Data.SqlDbType.NVarChar, 64).Value = model.FirstName;
                comm.Parameters.Add("@LASTNAME", System.Data.SqlDbType.NVarChar, 64).Value = model.LastName;
                comm.Parameters.Add("@SEX", System.Data.SqlDbType.Bit).Value = model.Sex == "Male" ? 1 : 0;
                comm.Parameters.Add("@AGE", System.Data.SqlDbType.Int).Value = model.Age;
                comm.Parameters.Add("@STATE", System.Data.SqlDbType.NVarChar, 64).Value = model.State;
                comm.Parameters.Add("@EMAIL", System.Data.SqlDbType.NVarChar, 64).Value = model.Email;
                comm.Parameters.Add("@USERNAME", System.Data.SqlDbType.NVarChar, 64).Value = model.Username;
                comm.Parameters.Add("@PASSWORD", System.Data.SqlDbType.NVarChar, 64).Value = model.Password;
                */

                try
                {
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }

            return false;
        }

        public bool Read(LoginViewModel model)
        {
            string sql = "SELECT * FROM dbo.Users WHERE username = @USERNAME and password = @PASSWORD";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add("@USERNAME", System.Data.SqlDbType.NVarChar, 64).Value = model.username;
                comm.Parameters.Add("@PASSWORD", System.Data.SqlDbType.NVarChar, 64).Value = model.password;

                try
                {
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }

            return false;
        }
    }
}
