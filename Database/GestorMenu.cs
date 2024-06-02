using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update;

namespace Christian_Grimberg_58425_Desafio_2;

internal static class GestorMenu
{
    internal static bool MenuPrincipal(SqlConnection connection)
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
            "----------------------------------"
        );

        Console.Clear();
        Console.WriteLine(mainMenu);

        switch (Input("Seleccione una opcion"))
        {
            case "0":
                Console.WriteLine("Salida del programa");
                selection = false;
                break;
            case "1":
                MenuUsuarios(connection);
                break;
            default:
                Console.WriteLine("Opción no encontrada");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;
        }

        return selection;
    }

    private static void MenuUsuarios(SqlConnection connection)
    {
        string usersMenu = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
                "===========MENU USUARIOS==========",
                "-------Seleccione un numero-------",
                "1 - Obtener usuario por ID",
                "2 - Listar usuarios",
                "3 - Crear usuario",
                "4 - Modificar usuario",
                "5 - Eliminar usuario",
                "----------------------------------"
            );
        string userUpdateMenu = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
            "===========MODIFICAR USUARIO==========",
            "-------Seleccione un numero-------",
            "1 - Modificar el nombre",
            "2 - Modificar el apellido",
            "3 - Modificar el nombre de usuario",
            "4 - Modificar la contraseña",
            "5 - Modificar el email",
            "--------------------------------------"
        );

        Console.Clear();
        Console.WriteLine(usersMenu);

        switch (Input("Seleccione una opcion"))
        {
            case "1":
                Console.Clear();
                string userId = Input("Ingrese el ID del usuario a buscar");
                Usuario user = UsuarioData.ObtenerUsuario(connection, Convert.ToInt32(userId));

                if (!user.IsEmpty)
                {
                    Console.WriteLine("\n===========DATOS DEL USUARIO==========\n");
                    Console.WriteLine(user);
                    Console.WriteLine("======================================");
                }
                break;
            case "2":
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
            case "3":
                Usuario newUser = new Usuario();
                Console.Clear();
                try
                {
                    Console.WriteLine("===========NUEVO USUARIO==========\n");
                    Console.Write("Ingrese el nombre: ");
                    newUser.Nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido: ");
                    newUser.Apellido = Console.ReadLine();
                    Console.Write("Ingrese el nombre de inicio de sesion: ");
                    newUser.NombreUsuario = Console.ReadLine();
                    Console.Write("Ingrese la contraseña: ");
                    newUser.Contraseña = Console.ReadLine();
                    Console.Write("Ingrese el email: ");
                    newUser.Mail = Console.ReadLine();
                    Console.WriteLine("==================================");

                    if (!newUser.IsEmpty && UsuarioData.CrearUsuario(connection, newUser))
                    {
                        Console.WriteLine("Usuario creado con éxito");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[APPLICATION ERROR]: {ex.Message}");
                }
                break;
            case "4":
                Console.Clear();
                string agreeToUpdate;
                string userIdToUpdate = Input("Ingrese el ID a modificar");
                string fieldOption;
                Usuario userToUpdate = UsuarioData.ObtenerUsuario(connection, Convert.ToInt32(userIdToUpdate));

                if (!userToUpdate.IsEmpty)
                {
                    Console.WriteLine("\n===========DATOS DEL USUARIO==========\n");
                    Console.WriteLine(userToUpdate);
                    Console.WriteLine("======================================");

                    agreeToUpdate = Input("Desea modificar al usuario? S(Si) - N(No)");
                    if (!string.IsNullOrEmpty(agreeToUpdate) && agreeToUpdate.ToUpper()[0] == 'S')
                    {
                        Console.Clear();
                        Console.WriteLine(userUpdateMenu);
                        fieldOption = Input("Seleccione una opcion");

                        switch (fieldOption)
                        {
                            case "1":
                                Console.Write("Ingrese el nuevo nombre: ");
                                userToUpdate.Nombre = Console.ReadLine();

                                if (!userToUpdate.IsEmpty && UsuarioData.ModificarUsuario(connection, userToUpdate))
                                {
                                    Console.WriteLine("El nombre se modificó con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo modificar el nombre");
                                }
                                break;
                            case "2":
                                Console.Write("Ingrese el nuevo apellido: ");
                                userToUpdate.Apellido = Console.ReadLine();

                                if (!userToUpdate.IsEmpty && UsuarioData.ModificarUsuario(connection, userToUpdate))
                                {
                                    Console.WriteLine("El apellido se modificó con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo modificar el apellido");
                                }
                                break;
                            case "3":
                                Console.Write("Ingrese el nuevo nombre de usuario: ");
                                userToUpdate.NombreUsuario = Console.ReadLine();

                                if (!userToUpdate.IsEmpty && UsuarioData.ModificarUsuario(connection, userToUpdate))
                                {
                                    Console.WriteLine("El nombre del usuario se modificó con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo modificar el nombre del usuario");
                                }
                                break;
                            case "4":
                                Console.Write("Ingrese la nueva contraseña: ");
                                userToUpdate.Contraseña = Console.ReadLine();

                                if (!userToUpdate.IsEmpty && UsuarioData.ModificarUsuario(connection, userToUpdate))
                                {
                                    Console.WriteLine("La contraseña se modificó con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo modificar la contraseña");
                                }
                                break;
                            case "5":
                                Console.Write("Ingrese el nuevo email: ");
                                userToUpdate.Mail = Console.ReadLine();

                                if (!userToUpdate.IsEmpty && UsuarioData.ModificarUsuario(connection, userToUpdate))
                                {
                                    Console.WriteLine("El email se modificó con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo modificar el email");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                break;
            case "5":
                string agreeToDelete;

                Console.Clear();
                string userIdToDelete = Input("Ingrese el ID del usuario y toda su actividad a eliminar");
                Usuario userToDelete = UsuarioData.ObtenerUsuario(connection, Convert.ToInt32(userIdToDelete));

                if (!userToDelete.IsEmpty)
                {
                    Console.WriteLine("\n===========DATOS DEL USUARIO==========\n");
                    Console.WriteLine(userToDelete);
                    Console.WriteLine("======================================");
                    agreeToDelete = Input("Desea eliminar al usuario y toda su actividad? S(Si) - N(No)");

                    if (
                        !string.IsNullOrEmpty(agreeToDelete)
                        && agreeToDelete.ToUpper()[0] == 'S'
                        && UsuarioData.EliminarUsuario(connection, userToDelete)
                    )
                    {
                        Console.WriteLine("Se eliminó el usuario y toda su actividad.");
                    }
                }
                break;
            default:
                Console.WriteLine("Opción no encontrada");
                break;
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
    private static string? Input(string message)
    {
        string option = string.Empty;

        Console.Write("{0}: ", message);

        try
        {
            option = Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[APPLICATION ERROR]: {ex.Message}");
        }

        return option;
    }
}