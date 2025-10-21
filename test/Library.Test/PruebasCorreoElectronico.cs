namespace Library.Test;

[TestClass]
    public class CorreoElectronicoTests
    {
        private Usuario usuario;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario("Juan", "Perez", "12345678", "juan@example.com","1234");
            cliente = new Cliente("Ana", "Gomez", "87654321", "ana@example.com", new DateTime(2000,1,1), usuario);
        }

        [TestMethod]
        public void Constructor_UsuarioEsEmisor_Correcto()
        {
            // Arrange
            string contenido = "Contenido de prueba";
            bool usuarioEsEmisor = true;
            DateTime fechaEsperada = new DateTime(2025, 10, 20);

            // Act
            CorreoElectronico correo = new CorreoElectronico(usuario, cliente, usuarioEsEmisor, contenido, fechaEsperada);

            // Assert
            Assert.AreEqual(contenido, correo.Contenido);
            Assert.AreEqual(usuario.Correo, correo.DireccionEmisor);
            Assert.AreEqual(cliente.Correo, correo.DireccionReceptor);
            Assert.AreEqual(fechaEsperada, correo.Fecha);
        }

        [TestMethod]
        public void Constructor_ClienteEsEmisor_Correcto()
        {
            // Arrange
            string contenido = "Otro contenido";
            bool usuarioEsEmisor = false;
            DateTime fechaEsperada = new DateTime(2025, 10, 21);

            // Act
            CorreoElectronico correo = new CorreoElectronico(usuario, cliente, usuarioEsEmisor, contenido, fechaEsperada);

            // Assert
            Assert.AreEqual(contenido, correo.Contenido);
            Assert.AreEqual(cliente.Correo, correo.DireccionEmisor);
            Assert.AreEqual(usuario.Correo, correo.DireccionReceptor);
            Assert.AreEqual(fechaEsperada, correo.Fecha);
        }

        [TestMethod]
        public void MostrarDetalle_ImprimeInformacionCorrecta()
        {
            // Arrange
            string contenido = "Correo de prueba";
            CorreoElectronico correo = new CorreoElectronico(usuario, cliente, true, contenido);
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            correo.MostrarDetalle();
            string salida = sw.ToString();

            // Assert
            StringAssert.Contains(salida, usuario.Nombre);
            StringAssert.Contains(salida, cliente.Nombre);
            StringAssert.Contains(salida, usuario.Correo);
            StringAssert.Contains(salida, cliente.Correo);
            StringAssert.Contains(salida, contenido);
            StringAssert.Contains(salida, "sin nota"); // porque la nota está vacía por defecto
        }
    }