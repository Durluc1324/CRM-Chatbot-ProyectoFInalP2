namespace Library;

public static class GestorUsuarios
{
    private static List<Usuario> listaUsuarios = new List<Usuario>();

    public static void CrearUsuario(string nombre, string apellido, string telefono, string correo, string contraseña)
    {
        foreach (Usuario usuario in listaUsuarios)
        {
            if (usuario.Telefono == telefono)
            {
                Console.WriteLine("Ya existe un usuario con ese número de teléfono.");
                return;
            }

            if (usuario.Correo == correo)
            {
                Console.WriteLine("Ya existe un usuario con ese correo electrónico.");
                return;
            }
        }

        Usuario nuevoUsuario = new Usuario(nombre, apellido, telefono, correo, contraseña);
        listaUsuarios.Add(nuevoUsuario);
        Console.WriteLine("Usuario creado correctamente.");
    }

    // Modificar los datos de un usuario
    public static void ModificarUsuario(Usuario usuario, string nuevoNombre = null, string nuevoApellido = null, string nuevoTelefono = null, string nuevoCorreo = null)
    {
        if (usuario == null)
        {
            Console.WriteLine("El usuario no puede ser nulo.");
            return;
        }
        
        if (usuario.Suspendido)
        {
            Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} está suspendido y no puede ser modificado.");
            return;
        }

        if (!string.IsNullOrEmpty(nuevoNombre))
        {
            usuario.Nombre = nuevoNombre;
        }

        if (!string.IsNullOrEmpty(nuevoApellido))
        {
            usuario.Apellido = nuevoApellido;
        }

        if (!string.IsNullOrEmpty(nuevoTelefono))
        {
            // Validar que no haya otro usuario con el mismo teléfono
            foreach (Usuario u in listaUsuarios)
            {
                if (u != usuario && u.Telefono == nuevoTelefono)
                {
                    Console.WriteLine("Ya existe otro usuario con ese teléfono.");
                    return;
                }
            }
            usuario.Telefono = nuevoTelefono;
        }

        if (!string.IsNullOrEmpty(nuevoCorreo))
        {
            // Validar que no haya otro usuario con el mismo correo
            foreach (Usuario u in listaUsuarios)
            {
                if (u != usuario && u.Correo == nuevoCorreo)
                {
                    Console.WriteLine("Ya existe otro usuario con ese correo electrónico.");
                    return;
                }
            }
            usuario.Correo = nuevoCorreo;
        }

        Console.WriteLine("Usuario modificado correctamente.");
    }

    // Suspender un usuario (por ejemplo, cambiar su estado)
    public static void SuspenderUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            Console.WriteLine("No se puede suspender un usuario nulo.");
            return;
        }

        usuario.Suspender(); // suponiendo que la clase Usuario tenga este método
        Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} ha sido suspendido.");
    }

    public static void RehabilitarUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            Console.WriteLine("No se puede rehabilitar un usuario nulo.");
            return;
        }

        usuario.Rehabilitar(); // suponiendo que la clase Usuario tenga este método
        Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} ha sido rehabilitado.");
    }

    // Eliminar un usuario
    public static void EliminarUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            Console.WriteLine("No se puede eliminar un usuario nulo.");
            return;
        }

        if (usuario.Suspendido)
        {
            Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} está suspendido y no puede ser eliminado.");
            return;
        }

        if (listaUsuarios.Contains(usuario))
        {
            listaUsuarios.Remove(usuario);
            Console.WriteLine("Usuario eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("El usuario no se encuentra en la lista.");
        }
    }

    // Buscar usuario por criterio (nombre, apellido, teléfono o correo)
    public static Usuario BuscarUsuario(string criterio)
    {
        foreach (Usuario usuario in listaUsuarios)
        {
            if (usuario.Nombre == criterio || usuario.Apellido == criterio || usuario.Telefono == criterio || usuario.Correo == criterio)
            {
                Console.WriteLine("Usuario encontrado:");
                usuario.MostrarPanelUsuario(); // suponiendo que existe este método
                return usuario;
            }
        }

        Console.WriteLine("Usuario no encontrado.");
        return null;
    }

    // Mostrar todos los usuarios
    public static List<Usuario> ObtenerTodosLosUsuarios()
    {
        foreach (Usuario usuario in listaUsuarios)
        {
            usuario.MostrarPanelUsuario();
        }

        return listaUsuarios;
    }

    public static void AsignarClienteAOtroVendedor(Cliente cliente, Usuario nuevoVendedor)
    {
        if (cliente == null || nuevoVendedor == null)
        {
            Console.WriteLine("Cliente o vendedor no válidos.");
            return;
        }

        if (nuevoVendedor.Suspendido)
        {
            Console.WriteLine($"El vendedor {nuevoVendedor.Nombre} está suspendido y no puede recibir clientes.");
            return;
        }

        // Buscar el vendedor actual
        Usuario vendedorActual = null;

        foreach (Usuario u in listaUsuarios)
        {
            if (u.ListaDeClientes.Contains(cliente))
            {
                vendedorActual = u;
                break;
            }
        }

        if (vendedorActual == null)
        {
            Console.WriteLine("El cliente no está asignado a ningún vendedor actual.");
            return;
        }

        if (vendedorActual.Suspendido)
        {
            Console.WriteLine($"El vendedor actual {vendedorActual.Nombre} está suspendido, por lo que el cliente no puede ser reasignado hasta su rehabilitación.");
            return;
        }

        vendedorActual.ListaDeClientes.Remove(cliente);
        nuevoVendedor.ListaDeClientes.Add(cliente);

        Console.WriteLine($"El cliente {cliente.Nombre} fue reasignado de {vendedorActual.Nombre} a {nuevoVendedor.Nombre}.");
    }
}