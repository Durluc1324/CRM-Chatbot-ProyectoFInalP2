namespace Library;

public static class GestorInteracciones
{
    public static void AgregarInteraccion(Cliente unCliente, Interaccion unaInteraccion)
    {
        unCliente.ListaDeInteracciones.Add(unaInteraccion);
    }

    public static void EliminarInteraccion(Cliente unCliente, Interaccion unaInteraccion)
    {
        if (unCliente.ListaDeInteracciones.Contains(unaInteraccion))
        {
            unCliente.ListaDeInteracciones.Remove(unaInteraccion);

        }
        else
        {
            Console.WriteLine("El cliente no tiene el cliente dado.");
        }
    }
    public static void AgregarNota(Interaccion interaccion, string nota)
    {
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
        // Se crea una lista temporal para almacenar las interacciones filtradas
        List<Interaccion> listaFiltrada = new List<Interaccion>();

        // Se recorren todas las interacciones del cliente
        foreach (Interaccion interaccion in cliente.ListaDeInteracciones)
        {
            bool coincideTipo = true;
            bool coincideFecha = true;

            // Si se especifica un tipo, se verifica si el nombre de la clase coincide
            if (!string.IsNullOrEmpty(tipo))
            {
                string nombreClase = interaccion.GetType().Name;
                coincideTipo = string.Equals(nombreClase, tipo, StringComparison.OrdinalIgnoreCase);
            }

            // Si se especifica una fecha, se verifica si coincide con la fecha de la interacción
            if (fecha.HasValue)
            {
                coincideFecha = interaccion.Fecha.Date == fecha.Value.Date;
            }

            // Si cumple con los filtros (tipo y/o fecha), se agrega a la lista filtrada
            if (coincideTipo && coincideFecha)
            {
                listaFiltrada.Add(interaccion);
            }
        }

        // Si no se encontraron interacciones
        if (listaFiltrada.Count == 0)
        {
            Console.WriteLine("No se encontraron interacciones con esos filtros.");
            return;
        }

        // Se muestran las interacciones filtradas
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

        // Se recorre cada cliente del usuario 

        foreach (Cliente cliente in usuario.ListaDeClientes )
        {
            List<Interaccion> pendientes = cliente.ListaDeInteracciones;
            //Si la interacción tiene respondido como falso, entonces se añade a la lista 
            //de interacciones no respondidas
            foreach (Interaccion interaccion in pendientes)
            {
                if (interaccion.Respondido == false)
                    interaccionesPendientes.Add(interaccion);
            }
        }
        return interaccionesPendientes;
    }
}