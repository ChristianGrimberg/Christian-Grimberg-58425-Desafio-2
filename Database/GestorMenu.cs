using System.Data.SqlClient;

namespace Christian_Grimberg_58425_Desafio_2;

internal static class GestorMenu
{
    internal static bool Menu(SqlConnection connection)
    {
        bool selection = true;

        string mainMenu = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
        "==========MENU PRINCIPAL==========",
        "-------Seleccione un numero-------",
        "0 - Salir del programa",
        "1 - Menu de usuarios",
        "2 - Menu de productos",
        "3 - Menu de ventas",
        "4 - Menu de operaciones",
        "----------------------------------");

        string usersMenu = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
        "===========MENU USUARIOS==========",
        "-------Seleccione un numero-------",
        "1 - Obtener usuario por ID",
        "2 - Listar usuarios",
        "3 - Crear usuario",
        "4 - Modificar usuario",
        "5 - Eliminar usuario",
        "----------------------------------");

        Console.Clear();
        Console.WriteLine(mainMenu);

        switch (Input("Seleccione una opcion"))
        {
            case 0:
                Console.WriteLine("Salida del programa");
                selection = false;
                break;
            case 1:
                Console.Clear();
                Console.WriteLine(usersMenu);

                switch (Input("Seleccione una opcion"))
                {
                    case 1:
                        Console.Clear();
                        int userId = Input("Ingrese el ID a buscar");
                        Usuario user = UsuarioData.ObtenerUsuario(connection, userId);

                        if(!user.IsEmpty)
                        {
                            Console.WriteLine("\n===========DATOS DEL USUARIO==========\n");
                            Console.WriteLine(user);
                            Console.WriteLine("======================================");
                        }
                        break;
                    case 2:
                        if (UsuarioData.ListarUsuarios(connection).Capacity > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("===========LISTADO USUARIOS==========\n");
                            foreach (var item in UsuarioData.ListarUsuarios(connection))
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("=====================================");
                        }
                        else
                        {
                            Console.WriteLine("No hay usuarios en el sistema");
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no encontrada");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();

                break;
            default:
                Console.WriteLine("Opción no encontrada");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;
        }

        return selection;
    }

    internal static int Input(string message)
    {
        int option = -1;

        Console.Write("{0}: ", message);

        try
        {
            option = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[APPLICATION ERROR]: {ex.Message}");
        }

        return option;
    }
}