using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializadora : IGuardar<Payaso>
    {

        public bool Guardar(Payaso item)
        {
            bool respuesta = false;
            try
            {
                string cartelJson = JsonSerializer.Serialize(item);
                File.WriteAllText(Payaso.rutaArchivo, cartelJson);

                if (File.Exists(Payaso.rutaArchivo))
                {
                    respuesta = true;
                }

                return respuesta;

            }
            catch (Exception)
            {
                throw new DatosException("Error al serializar en formato JSON");
            }
        }
    }
}
