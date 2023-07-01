using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreLibraries
{
    //14:40
    //16:13
    public static class JsonManager<T>// where T : Senador
    {
        private static string file;

        static JsonManager()
        {
            file = "votacion.json";
        }

        public static void Guardar(string file, T elemento)
        {
            JsonManager<T>.file = file;
            JsonManager<T>.Guardar(elemento);
        }

        public static void Guardar(T elemento)
        {
            try
            {
                //string ruta = AppDomain.CurrentDomain.BaseDirectory;
                ////string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                //string path = Path.Combine(ruta, "empleado.json");

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(file, apenda))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(elemento, opciones);
                    stream.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                throw new FilesException("Error al guardar JSON", ex);
            }
        }

        public static T Leer(string path) 
        {
            try
            {
                //string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                //string path = Path.Combine(ruta, "votacion.json");

                using (StreamReader stream = new StreamReader(path))
                {
                    string json = stream.ReadToEnd();
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer JSON", ex);
            }
        }

    }
}
