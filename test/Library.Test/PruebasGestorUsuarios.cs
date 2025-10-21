namespace Library.Test;

[TestClass]
public class GestorUsuariosTests
{
    [TestInitialize]
    public void Setup()
    {
        // Antes de cada prueba, reiniciamos la lista interna usando reflexión
        var listaField = typeof(GestorUsuarios)
            .GetField("listaUsuarios", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        listaField.SetValue(null, new System.Collections.Generic.List<Usuario>());
    }

    [TestMethod]
    public void CrearUsuario_AgregaUsuarioCorrectamente()
    {
        GestorUsuarios.CrearUsuario("Juan", "Perez", "123", "juan@mail.com", "1234");
        var todos = GestorUsuarios.ObtenerTodosLosUsuarios();
        Assert.AreEqual(1, todos.Count);
        Assert.AreEqual("Juan", todos[0].Nombre);
        Assert.AreEqual("Perez", todos[0].Apellido);
    }

    [TestMethod]
    public void CrearUsuario_NoPermiteCorreoDuplicado()
    {
        GestorUsuarios.CrearUsuario("Juan", "Perez", "123", "juan@mail.com", "1234");
        GestorUsuarios.CrearUsuario("Ana", "Lopez", "456", "juan@mail.com", "abcd"); // mismo correo
        var todos = GestorUsuarios.ObtenerTodosLosUsuarios();
        Assert.AreEqual(1, todos.Count);
    }

    [TestMethod]
    public void CrearUsuario_NoPermiteTelefonoDuplicado()
    {
        GestorUsuarios.CrearUsuario("Juan", "Perez", "123", "juan@mail.com", "1234");
        GestorUsuarios.CrearUsuario("Ana", "Lopez", "123", "ana@mail.com", "abcd"); // mismo teléfono
        var todos = GestorUsuarios.ObtenerTodosLosUsuarios();
        Assert.AreEqual(1, todos.Count);
    }

    [TestMethod]
    public void ModificarUsuario_CambiaDatosCorrectamente()
    {
        GestorUsuarios.CrearUsuario("Juan", "Perez", "123", "juan@mail.com", "1234");
        var usuario = GestorUsuarios.BuscarUsuario("Juan");
        GestorUsuarios.ModificarUsuario(usuario, nuevoNombre: "Juanito", nuevoCorreo: "juanito@mail.com");
        Assert.AreEqual("Juanito", usuario.Nombre);
        Assert.AreEqual("juanito@mail.com", usuario.Correo);
    }

    [TestMethod]
    public void SuspenderYRehabilitarUsuario_CambiaEstadoCorrectamente()
    {
        GestorUsuarios.CrearUsuario("Juan", "Perez", "123", "juan@mail.com", "1234");
        var usuario = GestorUsuarios.BuscarUsuario("Juan");
        GestorUsuarios.SuspenderUsuario(usuario);
        Assert.IsTrue(usuario.Suspendido);
        GestorUsuarios.RehabilitarUsuario(usuario);
        Assert.IsFalse(usuario.Suspendido);
    }

    [TestMethod]
    public void EliminarUsuario_UsuarioExistente()
    {
        GestorUsuarios.CrearUsuario("Juan", "Perez", "123", "juan@mail.com", "1234");
        var usuario = GestorUsuarios.BuscarUsuario("Juan");
        GestorUsuarios.EliminarUsuario(usuario);
        var todos = GestorUsuarios.ObtenerTodosLosUsuarios();
        Assert.AreEqual(0, todos.Count);
    }

    [TestMethod]
    public void AsignarClienteAOtroVendedor_ReasignaClienteCorrectamente()
    {
        // Crear vendedores
        GestorUsuarios.CrearUsuario("V1", "Perez", "111", "v1@mail.com", "123");
        GestorUsuarios.CrearUsuario("V2", "Lopez", "222", "v2@mail.com", "123");
        var vendedor1 = GestorUsuarios.BuscarUsuario("V1");
        var vendedor2 = GestorUsuarios.BuscarUsuario("V2");

        // Crear cliente y asignar al vendedor1
        Cliente cliente = new Cliente("Cliente", "Test", "999", "cliente@mail.com", DateTime.Now, vendedor1);
        vendedor1.ListaDeClientes.Add(cliente);

        // Reasignar
        GestorUsuarios.AsignarClienteAOtroVendedor(cliente, vendedor2);

        Assert.IsFalse(vendedor1.ListaDeClientes.Contains(cliente));
        Assert.IsTrue(vendedor2.ListaDeClientes.Contains(cliente));
        Assert.AreEqual(vendedor2, cliente.AsignadoA); // opcional si asignas este campo también
    }
}