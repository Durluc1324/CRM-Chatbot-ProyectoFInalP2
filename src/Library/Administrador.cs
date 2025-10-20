namespace Library;

public class Administrador: Usuario
{
    public Administrador(string unNombre, string unApellido, string unTelefono, string unCorreo, string unaContraseña) : base(unNombre,
        unApellido, unTelefono, unCorreo, unaContraseña)
    {
        
    }

    public override void MostrarPanelUsuario()
    {
        Console.WriteLine("──────────────");
        Console.WriteLine($"ADMINISTRADOR");
        Console.WriteLine("──────────────");
        Console.WriteLine($"Nombre completo: {Nombre} {Apellido}");
        Console.WriteLine($"Correo electrónico: {Correo}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine("Clientes:");
        foreach (Cliente cliente in ListaDeClientes)
        {
            Console.WriteLine($"- {cliente.Nombre} {cliente.Apellido}");
            
        }
    }
    
    public void CrearUsuario(string nombre, string apellido, string telefono, string correo, string contraseña)
    {
        GestorUsuarios.CrearUsuario(nombre, apellido, telefono, correo, contraseña);
    }

    public void SuspenderUsuario(Usuario usuario)
    {
        GestorUsuarios.SuspenderUsuario(usuario);
    }

    public void EliminarUsuario(Usuario usuario)
    {
        GestorUsuarios.EliminarUsuario(usuario);
    }

    public void ModificarUsuario(
        Usuario usuario,
        string nuevoNombre = null,
        string nuevoApellido = null,
        string nuevoTelefono = null,
        string nuevoCorreo = null
    )
    {
        GestorUsuarios.ModificarUsuario(usuario, nuevoNombre, nuevoApellido, nuevoTelefono, nuevoCorreo);
    }

    public void BuscarUsuario(string criterio)
    {
        GestorUsuarios.BuscarUsuario(criterio);
    }

    public void ObtenerTodosLosUsuarios()
    {
        GestorUsuarios.ObtenerTodosLosUsuarios();
    }

    public void AsignarClienteAOtroVendedor(Cliente unCliente, Usuario vendedorActual, Usuario nuevoVendedor)
    {
        GestorClientes.AsignarClienteAOtroVendedor(unCliente, vendedorActual, nuevoVendedor);
    }
    
}
