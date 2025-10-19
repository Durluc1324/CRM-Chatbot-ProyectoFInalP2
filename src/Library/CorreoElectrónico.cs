namespace Library;

public class CorreoElectronico: Interaccion
{
    public string DireccionEmisor { get; set; }
    public string DireccionReceptor { get; set; }
    public string Contenido { get; set; }

    public CorreoElectronico (Usuario unUsuario, Cliente unCliente, bool usuarioEsEmisor, string unContenido,  DateTime? unaFecha = null) : base(unUsuario, unCliente, unaFecha)
    {
        Contenido = unContenido;
        if (usuarioEsEmisor)
        {
            DireccionEmisor = unUsuario.Correo;
            DireccionReceptor = unCliente.Correo;
        }
        else
        {
            DireccionEmisor = unCliente.Correo;
            DireccionReceptor = unUsuario.Correo;
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
        Console.WriteLine($"Emisor: {DireccionEmisor}");
        Console.WriteLine($"Receptor: {DireccionReceptor}");
        Console.WriteLine($"Contenido del correo: {Contenido}");
        Console.WriteLine($"Respondido: {(Respondido ? "Sí" : "No")}"); // operador ternario para reducir tamaño de código
        Console.WriteLine($"Nota: {(string.IsNullOrEmpty(Nota) ? "sin nota": Nota)}");
    }
}