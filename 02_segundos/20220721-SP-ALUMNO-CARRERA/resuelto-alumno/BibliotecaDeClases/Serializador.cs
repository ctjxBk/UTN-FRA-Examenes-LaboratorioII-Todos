using System;
using System.IO;
using System.Text.Json;

namespace BibliotecaDeClases
{
    public static class Serializador<T>
    {
        public static T Leer(string archivo, Action<string> mostrarElementos)
        {
            using (StreamReader stream = new StreamReader(archivo))
            {
                string json = stream.ReadToEnd();
                mostrarElementos("Documento serializado con éxito");
                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
