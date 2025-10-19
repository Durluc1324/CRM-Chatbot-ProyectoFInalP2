namespace Library;

public class Cotización
{
    public string Motivo { get; set; }
    public double Precio { get; set; }
    public DateTime Fecha { get; set; }

    public Cotización(string unMotivo, double unPrecio, DateTime? unaFecha=null)
    {
        Motivo = unMotivo;
        Precio = unPrecio;
        Fecha = unaFecha ?? DateTime.Now;
    }

    public void MostrarCotización()
    {
        Console.WriteLine($"Motivo: {Motivo}\n" +
                          $"Precio ofrecido: {Precio}\n" +
                          $"Fecha de cotización: {Fecha:dd/MM/yyyy HH:mm}");
    }


}