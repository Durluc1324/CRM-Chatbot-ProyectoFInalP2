namespace Library.Test;

[TestClass]
public class AdministradorTests
{
    [TestMethod]
    public void Constructor_CreaAdministradorCorrectamente()
    {
        Administrador admin = new Administrador("Luciano", "Rodriguez", "123", "luciano@mail.com", "pass123");
        Assert.AreEqual("Luciano", admin.Nombre);
        Assert.AreEqual("Rodriguez", admin.Apellido);
    }

    [TestMethod]
    public void MostrarPanelUsuario_ImprimeDatosCorrectamente()
    {
        Administrador admin = new Administrador("Luciano", "Rodriguez", "123", "luciano@mail.com", "pass123");
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        admin.MostrarPanelUsuario();
        string salida = sw.ToString();

        StringAssert.Contains(salida, "ADMINISTRADOR");
        StringAssert.Contains(salida, "Luciano Rodriguez");
        StringAssert.Contains(salida, "luciano@mail.com");
    }
    
    [TestMethod]
    public void CrearAdministrador_CreaCorrectamente()
    {
        // Arrange
        string nombre = "Admin";
        string apellido = "Prueba";
        string telefono = "12345678";
        string correo = "admin@correo.com";
        string contraseña = "pass123";

        // Act
        GestorUsuarios.CrearAdministrador(nombre, apellido, telefono, correo, contraseña);
        List<Administrador> listaAdmins = GestorUsuarios.ObtenerAdministradores();

        // Assert
        Assert.AreEqual(1, listaAdmins.Count);
        Assert.AreEqual(nombre, listaAdmins[0].Nombre);
        Assert.AreEqual(apellido, listaAdmins[0].Apellido);
        Assert.AreEqual(telefono, listaAdmins[0].Telefono);
        Assert.AreEqual(correo, listaAdmins[0].Correo);
    }

    [TestMethod]
    public void CrearAdministrador_NoCreaDuplicado()
    {
        // Arrange
        string nombre = "Admin2";
        string apellido = "Prueba2";
        string telefono = "87654321";
        string correo = "admin2@correo.com";
        string contraseña = "pass456";

        // Crear primero
        GestorUsuarios.CrearAdministrador(nombre, apellido, telefono, correo, contraseña);

        // Act - intentar crear duplicado
        GestorUsuarios.CrearAdministrador(nombre, apellido, telefono, correo, contraseña);
        List<Administrador> listaAdmins = GestorUsuarios.ObtenerAdministradores();
        
        Assert.AreEqual(2, listaAdmins.Count);
    }
}
