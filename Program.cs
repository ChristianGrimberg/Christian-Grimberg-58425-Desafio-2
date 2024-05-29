using System.Data.SqlClient;

namespace Desafio_2;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=.; Database=Desafio2; User=sa; Password=P@ssw0rd;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"SELECT [name]
                            FROM [sys].[databases]
                            WHERE [name] = 'Desafio2';";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var data = dataReader.GetString(0);
                            Console.WriteLine(data);
                        }
                    }
                }
            }
        }
    }
}