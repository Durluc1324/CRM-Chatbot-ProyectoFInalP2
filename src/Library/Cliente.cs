namespace Library;

public class Cliente
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public Usuario asignadoA;
    public List<Venta> listaDeVentas;
    public List<Cotizacion> listaDeCotizaciones;
    public List<string> etiquetas;
    public List<Interaccion> listaDeInteracciones;

    public Cliente(string unNombre, string unApellido, string unTelefono, string unCorreo, DateTime unaFecha,
        Usuario unUsuario)
    {
        Nombre = unNombre;
        Apellido = unApellido;
        Telefono = unTelefono;
    }
}