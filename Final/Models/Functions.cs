using System;
using System.Data;
using System.Data.SqlClient;

namespace Final.Models
{
    public class Functions
    {
        private string ConStr;

        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sharu\Documents\PROJECTASPDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public DataTable GetData(string Query)
        {
            using (SqlConnection Con = new SqlConnection(ConStr))
            using (SqlDataAdapter sda = new SqlDataAdapter(Query, Con))
            {
                DataTable dt = new DataTable();
                try
                {
                    sda.Fill(dt);
                }
                catch (Exception ex)
                {
                    // Handle exception (log it, rethrow it, or display a message)
                    throw new Exception("Error executing GetData: " + ex.Message);
                }
                return dt;
            }
        }

        public int SetData(string Query)
        {
            using (SqlConnection Con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(Query, Con))
            {
                int cnt = 0;
                try
                {
                    Con.Open();
                    cnt = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception (log it, rethrow it, or display a message)
                    throw new Exception("Error executing SetData: " + ex.Message);
                }
                finally
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }
                return cnt;
            }
        }
    }
}
