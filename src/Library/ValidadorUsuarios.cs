namespace Library;

public static class ValidadorUsuarios
    {
        public static bool UsuarioActivo(Usuario usuario)
        {
            if (usuario == null)
            {
                Console.WriteLine("El usuario es nulo.");
                return false;
            }

            if (usuario.Suspendido)
            {
                Console.WriteLine($"El usuario {usuario.Nombre} {usuario.Apellido} está suspendido y no puede realizar esta acción.");
                return false;
            }

            return true;
        }
    }
