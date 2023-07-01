using System;
using System.IO;
using System.Text.Json;

namespace BibliotecaDeClases
{


    // DESARROLLAR
    public static class Serializador<T>// where T : Empleado, new()
    {
        public static void Escribir(T datos, string ruta, string nombreArchivo, Action<string> mostrarElementos)
        {
            try
            {
                string rutaCompleta = Path.Combine(ruta, nombreArchivo);

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(rutaCompleta, apenda))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(datos, opciones);
                    stream.WriteLine(json);
                    mostrarElementos?.Invoke("El empleado ha sido serializado correctamente");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar JSON", ex);
            }
        }
      
    }
}
