using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

internal class GestorBaseDatos
{
    private readonly string _connectionString;
    
    internal GestorBaseDatos(string server, string baseDeDatos, string user, string password)
    {
        this._connectionString = $"Server={server}; User={user}; Password={password};";
        string newDatabaseQuery = $@"
                                SET NOCOUNT OFF;

                                IF NOT EXISTS(SELECT [name] FROM [sys].[databases] WHERE [name] = '{baseDeDatos}')
                                BEGIN
                                    CREATE DATABASE [{baseDeDatos}];
                                    SELECT 'Se crea la base de datos [{baseDeDatos}]';
                                END
                                ELSE
                                BEGIN
                                    SELECT 'La base de datos [{baseDeDatos}] ya existe';
                                END
                                ";

        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(newDatabaseQuery, connection);
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }

            connection.Close();
        }
    }
}
