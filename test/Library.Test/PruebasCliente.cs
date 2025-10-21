namespace Library.Test;

[TestClass]
public class ClienteTests
{
    [TestMethod]
    public void Constructor_CreaClienteCorrectamente()
    {
        var usuario = new Usuario("Juan", "Perez", "123", "correo@ejemplo.com", "pass");
        var fecha = new DateTime(2000, 1, 1);
        var cliente = new Cliente("Ana", "Lopez", "987654", "ana@mail.com", fecha, usuario);

        Assert.AreEqual("Ana", cliente.Nombre);
        Assert.AreEqual(fecha, cliente.FechaNacimiento);
        Assert.AreEqual(usuario, cliente.AsignadoA);
        Assert.AreEqual(0, cliente.ListaDeVentas.Count);
        Assert.AreEqual(0, cliente.ListaDeCotizaciones.Count);
        Assert.AreEqual(0, cliente.ListaDeInteracciones.Count);
    }

    [TestMethod]
    public void AñadirVenta_AgregaVentaCorrectamente()
    {
        var usuario = new Usuario("Juan", "Perez", "123", "correo@ejemplo.com", "pass");
        var cliente = new Cliente("Ana", "Lopez", "987654", "ana@mail.com", DateTime.Now, usuario);
        var venta = new Venta(500, "Laptop");

        cliente.AñadirVenta(venta);

        Assert.AreEqual(1, cliente.ListaDeVentas.Count);
        Assert.AreEqual(venta, cliente.ListaDeVentas[0]);
    }

    [TestMethod]
    public void AñadirCotizacion_AgregaCotizacionCorrectamente()
    {
        var usuario = new Usuario("Juan", "Perez", "123", "correo@ejemplo.com", "pass");
        var cliente = new Cliente("Ana", "Lopez", "987654", "ana@mail.com", DateTime.Now, usuario);
        var cotizacion = new Cotizacion("Laptop", 1000);

        cliente.AñadirCotizacion(cotizacion);

        Assert.AreEqual(1, cliente.ListaDeCotizaciones.Count);
        Assert.AreEqual(cotizacion, cliente.ListaDeCotizaciones[0]);
    }
}