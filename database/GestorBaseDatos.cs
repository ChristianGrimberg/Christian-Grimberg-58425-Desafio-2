using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

public class GestorBaseDatos
{
    private readonly string _connectionString;
    public GestorBaseDatos(string baseDeDatos)
    {
        this._connectionString = $"Server=.; User=sa; Password=P@ssw0rd;";
        string newDatabaseQuery = $@"
                                SET NOCOUNT OFF;

                                IF NOT EXISTS(SELECT [name] FROM [sys].[databases] WHERE [name] = '{baseDeDatos}')
                                BEGIN
                                    CREATE DATABASE [{baseDeDatos}];
                                    SELECT 'Se crea la base de datos';
                                END
                                ELSE
                                BEGIN
                                    SELECT 'La base de datos ya existe';
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
