using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializador<T,V> : IMantenerDatos<T,V>
        where T : class, new()
        where V : class, new()
    {
        public void Guardar(T item, string path)
        {
            //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //string path = Path.Combine(ruta, "agustin-c.xml");

            try
            {
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, item);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al guardar en XML", ex);
            }
        }

        public V Leer(string path)
        {
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(V));
                    return (V)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al leer en XML", ex);
            }
        }


    }
}
