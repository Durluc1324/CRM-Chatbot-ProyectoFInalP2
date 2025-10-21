namespace Library.Test;

 [TestClass]
    public class ReunionTests
    {
        private Usuario usuario;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario("Marcos", "Lopez", "12345678", "marcos@example.com", "1234");
            cliente = new Cliente("Julia", "Fernandez", "87654321", "julia@example.com", new DateTime(1999, 5, 12), usuario);
        }

        [TestMethod]
        public void Constructor_ConLugarValido_AsignaCorrectamente()
        {
            // Arrange
            string lugarEsperado = "Oficina Central";
            DateTime fechaEsperada = new DateTime(2025, 10, 20);

            // Act
            Reunion reunion = new Reunion(usuario, cliente, lugarEsperado, fechaEsperada);

            // Assert
            Assert.AreEqual(lugarEsperado, reunion.Lugar);
            Assert.AreEqual(fechaEsperada, reunion.Fecha);
            Assert.AreEqual(usuario, reunion.Usuario);
            Assert.AreEqual(cliente, reunion.Cliente);
        }

        [TestMethod]
        public void Constructor_LugarVacio_AsignaSinEspecificar()
        {
            // Arrange
            string lugarVacio = " ";
            
            // Act
            Reunion reunion = new Reunion(usuario, cliente, lugarVacio);

            // Assert
            Assert.AreEqual("Sin especificar", reunion.Lugar);
        }

        [TestMethod]
        public void MostrarDetalle_ImprimeInformacionCorrecta()
        {
            // Arrange
            string lugar = "Café del Centro";
            Reunion reunion = new Reunion(usuario, cliente, lugar, new DateTime(2025, 10, 20));
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            reunion.MostrarDetalle();
            string salida = sw.ToString();

            // Assert
            StringAssert.Contains(salida, "REUNIÓN");
            StringAssert.Contains(salida, usuario.Nombre);
            StringAssert.Contains(salida, cliente.Nombre);
            StringAssert.Contains(salida, lugar);
            StringAssert.Contains(salida, "sin nota");
            StringAssert.Contains(salida, "No"); // Respondido = false por defecto
        }
    }