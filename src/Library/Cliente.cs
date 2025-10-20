namespace Library;

public class Cliente
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public Usuario AsignadoA { get; set; }
    public List<Venta> ListaDeVentas;
    public List<Cotizacion> ListaDeCotizaciones;
    public List<Interaccion> ListaDeInteracciones;
    public List<string> Etiquetas;


    public Cliente(string unNombre, string unApellido, string unTelefono, string unCorreo, DateTime unaFecha,
        Usuario unUsuario)
    {
        Nombre = unNombre;
        Apellido = unApellido;
        Telefono = unTelefono;
        Correo = unCorreo;
        FechaNacimiento = unaFecha;
        AsignadoA = unUsuario;
        ListaDeVentas = new List<Venta>();
        ListaDeCotizaciones = new List<Cotizacion>();
        ListaDeInteracciones = new List<Interaccion>();
        Etiquetas = new List<string>();

    }

    public void AñadirVenta(Venta venta)
    {
        ListaDeVentas.Add(venta);
        Console.WriteLine($"Se añadió una nueva venta al cliente {Nombre} {Apellido}.");

    }

    public void AñadirCotizacion(Cotizacion cotizacion)
    {
        ListaDeCotizaciones.Add(cotizacion);
        Console.WriteLine($"Se añadió una nueva cotización al cliente {Nombre} {Apellido}.");

    }
}