using System.ComponentModel.Design;

namespace Library;

public static class GestorClientes
{
    public static void CrearCliente(string unNombre, string unApellido, string unTelefono, string unCorreo,
        DateTime unaFecha, Usuario usuario)
    {
        if (usuario == null)
        {
            Console.WriteLine("El usuario no puede ser nulo.");
            return;
        }

        if (usuario.Suspendido)
        {
            Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} está suspendido y no puede crear clientes.");
            return;
        }

        if (usuario.ListaDeClientes.Any(c => c.Correo == unCorreo))
        {
            Console.WriteLine("Ya existe un cliente con ese correo.");
            return;
        }
        else if (usuario.ListaDeClientes.Any(c => c.Telefono == unTelefono))
        {
            Console.WriteLine("Ya existe un cliente con ese teléfono.");
            return;
        }

        Cliente cliente = new Cliente(unNombre, unApellido, unTelefono, unCorreo, unaFecha, usuario);
        usuario.ListaDeClientes.Add(cliente);
        Console.WriteLine($"Cliente {cliente.Nombre} {cliente.Apellido} creado correctamente.");
    }
    public static void ModificarCliente(Cliente cliente, string? unNombre = null,
        string? unApellido = null, string? unTelefono = null,
        string? unCorreo = null, DateTime? unaFecha = null)
    {
        if (cliente == null)
        {
            Console.WriteLine("El cliente no puede ser nulo.");
            return;
        }

        if (cliente.AsignadoA != null && cliente.AsignadoA.Suspendido)
        {
            Console.WriteLine($"El usuario {cliente.AsignadoA.Nombre} {cliente.AsignadoA.Apellido} está suspendido y no puede modificar clientes.");
            return;
        }
        
        if (unNombre != null)
            cliente.Nombre = unNombre;

        if (unApellido != null)
            cliente.Apellido = unApellido;

        if (unTelefono != null)
            cliente.Telefono = unTelefono;

        if (unCorreo != null)
            cliente.Correo = unCorreo;

        if (unaFecha.HasValue)
            cliente.FechaNacimiento = unaFecha.Value;

        Console.WriteLine($"El cliente {cliente.Nombre} {cliente.Apellido} fue modificado correctamente.");
    }

    public static void EliminarCliente(Cliente unCLiente, Usuario usuario)
    {
        if (usuario == null || unCLiente == null)
        {
            Console.WriteLine("Error: el usuario o el cliente son nulos");
        }
        else if (usuario.ListaDeClientes.Contains(unCLiente))
        {
            usuario.ListaDeClientes.Remove(unCLiente);
        }
        else
        {
            Console.WriteLine("El usuario no tiene el cliente dado");
        }
    }

    public static Cliente BuscarCliente(string criterio, Usuario usuario)
    {
        // Verificación básica
        if (usuario == null || usuario.ListaDeClientes == null)
        {
            Console.WriteLine("Error: el usuario o su lista de clientes es nula.");
            return null;
        }

        foreach (Cliente cliente in usuario.ListaDeClientes)
        {
            if (cliente.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                cliente.Apellido.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                cliente.Telefono.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                cliente.Correo.Contains(criterio, StringComparison.OrdinalIgnoreCase))
            {
                return cliente;
            }
        }

        Console.WriteLine("No hay cliente que contenga el valor dado.");
        return null;
    }

    public static void AñadirVenta(Venta unaVenta, Cliente unCliente, Usuario usuario)
        {
            if (usuario.Suspendido)
            {
                Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} está suspendido y no puede añadir ventas.");
                return;
            }
            
            if (usuario.ListaDeClientes.Contains(unCliente))
            {
                unCliente.AñadirVenta(unaVenta);
            }
            else
            {
                Console.WriteLine("El cliente no pertenece al usuario actual.");
            }
        }
    
    public static void AñadirCotizacion(Cotizacion unaCotizacion, Cliente unCliente, Usuario usuario)
        {
            if (usuario.Suspendido)
            {
                Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} está suspendido y no puede añadir cotizaciones.");
                return;
            }
            if (usuario.ListaDeClientes.Contains(unCliente))
            {
                unCliente.AñadirCotizacion(unaCotizacion);
            }
            else
            {
                Console.WriteLine("El cliente no pertenece al usuario actual.");
            }
        }

    public static List<Venta> ObtenerVentasPorPeriodo(DateTime inicio, DateTime fin, Cliente cliente)
        {
            List<Venta> ventasEnPeriodo = new List<Venta>();
            foreach (Venta venta in cliente.ListaDeVentas)
            {
                if (venta.Fecha >= inicio && venta.Fecha <= fin)
                {
                    ventasEnPeriodo.Add(venta);
                }
            }

            if (ventasEnPeriodo.Count == 0)
            {
                Console.WriteLine("No hay ninguna venta en el periodo dado");
            }

            return ventasEnPeriodo;

        }

    public static List<Cotizacion> ObtenerCotizacionesPorPeriodo(DateTime inicio, DateTime fin, Cliente cliente)
        {
            List<Cotizacion> cotizacionEnPeriodo = new List<Cotizacion>();
            foreach (Cotizacion cotizacion in cliente.ListaDeCotizaciones)
            {
                if (cotizacion.Fecha >= inicio && cotizacion.Fecha <= fin)
                    cotizacionEnPeriodo.Add(cotizacion);
            }

            if (cotizacionEnPeriodo.Count == 0)
                Console.WriteLine("No hay ninguna cotización en el periodo dado");
            return cotizacionEnPeriodo;
        }

    public static void AsignarClienteAOtroVendedor(Cliente cliente, Usuario vendedorActual, Usuario vendedorNuevo)
    {
        if (vendedorActual == null || vendedorNuevo == null || cliente == null)
        {
            Console.WriteLine("Error: vendedor o cliente nulo.");
            return;
        }

        if (vendedorActual.Suspendido)
        {
            Console.WriteLine($"El vendedor actual {vendedorActual.Nombre} está suspendido y no puede reasignar clientes.");
            return;
        }

        if (vendedorNuevo.Suspendido)
        {
            Console.WriteLine($"El nuevo vendedor {vendedorNuevo.Nombre} está suspendido y no puede recibir clientes.");
            return;
        }

        if (vendedorActual.ListaDeClientes.Contains(cliente))
        {
            vendedorActual.ListaDeClientes.Remove(cliente);
            vendedorNuevo.ListaDeClientes.Add(cliente);

            Console.WriteLine(
                $"El cliente {cliente.Nombre} {cliente.Apellido} fue asignado correctamente a {vendedorNuevo.Nombre} {vendedorNuevo.Apellido}.");
        }
        else
        {
            Console.WriteLine(
                $"El cliente {cliente.Nombre} {cliente.Apellido} no pertenece al vendedor {vendedorActual.Nombre} {vendedorActual.Apellido}.");
        }
    }
}