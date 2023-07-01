using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public class Serializadora : IGuardar<Payaso>
    {
        public bool IGuardar(Payaso item)
        {
            if(item is null)
            {
                throw new DatosException("El payaso a serializar es NULL");
            }

            try
            {
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;

                // Serializo un objeto de tipo Payaso a formato JSON. 
                string jsonString = JsonSerializer.Serialize(item, opciones);

                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(escritorio, "payaso.json");
                // Guardo el JSON desde un archivo.
                File.WriteAllText(path, jsonString);

                return File.Exists(path);
            }
            catch (Exception ex)
            {
                throw new DatosException("Error al intentar serializar en json");    
            }

            
        }
    }
}
