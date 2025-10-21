namespace Library;

public static class GestorInteracciones
{
    public static void AgregarInteraccion(Cliente unCliente, Interaccion unaInteraccion)
    {
        if (!ValidadorUsuarios.UsuarioActivo(unCliente.AsignadoA) || unCliente.AsignadoA.Suspendido)
        {
            Console.WriteLine("El usuario asignado está suspendido y no puede agregar interacciones.");
            return;
        }

        unCliente.ListaDeInteracciones.Add(unaInteraccion);
    }

    public static void EliminarInteraccion(Cliente unCliente, Interaccion unaInteraccion)
    {
        if (unCliente.AsignadoA.Suspendido)
        {
            Console.WriteLine("El usuario asignado está suspendido y no puede eliminar interacciones.");
            return;
        }

        if (unCliente.ListaDeInteracciones.Contains(unaInteraccion))
        {
            unCliente.ListaDeInteracciones.Remove(unaInteraccion);
        }
        else
        {
            Console.WriteLine("El cliente no tiene la interacción dada.");
        }
    }

    public static void AgregarNota(Interaccion interaccion, string nota)
    {
        if (interaccion.Usuario.Suspendido)
        {
            Console.WriteLine("El usuario asignado está suspendido y no puede agregar notas.");
            return;
        }

        if (string.IsNullOrWhiteSpace(nota))
        {
            Console.WriteLine("No se puede agregar una nota vacía.");
            return;
        }

        if (string.IsNullOrWhiteSpace(interaccion.Nota))
        {
            interaccion.Nota = nota;
            Console.WriteLine("Nota agregada correctamente.");
        }
        else
        {
            Console.WriteLine($"La interacción ya tiene una nota: \"{interaccion.Nota}\"");
            Console.Write("¿Desea reemplazarla con la nueva nota? (s/n): ");
            string respuesta = Console.ReadLine();

            if (respuesta?.ToLower() == "s")
            {
                interaccion.Nota = nota;
                Console.WriteLine("La nota fue reemplazada correctamente.");
            }
            else
            {
                Console.WriteLine("La nota anterior se mantuvo sin cambios.");
            }
        }
    }
    
    public static void MostrarInteracciones(Cliente cliente, string? tipo = null, DateTime? fecha = null)
    {
        List<Interaccion> listaFiltrada = new List<Interaccion>();

        foreach (Interaccion interaccion in cliente.ListaDeInteracciones)
        {
            bool coincideTipo = true;
            bool coincideFecha = true;

            if (!string.IsNullOrEmpty(tipo))
            {
                string nombreClase = interaccion.GetType().Name;
                coincideTipo = string.Equals(nombreClase, tipo, StringComparison.OrdinalIgnoreCase);
            }

            if (fecha.HasValue)
            {
                coincideFecha = interaccion.Fecha.Date == fecha.Value.Date;
            }

            if (coincideTipo && coincideFecha)
            {
                listaFiltrada.Add(interaccion);
            }
        }

        if (listaFiltrada.Count == 0)
        {
            Console.WriteLine("No se encontraron interacciones con esos filtros.");
            return;
        }

        Console.WriteLine($"\nInteracciones del cliente {cliente.Nombre} {cliente.Apellido}:");
        Console.WriteLine("────────────────────────────────────────────");

        foreach (Interaccion interaccion in listaFiltrada)
        {
            interaccion.MostrarDetalle();
            Console.WriteLine("────────────────────────────────────────────");
        }
    }
    
    public static List<Interaccion> ObtenerInteraccionesNoRespondidas(Usuario usuario)
    {
        List<Interaccion> interaccionesPendientes = new List<Interaccion>();
        
        foreach (Cliente cliente in usuario.ListaDeClientes )
        {
            List<Interaccion> pendientes = cliente.ListaDeInteracciones;
            
            foreach (Interaccion interaccion in pendientes)
            {
                if (interaccion.Respondido == false)
                    interaccionesPendientes.Add(interaccion);
            }
        }
        return interaccionesPendientes;
    }
}