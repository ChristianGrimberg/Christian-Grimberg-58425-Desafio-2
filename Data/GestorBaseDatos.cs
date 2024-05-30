using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

internal class GestorBaseDatos
{
    private readonly string _connectionString;

    internal GestorBaseDatos(string server, string baseDeDatos, string user, string password)
    {
        string newDatabaseQuery = $@"
                                    IF NOT EXISTS(SELECT [name] FROM [sys].[databases] WHERE [name] = '{baseDeDatos}')
                                    BEGIN
                                        CREATE DATABASE [{baseDeDatos}];
                                        SELECT 'Conectado a la nueva base de datos [{baseDeDatos}]';
                                    END
                                    ELSE
                                    BEGIN
                                        SELECT 'Conectado a la base de datos existente [{baseDeDatos}]';
                                    END
                                    ";

        _connectionString = $"Server={server}; User={user}; Password={password};";

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(newDatabaseQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("[INFO]: {0}", reader[0]));
                    }
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR]: {ex.Message}");
        }
    }
}