namespace Library;

public class Mensaje : Interaccion
{
    public string NumeroEmisor { get; set; }
    public string NumeroReceptor { get; set; }
    
    public string Texto { get; set; }

    public Mensaje (Usuario unUsuario, Cliente unCliente, bool usuarioEsEmisor, string unTexto, DateTime? unaFecha=null) : base(unUsuario, unCliente, unaFecha)
    {
        Texto = unTexto;
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
        
        
        
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine("──────────────");
        Console.WriteLine($"MENSAJE");
        Console.WriteLine("──────────────");
        Console.WriteLine($"Usuario: {Usuario.Nombre} {Usuario.Apellido}");
        Console.WriteLine($"Cliente: {Cliente.Nombre} {Cliente.Apellido}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Emisor: {NumeroEmisor}");
        Console.WriteLine($"Receptor: {NumeroReceptor}");
        Console.WriteLine($"Texto: {Texto}");
        Console.WriteLine($"Respondido: {(Respondido ? "Sí" : "No")}"); // operador ternario para reducir tamaño de código
        Console.WriteLine($"Nota: {(string.IsNullOrEmpty(Nota) ? "sin nota": Nota)}");
    }
}