namespace Christian_Grimberg_58425_Desafio_2;

class Program
{
    static void Main(string[] args)
    {
        GestorBaseDatos gestor = new GestorBaseDatos(server: ".", baseDeDatos: "Desafio2", user: "sa", password: "P@ssw0rd");
    }
}