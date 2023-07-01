using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Entidades;
using System.Xml;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        public void Guardar(string archivo, T datos)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, archivo);
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, datos);
                }
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error al momento de guardar XML", ex);
            }
        }

        public void Leer(string archivo, out T datos)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, archivo);
                using (StreamReader stream = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    datos = (T)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error al momento de leer XML", ex);
            }

            /*
            datos = default;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serial = new XmlSerializer(typeof(T));
                    //if (serial.CanDeserialize(reader)) {
                    datos = (T)serial.Deserialize(reader);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error al momento de leer XML", ex);
            }
            */
        }
    }
}
