using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

class Program
{
    static void Main(string[] args)
    {
        SqlConnection? conection = GestorBaseDatos.Inicializacion(server: ".", baseDeDatos: "Desafio2", user: "sa", password: "P@ssw0rd");
    }
}