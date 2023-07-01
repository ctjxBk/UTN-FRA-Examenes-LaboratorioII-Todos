using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades
{

    public static class ClaseSerializadora<T>
    {
        public static void Guardar(T dato, string archivo)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, archivo);

                string extension = Path.GetExtension(path);
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    if (extension == ".json")
                    {
                        JsonSerializerOptions opciones = new JsonSerializerOptions();
                        opciones.WriteIndented = true;

                        string json = JsonSerializer.Serialize(dato, opciones);
                        stream.WriteLine(json);
                    }
                    else if(extension == ".xml")
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(stream, dato);
                    }
                    else
                    {
                        throw new Exception("No existe la extension");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar una serialización", ex);
            }
        }

        public static T Leer(string archivo)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, archivo);

                string extension = Path.GetExtension(path);
                using (StreamReader stream = new StreamReader(path))
                {
                    if (extension == ".json")
                    {
                        string json = stream.ReadToEnd();
                        return JsonSerializer.Deserialize<T>(json);
                    }
                    else if (extension == ".xml")
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        return (T)xmlSerializer.Deserialize(stream);
                    }
                    else
                    {
                        throw new Exception("No existe la extension");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer la serialización", ex);
            }
        }
    }
}
