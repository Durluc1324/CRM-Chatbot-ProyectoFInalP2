namespace Library;

public class Usuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    
    public string Contraseña { get; set; }
    public List<Cliente> ListaDeClientes { get; set; }
    public bool Suspendido { get; private set; } = false;

    public Usuario(string unNombre, string unApellido, string unTelefono, string unCorreo, string unaContraseña)
    {
        Nombre = unNombre;
        Apellido = unApellido;
        Telefono = unTelefono;
        Correo = unCorreo;
        ListaDeClientes = new List<Cliente>();
        Contraseña = unaContraseña;
    }
    public virtual void MostrarPanelUsuario()
    {
        Console.WriteLine("──────────────");
        Console.WriteLine($"USUARIO");
        Console.WriteLine("──────────────");
        Console.WriteLine($"Nombre completo: {Nombre} {Apellido}");
        Console.WriteLine($"Correo electrónico: {Correo}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine("Clientes:");
        foreach (Cliente cliente in ListaDeClientes)
        {
            Console.WriteLine($"{cliente.Nombre} {cliente.Apellido}");
            
            
        }
        
    }
    public void Suspender()
    {
        Suspendido = true;
    }

    public void Rehabilitar()
    {
        Suspendido = false;
    }
}