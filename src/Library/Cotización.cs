namespace Library;

public class Cotizacion
{
    public string Motivo { get; set; }
    public double Precio { get; set; }
    public DateTime Fecha { get; set; }

    public Cotizacion(string unMotivo, double unPrecio, DateTime? unaFecha=null)
    {
        Motivo = unMotivo;
        Precio = unPrecio;
        Fecha = unaFecha ?? DateTime.Now;
    }

    public void MostrarCotización()
    {
        Console.WriteLine($"Motivo: {Motivo}");
        Console.WriteLine($"Precio ofrecido: {Precio}"); 
        Console.WriteLine($"Fecha de cotización: {Fecha:dd/MM/yyyy HH:mm}"); 
    }


}