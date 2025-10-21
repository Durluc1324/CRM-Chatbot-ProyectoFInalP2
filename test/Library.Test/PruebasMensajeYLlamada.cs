namespace Library.Test;

[TestClass]
    public class InteraccionTelefonicaTests
    {
        private Usuario usuario;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario("Luciano", "Rodríguez", "luciano@crm.com", "099999999","1234");
            cliente = new Cliente("Tom", "Morales", "tom@cliente.com", "098888888", new DateTime(2005,4,18), usuario);
        }

        // ───────────────────────────────
        // PRUEBAS DE MENSAJE
        // ───────────────────────────────
        [TestMethod]
        public void Mensaje_DeUsuarioACliente_AsignacionCorrecta()
        {
            var mensaje = new Mensaje(usuario, cliente, true, "Hola Tom!");

            Assert.AreEqual(usuario.Telefono, mensaje.NumeroEmisor);
            Assert.AreEqual(cliente.Telefono, mensaje.NumeroReceptor);
            Assert.AreEqual("Hola Tom!", mensaje.Texto);
        }

        [TestMethod]
        public void Mensaje_DeClienteAUsuario_AsignacionCorrecta()
        {
            var mensaje = new Mensaje(usuario, cliente, false, "Hola Luciano");

            Assert.AreEqual(cliente.Telefono, mensaje.NumeroEmisor);
            Assert.AreEqual(usuario.Telefono, mensaje.NumeroReceptor);
        }

        [TestMethod]
        public void Mensaje_PropiedadesInicialesPorDefecto_Correctas()
        {
            var mensaje = new Mensaje(usuario, cliente, true, "Probando");

            Assert.IsFalse(mensaje.Respondido);
            Assert.IsNull(mensaje.Nota);
            Assert.IsNotNull(mensaje.Fecha);
        }

        // ───────────────────────────────
        // PRUEBAS DE LLAMADA
        // ───────────────────────────────
        [TestMethod]
        public void Llamada_DeUsuarioACliente_AsignacionCorrecta()
        {
            var llamada = new Llamada(usuario, cliente, true, usuario.Telefono, cliente.Telefono, 120);

            Assert.AreEqual(usuario.Telefono, llamada.NumeroEmisor);
            Assert.AreEqual(cliente.Telefono, llamada.NumeroReceptor);
            Assert.AreEqual(120, llamada.DuracionSegundos);
        }

        [TestMethod]
        public void Llamada_DeClienteAUsuario_AsignacionCorrecta()
        {
            var llamada = new Llamada(usuario, cliente, false, cliente.Telefono, usuario.Telefono, 45);

            Assert.AreEqual(cliente.Telefono, llamada.NumeroEmisor);
            Assert.AreEqual(usuario.Telefono, llamada.NumeroReceptor);
        }

        [TestMethod]
        public void Llamada_PropiedadesInicialesPorDefecto_Correctas()
        {
            var llamada = new Llamada(usuario, cliente, true, usuario.Telefono, cliente.Telefono, 30);

            Assert.IsFalse(llamada.Respondido);
            Assert.IsNull(llamada.Nota);
            Assert.IsNotNull(llamada.Fecha);
        }
    }