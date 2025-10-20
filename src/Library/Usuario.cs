namespace Library;

public class Usuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public List<Cliente> ListaDeClientes;

    public Usuario(string unNombre, string unApellido, string unTelefono, string unCorreo)
    {
        Nombre = unNombre;
        Apellido = unApellido;
        Telefono = unTelefono;
        Correo = unCorreo;
        ListaDeClientes = new List<Cliente>();
    }
    
}