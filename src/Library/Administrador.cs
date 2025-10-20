namespace Library;

public class Administrador: Usuario
{
    public Administrador(string unNombre, string unApellido, string unTelefono, string unCorre) : base(unNombre,
        unApellido, unTelefono, unCorre)
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
}