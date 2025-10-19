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

    public void AgregarNota(Cliente cliente, Interaccion unaInteraccion, string nota)
    {

    }

    public void MostrarClientesPocoFrecuentes(int diasSinContacto)
    {

    }

    public void CrearCliente(string nombre, string apellido, string telefono, string correo, DateTime fechaNacimiento)
    {

    }

    public void ModificarCLiente(string? nombre = null, string? apellido = null, string? telefono = null,
        string? correo = null, DateTime? fechaNacimiento = null)
    {

    }

    public void EliminarCliente(Cliente cliente)
    {

    }

    public void AñadirVenta(Venta venta, Cliente cliente)
    {

    }

    public void AñadirCotizacion(Cotizacion cotizacion, Cliente cliente)
    {

    }

    public void BuscarCliente(string criterio)
    {

    }

    public void ObtenerVentasPorPeriodo(DateTime inicio, DateTime fin)
    {

    }

    public void ObtenerCotizacionesPorPeriodo(DateTime inicio, DateTime fin)
    {

    }

    public void AsignarClienteAOtroVendedor(Cliente cliente, Usuario nuevoVendedor)
    {
        
    }

    public void AgregarInteraccion(Cliente cliente, Interaccion interaccion)
    {
        
    }

    public void EliminarInteraccion(Cliente cliente,Interaccion interaccion)
    {
        
    }

    public void MostrarInteracciones(Cliente cliente, string? tipo = null, DateTime? fecha = null)
    {
        
    }

    public void ObtenerInteraccionesNoRespondidas()
    {
        
    }
}