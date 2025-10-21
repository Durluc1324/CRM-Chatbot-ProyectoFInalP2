namespace Library.Test;

[TestClass]
public class UsuarioTests
{
    [TestMethod]
    public void Constructor_CreaUsuarioCorrectamente()
    {
        var usuario = new Usuario("Juan", "Perez", "123456", "correo@ejemplo.com", "pass123");
        
        Assert.AreEqual("Juan", usuario.Nombre);
        Assert.AreEqual("Perez", usuario.Apellido);
        Assert.AreEqual("123456", usuario.Telefono);
        Assert.AreEqual("correo@ejemplo.com", usuario.Correo);
        Assert.AreEqual("pass123", usuario.Contraseña);
        Assert.IsFalse(usuario.Suspendido);
        Assert.AreEqual(0, usuario.ListaDeClientes.Count);
    }

    [TestMethod]
    public void SuspenderYRehabilitar_CambiaEstadoCorrectamente()
    {
        var usuario = new Usuario("Ana", "Lopez", "987654", "ana@correo.com", "pass");
        usuario.Suspender();
        Assert.IsTrue(usuario.Suspendido);
        usuario.Rehabilitar();
        Assert.IsFalse(usuario.Suspendido);
    }
}