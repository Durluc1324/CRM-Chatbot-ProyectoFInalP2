namespace Library;

public class Llamada : Interaccion
{
    public string NumeroEmisor { get; private set; }
    public string NumeroReceptor { get; private set; }
    public int DuracionSegundos { get; private set; }

    // Constructor
    public Llamada(Usuario unUsuario, Cliente unCliente, bool usuarioEsEmisor, string numeroEmisor, string numeroReceptor, int duracion, DateTime? unaFecha = null)
        : base(unUsuario, unCliente, unaFecha)
    {
        if (usuarioEsEmisor)
        {
            NumeroEmisor = unUsuario.Telefono;
            NumeroReceptor = unCliente.Telefono;
        }
        else
        {
            NumeroEmisor = unCliente.Telefono;
            NumeroReceptor = unUsuario.Telefono;
        }
        
        DuracionSegundos = duracion;
        
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine("──────────────");
        Console.WriteLine($"LLAMADA");
        Console.WriteLine("──────────────");
        Console.WriteLine($"Usuario: {Usuario.Nombre} {Usuario.Apellido}");
        Console.WriteLine($"Cliente: {Cliente.Nombre} {Cliente.Apellido}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Emisor: {NumeroEmisor}");
        Console.WriteLine($"Receptor: {NumeroReceptor}");
        Console.WriteLine($"Duración: {DuracionSegundos} segundos");
        Console.WriteLine($"Respondido: {(Respondido ? "Sí" : "No")}"); // operador ternario para reducir tamaño de código
        Console.WriteLine($"Nota: {(string.IsNullOrEmpty(Nota) ? "sin nota": Nota)}");
    }
}