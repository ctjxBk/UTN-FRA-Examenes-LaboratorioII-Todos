using System;
using System.IO;
using System.Text.Json;

namespace BibliotecaDeClases
{
    public static class Serializador<T>
    {

        public static T Leer(string archivo, Action<string> mostrarElementos)
        {
            T datosRecuperados = default;

            try
            {
                if (!string.IsNullOrEmpty(archivo))
                {
                    datosRecuperados = JsonSerializer.Deserialize<T>(File.ReadAllText(archivo));
                    mostrarElementos("Documento deserializado con exito");
                }
                else
                {
                    throw new DirectoryNotFoundException("no encontrado");
                }

                return datosRecuperados;
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {archivo}", e);
            }
        }

    }
}
