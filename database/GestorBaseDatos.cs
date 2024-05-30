using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

internal class GestorBaseDatos
{
    private readonly string _connectionString;
    private readonly SqlConnection _connection;

    internal GestorBaseDatos(string server, string baseDeDatos, string user, string password)
    {
        _connectionString = $"Server={server}; User={user}; Password={password};";
        string newDatabaseQuery = $@"
                                    SET NOCOUNT OFF;

                                    IF NOT EXISTS(SELECT [name] FROM [sys].[databases] WHERE [name] = '{baseDeDatos}')
                                    BEGIN
                                        CREATE DATABASE [{baseDeDatos}];
                                        SELECT '[INFO]: Conectado a la nueva base de datos [{baseDeDatos}]';
                                    END
                                    ELSE
                                    BEGIN
                                        SELECT '[INFO]: Conectado a la base de datos existente [{baseDeDatos}]';
                                    END
                                    ";

        _connection = new SqlConnection(_connectionString);

        GetDatabaseQuery(_connection, newDatabaseQuery);
    }

    private static void GetDatabaseQuery(SqlConnection connection, string sqlCommand)
    {
        connection.Open();

        SqlCommand command = new SqlCommand(sqlCommand, connection);

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(string.Format("{0}", reader[0]));
            }
        }

        connection.Close();
    }
}
