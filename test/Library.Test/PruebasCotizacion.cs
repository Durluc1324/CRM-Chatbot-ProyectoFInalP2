namespace Library.Test;

    [TestClass]
    public class CotizacionTests
    {
        [TestMethod]
        public void Constructor_SinFecha_UsaFechaActual()
        {
            // Arrange
            string motivo = "Cotización de laptop";
            double precio = 1200;
            DateTime antes = DateTime.Now;

            // Act
            Cotizacion cot = new Cotizacion(motivo, precio);

            DateTime despues = DateTime.Now;

            // Assert
            Assert.AreEqual(motivo, cot.Motivo);
            Assert.AreEqual(precio, cot.Precio);
            Assert.IsTrue(cot.Fecha >= antes && cot.Fecha <= despues,
                "La fecha debe establecerse al momento actual cuando no se especifica.");
        }

        [TestMethod]
        public void Constructor_ConFecha_UsaFechaEspecificada()
        {
            // Arrange
            string motivo = "Cotización antigua";
            double precio = 1500;
            DateTime fechaEsperada = new DateTime(2025, 6, 4);

            // Act
            Cotizacion cot = new Cotizacion(motivo, precio, fechaEsperada);

            // Assert
            Assert.AreEqual(motivo, cot.Motivo);
            Assert.AreEqual(precio, cot.Precio);
            Assert.AreEqual(fechaEsperada, cot.Fecha);
        }

        [TestMethod]
        public void Propiedades_Modificables()
        {
            // Arrange
            Cotizacion cot = new Cotizacion("Inicial", 1000);
            string motivoEsperado = "Nueva Cotización";
            double precioEsperado = 1100;

            // Act
            cot.Motivo = motivoEsperado;
            cot.Precio = precioEsperado;

            // Assert
            Assert.AreEqual(motivoEsperado, cot.Motivo);
            Assert.AreEqual(precioEsperado, cot.Precio);
        }

        [TestMethod]
        public void MostrarCotizacion_ImprimeInformacionCorrecta()
        {
            // Arrange
            Cotizacion cot = new Cotizacion("Prueba", 2000, new DateTime(2025, 10, 20));
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            cot.MostrarCotización();
            string salida = sw.ToString();

            // Assert
            StringAssert.Contains(salida, "Prueba");
            StringAssert.Contains(salida, "2000");
            StringAssert.Contains(salida, "20/10/2025");
        }
    }
