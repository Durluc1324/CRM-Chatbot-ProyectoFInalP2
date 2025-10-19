namespace Library;

public class Venta
{
    public string Objeto { get; set; }
    public double Precio { get; set; }
    public DateTime Fecha { get; private set; }
    public string Motivo { get; set; }

    public Venta(double unPrecio, string unMotivo, DateTime? unaFecha = null)
    {
        Precio = unPrecio;
        Fecha = unaFecha ?? DateTime.Now;
        Motivo = unMotivo;
    }

    /// <summary>
    /// Crear las ventas de la siguiente manera:
    /// Venta v1 = new Venta(500, "Venta de laptop"); // usa fecha actual
    /// Venta v2 = new Venta(600, "Venta antigua", new DateTime(2025, 6, 4)); // fecha específica
    /// </summary>

    public void MostrarVenta()
    {
        Console.WriteLine($"Producto: {Objeto}\n" +
                          $"Precio: {Precio}\n" +
                          $"Fecha de venta: {Fecha:dd/MM/yyyy HH:mm}\n" +
                          $"Motivo de venta: {Motivo}\n");
    }

}