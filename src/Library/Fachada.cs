namespace Library;

public static class Fachada
{
    public static void Inicio()
    {
        Console.WriteLine("Hola, bienvenido.");
        Console.WriteLine("Si ya tiene una cuenta registrada, envíe \"ingresar\"");
        Console.WriteLine("Si no tiene una cuenta, envíe \"registrarme\"");

        string opcion = Console.ReadLine()?.ToLower();

        if (opcion == "registrarme")
        {
            RegistroCuenta();
        }
        else if (opcion == "ingresar")
        {
            IngresoCuenta();
        }
        else
        {
            Console.WriteLine("Opción inválida, intente de nuevo.");
            Inicio(); // volver a mostrar menú
        }
    }

    private static void RegistroCuenta()
    {
        Console.WriteLine("Seleccione tipo de cuenta: 'administrador' o 'usuario'");
        string tipo = Console.ReadLine()?.ToLower();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Correo: ");
        string correo = Console.ReadLine();

        Console.Write("Contraseña: ");
        string contraseña = Console.ReadLine();

        if (tipo == "administrador")
        {
            GestorUsuarios.CrearAdministrador(nombre, apellido, telefono, correo, contraseña);
        }
        else
        {
            GestorUsuarios.CrearUsuario(nombre, apellido, telefono, correo, contraseña);
        }

        Console.WriteLine("Cuenta registrada con éxito. Puede ingresar ahora.");
        Inicio(); // regresar al inicio para login
    }

    private static void IngresoCuenta()
    {
        Console.Write("Ingrese su correo o teléfono: ");
        string identificador = Console.ReadLine();

        Usuario usuario = GestorUsuarios.BuscarUsuario(identificador);

        if (usuario != null)
        {
            Console.WriteLine($"Bienvenido {usuario.Nombre} {usuario.Apellido}!");
            
        }
        else
        {
            Console.WriteLine("Usuario no encontrado, intente registrarse.");
            Inicio();
        }
    }
}
