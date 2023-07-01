using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesRSP
{
    public static class Serializador
    {
        private static string path;
        static  Serializador()
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            path = Path.Combine(ruta, "agustin.c.alumnos.xml");
        }
        public static bool Guardar(List<Alumno> lista)
        {
            try
            {
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Alumno>));
                    serializer.Serialize(stream, lista);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al serializar XML", ex);
            }
        }

        public static List<Alumno> Leer()
        {


            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Alumno>));
                    return  xmlSerializer.Deserialize(stream) as List<Alumno>;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al deserializar XML", ex);
            }

        }


    }
}
