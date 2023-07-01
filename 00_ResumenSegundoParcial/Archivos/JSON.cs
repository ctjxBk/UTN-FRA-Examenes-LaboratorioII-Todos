using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entidades;

namespace Archivos
{
    //sobre el atributo o propiedad publica
    //[System.Text.Json.Serialization.JsonIgnore]

    //siempre propiedades publicas, no atributos para serializar (GET y SET)
    public class JSON
    {
        public void Guardar(Empleado empleado)
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.json");

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(empleado, opciones);
                    stream.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar JSON", ex);
            }
        }

        public Empleado Leer()
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.json");

                using (StreamReader stream = new StreamReader(path))
                {
                    string json = stream.ReadToEnd();
                    return JsonSerializer.Deserialize<Empleado>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer JSON", ex);
            }
        }
    }
}
