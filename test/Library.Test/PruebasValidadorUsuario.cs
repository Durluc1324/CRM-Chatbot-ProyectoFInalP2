namespace Library.Test;

[TestClass]
public class ValidadorUsuariosTests
{
    [TestMethod]
    public void UsuarioActivo_UsuarioActivo_RetornaTrue()
    {
        // Arrange
        Usuario usuario = new Usuario("Luciano", "Rodriguez", "099999999", "luciano@crm.com", "2006");
        usuario.Rehabilitar();
        // Act
        bool resultado = ValidadorUsuarios.UsuarioActivo(usuario);

        // Assert
        Assert.IsTrue(resultado);
    }

    [TestMethod]
    public void UsuarioActivo_UsuarioSuspendido_RetornaFalse()
    {
        // Arrange
        Usuario usuario = new Usuario("Luciano", "Rodriguez", "099999999", "luciano@crm.com", "2006");
        usuario.Suspender();
        // Act
        bool resultado = ValidadorUsuarios.UsuarioActivo(usuario);

        // Assert
        Assert.IsFalse(resultado);
    }

    [TestMethod]
    public void UsuarioActivo_UsuarioNulo_RetornaFalse()
    {
        // Act
        bool resultado = ValidadorUsuarios.UsuarioActivo(null);

        // Assert
        Assert.IsFalse(resultado);
    }
}