namespace Library.Test;

[TestClass]
public sealed class PruebasVenta
{
    [TestClass]
    public class VentaTests
    {
        [TestMethod]
        public void Constructor_SinFecha_UsaFechaActual()
        {
            // Arrange
            double precio = 500;
            string motivo = "Venta de laptop";
            DateTime antes = DateTime.Now;

            // Act
            Venta venta = new Venta(precio, motivo);

            DateTime despues = DateTime.Now;
            
            // Assert
            Assert.AreEqual(precio, venta.Precio);
            Assert.AreEqual(motivo, venta.Motivo);
            Assert.IsTrue(venta.Fecha >= antes && venta.Fecha <= despues,
                "La fecha debe establecerse al momento actual cuando no se especifica.");
        }

        [TestMethod]
        public void Constructor_ConFecha_UsaFechaEspecificada()
        {
            // Arrange
            double precio = 600;
            string motivo = "Venta antigua";
            DateTime fechaEsperada = new DateTime(2025, 6, 4);

            // Act
            Venta venta = new Venta(precio, motivo, fechaEsperada);

            // Assert
            Assert.AreEqual(precio, venta.Precio);
            Assert.AreEqual(motivo, venta.Motivo);
            Assert.AreEqual(fechaEsperada, venta.Fecha);
        }

        [TestMethod]
        public void Propiedades_Objeto_Modificables()
        {
            // Arrange
            Venta venta = new Venta(300, "Venta simple");
            string objetoEsperado = "Tablet";

            // Act
            venta.Objeto = objetoEsperado;

            // Assert
            Assert.AreEqual(objetoEsperado, venta.Objeto);
        }

        [TestMethod]
        public void MostrarVenta_ImprimeInformacionCorrecta()
        {
            // Arrange
            Venta venta = new Venta(800, "Venta test", new DateTime(2025, 10, 19));
            venta.Objeto = "Monitor";
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            venta.MostrarVenta();
            string salida = sw.ToString();

            // Assert
            StringAssert.Contains(salida, "Monitor");
            StringAssert.Contains(salida, "800");
            StringAssert.Contains(salida, "Venta test");
            StringAssert.Contains(salida, "19/10/2025");
        }
    }
}