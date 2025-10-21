namespace Library.Test;

[TestClass]
public class GestorInteraccionesTests
{
    private Usuario usuarioActivo;
    private Usuario usuarioSuspendido;
    private Cliente cliente;
    private Interaccion interaccion;

    [TestInitialize]
    public void Setup()
    {
        Usuario usuarioActivo = new Usuario("Juan", "Perez", "123", "correo@mail.com", "pass");
        Usuario usuarioSuspendido = new Usuario("Ana", "Lopez", "456", "ana@mail.com", "pass");
        usuarioSuspendido.Suspender();

        cliente = new Cliente("Cliente1", "Apellido1", "111", "cli@mail.com", DateTime.Now, usuarioActivo);
        interaccion = new Mensaje(usuarioActivo, cliente, true, "Hola");
    }

    [TestMethod]
    public void AgregarInteraccion_UsuarioActivo_AgregaCorrectamente()
    {
        GestorInteracciones.AgregarInteraccion(cliente, interaccion);
        Assert.AreEqual(1, cliente.ListaDeInteracciones.Count);
        Assert.AreEqual(interaccion, cliente.ListaDeInteracciones[0]);
    }

    [TestMethod]
    public void AgregarInteraccion_UsuarioSuspendido_NoAgrega()
    {
        cliente.AsignadoA = usuarioSuspendido;
        using var sw = new StringWriter();
        Console.SetOut(sw);

        GestorInteracciones.AgregarInteraccion(cliente, interaccion);

        Assert.AreEqual(0, cliente.ListaDeInteracciones.Count);
        StringAssert.Contains(sw.ToString(), "El usuario asignado está suspendido");
    }

    [TestMethod]
    public void EliminarInteraccion_Existente_EliminaCorrectamente()
    {
        cliente.ListaDeInteracciones.Add(interaccion);
        GestorInteracciones.EliminarInteraccion(cliente, interaccion);
        Assert.AreEqual(0, cliente.ListaDeInteracciones.Count);
    }

    [TestMethod]
    public void AgregarNota_SinNotaPrevio_AgregaCorrectamente()
    {
        GestorInteracciones.AgregarNota(interaccion, "Esta es una nota");
        Assert.AreEqual("Esta es una nota", interaccion.Nota);
    }

    [TestMethod]
    public void ObtenerInteraccionesNoRespondidas_RetornaCorrectamente()
    {
        var mensaje1 = new Mensaje(usuarioActivo, cliente, true, "Hola1");
        var mensaje2 = new Mensaje(usuarioActivo, cliente, true, "Hola2");
        mensaje2.MarcarComoRespondido();

        cliente.ListaDeInteracciones.Add(mensaje1);
        cliente.ListaDeInteracciones.Add(mensaje2);

        var pendientes = GestorInteracciones.ObtenerInteraccionesNoRespondidas(usuarioActivo);

        Assert.AreEqual(1, pendientes.Count);
        Assert.AreEqual(mensaje1, pendientes[0]);
    }

    [TestMethod]
    public void MostrarInteracciones_FiltraPorTipoCorrectamente()
    {
        var mensaje = new Mensaje(usuarioActivo, cliente, true, "Texto");
        var reunion = new Reunion(usuarioActivo, cliente, "Sala1");
        cliente.ListaDeInteracciones.Add(mensaje);
        cliente.ListaDeInteracciones.Add(reunion);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        GestorInteracciones.MostrarInteracciones(cliente, tipo: "Reunion");
        string output = sw.ToString();

        StringAssert.Contains(output, "REUNIÓN");
        Assert.IsFalse(output.Contains("MENSAJE"), "No se esperaba encontrar 'MENSAJE' en la salida.");
    }
}
