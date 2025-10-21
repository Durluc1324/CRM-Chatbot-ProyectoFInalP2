namespace Library.Test;

public class GestorClientesTests
{
    private Usuario usuario;

    [TestInitialize]
    public void Setup()
    {
        usuario = new Usuario("Juan", "Perez", "123", "juan@mail.com", "1234");
    }

    [TestMethod]
    public void CrearCliente_AgregaClienteCorrectamente()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Assert.AreEqual(1, usuario.ListaDeClientes.Count);
        Assert.AreEqual("Ana", usuario.ListaDeClientes[0].Nombre);
    }

    [TestMethod]
    public void CrearCliente_NoPermiteCorreoDuplicado()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        GestorClientes.CrearCliente("Pedro", "Gomez", "888", "ana@mail.com", DateTime.Now, usuario); // mismo correo
        Assert.AreEqual(1, usuario.ListaDeClientes.Count);
    }

    [TestMethod]
    public void CrearCliente_NoPermiteTelefonoDuplicado()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        GestorClientes.CrearCliente("Pedro", "Gomez", "999", "pedro@mail.com", DateTime.Now, usuario); // mismo teléfono
        Assert.AreEqual(1, usuario.ListaDeClientes.Count);
    }

    [TestMethod]
    public void ModificarCliente_CambiaDatosCorrectamente()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Cliente cliente = usuario.ListaDeClientes[0];
        GestorClientes.ModificarCliente(cliente, unNombre: "Ana Maria", unCorreo: "ana.maria@mail.com");
        Assert.AreEqual("Ana Maria", cliente.Nombre);
        Assert.AreEqual("ana.maria@mail.com", cliente.Correo);
    }

    [TestMethod]
    public void EliminarCliente_RemueveClienteDeLista()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Cliente cliente = usuario.ListaDeClientes[0];
        GestorClientes.EliminarCliente(cliente, usuario);
        Assert.AreEqual(0, usuario.ListaDeClientes.Count);
    }

    [TestMethod]
    public void AñadirVenta_AgregaVentaAlCliente()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Cliente cliente = usuario.ListaDeClientes[0];
        Venta venta = new Venta(500, "Producto");
        GestorClientes.AñadirVenta(venta, cliente, usuario);
        Assert.AreEqual(1, cliente.ListaDeVentas.Count);
        Assert.AreEqual(500, cliente.ListaDeVentas[0].Precio);
    }

    [TestMethod]
    public void AñadirCotizacion_AgregaCotizacionAlCliente()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Cliente cliente = usuario.ListaDeClientes[0];
        Cotizacion cot = new Cotizacion("Producto", 300);
        GestorClientes.AñadirCotizacion(cot, cliente, usuario);
        Assert.AreEqual(1, cliente.ListaDeCotizaciones.Count);
        Assert.AreEqual(300, cliente.ListaDeCotizaciones[0].Precio);
    }

    [TestMethod]
    public void ObtenerVentasPorPeriodo_FiltraCorrectamente()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Cliente cliente = usuario.ListaDeClientes[0];

        Venta v1 = new Venta(100, "Producto1", new DateTime(2025, 1, 1));
        Venta v2 = new Venta(200, "Producto2", new DateTime(2025, 2, 1));
        cliente.ListaDeVentas.Add(v1);
        cliente.ListaDeVentas.Add(v2);

        var filtradas = GestorClientes.ObtenerVentasPorPeriodo(new DateTime(2025, 1, 1), new DateTime(2025, 1, 31), cliente);
        Assert.AreEqual(1, filtradas.Count);
        Assert.AreEqual(v1, filtradas[0]);
    }

    [TestMethod]
    public void ObtenerCotizacionesPorPeriodo_FiltraCorrectamente()
    {
        GestorClientes.CrearCliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, usuario);
        Cliente cliente = usuario.ListaDeClientes[0];

        Cotizacion c1 = new Cotizacion("Prod1", 100, new DateTime(2025, 1, 1));
        Cotizacion c2 = new Cotizacion("Prod2", 200, new DateTime(2025, 2, 1));
        cliente.ListaDeCotizaciones.Add(c1);
        cliente.ListaDeCotizaciones.Add(c2);

        var filtradas = GestorClientes.ObtenerCotizacionesPorPeriodo(new DateTime(2025, 1, 1), new DateTime(2025, 1, 31), cliente);
        Assert.AreEqual(1, filtradas.Count);
        Assert.AreEqual(c1, filtradas[0]);
    }

    [TestMethod]
    public void AsignarClienteAOtroVendedor_ReasignaClienteCorrectamente()
    {
        Usuario vendedor1 = new Usuario("V1", "Perez", "111", "v1@mail.com", "123");
        Usuario vendedor2 = new Usuario("V2", "Lopez", "222", "v2@mail.com", "123");
        Cliente cliente = new Cliente("Ana", "Lopez", "999", "ana@mail.com", DateTime.Now, vendedor1);
        vendedor1.ListaDeClientes.Add(cliente);

        GestorClientes.AsignarClienteAOtroVendedor(cliente, vendedor1, vendedor2);

        Assert.IsFalse(vendedor1.ListaDeClientes.Contains(cliente));
        Assert.IsTrue(vendedor2.ListaDeClientes.Contains(cliente));
    }
}