namespace Library;

public class Venta
{
    public string Objeto { get; set; }
    public double Precio { get; set; }
    public DateTime Fecha { get; private set; }
    public string Motivo { get; set; }

    public Venta(double unPrecio, string unMotivo, DateTime? unaFecha = null)
    {
        this.Precio = unPrecio;
        this.Fecha = unaFecha ?? DateTime.Now;
        this.Motivo = unMotivo;
    }
    
    public void MostrarVenta()
    {
        Console.WriteLine($"Producto: {Objeto}\n" +
                          $"Precio: {Precio}\n" +
                          $"Fecha de venta: {Fecha:dd/MM/yyyy HH:mm}\n" +
                          $"Motivo de venta: {Motivo}\n");
    }

}