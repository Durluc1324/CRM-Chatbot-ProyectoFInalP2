using System.Runtime.InteropServices.JavaScript;

namespace Library;

public abstract class Interaccion
{
    public Usuario Usuario{ get; private set; }
    public Cliente Cliente { get; private set; }
    public DateTime Fecha { get; set; }
    public bool Respondido { get; private set; }
    public string Nota { get; set; }

    public Interaccion(Usuario unUsuario, Cliente unCliente, DateTime? unaFecha)
    {
        this.Usuario = unUsuario;
        this.Cliente = unCliente;
        this.Fecha = unaFecha ?? DateTime.Now;
        this.Respondido = false;
        this.Nota=String.Empty;

    }

    public void MarcarComoRespondido()
    {
        this.Respondido = true;
    }

    public abstract void MostrarDetalle();
}