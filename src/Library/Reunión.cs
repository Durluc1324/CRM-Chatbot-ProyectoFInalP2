namespace Library;

public class Reunion: Interaccion
{
    public string Lugar { get; set; }

    public Reunion(Usuario unUsuario, Cliente unCliente, string unLugar, DateTime? unaFecha = null) : base(unUsuario, unCliente, unaFecha)
    {
        Lugar = string.IsNullOrWhiteSpace(unLugar) ? "Sin especificar" : unLugar;
    }
    
    public override void MostrarDetalle()
    {
        Console.WriteLine("──────────────");
        Console.WriteLine($"REUNIÓN");
        Console.WriteLine("──────────────");
        Console.WriteLine($"Usuario: {Usuario.Nombre} {Usuario.Apellido}");
        Console.WriteLine($"Cliente: {Cliente.Nombre} {Cliente.Apellido}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Lugar de reunion: {Lugar}");
        Console.WriteLine($"Reunión realizada: {(Respondido ? "Sí" : "No")}"); // operador ternario para reducir tamaño de código
        Console.WriteLine($"Nota: {(string.IsNullOrEmpty(Nota) ? "sin nota": Nota)}");
    }
}