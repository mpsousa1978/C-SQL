using Microsoft.Data.SqlClient;


namespace ConsoleApp5Sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=BeautySolun;Integrated Security=SSPI;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "select p.id_professional,p.Name,s.Description dsc_status From bt_professional p inner join bt_status s on p.id_status = s.id_status   ";
                    SqlCommand cnd = new SqlCommand(sqlQuery, connection);

                    using (SqlDataReader reader = cnd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id_professional"]} - {reader["Name"]} - status {reader["dsc_status"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.ToString()}");
                }

            }
        }
    }
}