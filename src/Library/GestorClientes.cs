using System.ComponentModel.Design;

namespace Library;

public class GestorClientes
{
    public static void CrearCliente(string unNombre, string unApellido, string unTelefono, string unCorreo, DateTime unaFecha,
        Usuario usuario)
    {
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
        else
        {
            Cliente cliente = new Cliente(unNombre, unApellido, unTelefono, unCorreo, unaFecha, usuario);
            usuario.ListaDeClientes.Add(cliente);
        }

    }

    public static void ModificarCliente(Cliente cliente, string? unNombre = null,
        string? unApellido = null, string? unTelefono = null,
        string? unCorreo = null, DateTime? unaFecha = null)
    {
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

    public static void AñadirVenta(Venta unaVenta, Cliente unCliente)
    {
        
    }

    public static void AñadirCotizacion()
    {

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

    public static List<Venta> ObtenerVentasPorPeriodo(DateTime inicio, DateTime fin)
    {
        
    }

    public static List<Cotizacion> ObtenerCotizacionesPorPeriodo(DateTime inicio, DateTime fin)
    {
        
    }

    public static void AsignarClienteAOtroVendedor(Cliente cliente, Usuario vendedorNuevo)
    {
        
    }

}