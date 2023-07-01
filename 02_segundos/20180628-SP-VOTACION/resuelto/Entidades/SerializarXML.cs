using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{
    public class SerializarXML<T>: IArchivos<T>
    {
        public bool Guardar(string rutaArchivo, T objecto)
        {
            try
            {
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(rutaArchivo, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, objecto);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException($"Error al guardar en XML",ex);
            }

        }

        public T Leer(string rutaArchivo)
        {
            try
            {
                using (StreamReader stream = new StreamReader(rutaArchivo))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException($"Error al Leer en XML",ex);
            }
        }
    }
}
