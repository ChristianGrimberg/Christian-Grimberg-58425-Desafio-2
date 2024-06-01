using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SqlConnection initializedConnection = GestorBaseDatos.Inicializacion(server: ".", database: "Desafio2", user: "sa", password: "P@ssw0rd");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[APPLICATION ERROR]: {ex.Message}");
        }
    }
}