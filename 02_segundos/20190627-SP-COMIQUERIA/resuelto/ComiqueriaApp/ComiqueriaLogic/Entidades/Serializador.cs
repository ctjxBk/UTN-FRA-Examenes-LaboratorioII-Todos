using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComiqueriaLogic
{
    public static class Serializador<T> where T : class, new()
    {
        //private static string ruta;
        //static Serializador()
        //{
        //    ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        //}

        public static void SerializarXML(T elemento, string path)
        {
            try
            {
                //string path = Path.Combine(ruta, "elemento.xml");
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, elemento);
                }
            }
            catch (ArgumentException)// ex)
            {
                //esto no pierda las pilas de llamadas ????
                throw;// new ComiqueriaException("Error al momento de SerializarXML (ArgumentException)", ex);
            }
            catch(DirectoryNotFoundException ex)
            {
                throw new ComiqueriaException("Error: Directorio no encontrado (DirectoryNotFoundException) sobre SerializarXML", ex);
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException("Error: ufff le pidiaste en el codigo al usar SerializarXML", ex);
            }
        }


        public static T DeserializarXML(string path)
        {
            try
            {
                //string path = Path.Combine(ruta, "elemento.xml");
                using (StreamReader stream = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                    return (T)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException("Error: ufff le pidiaste en el codigo al usar DeserializarXML", ex);
            }
        }



        public static void SerializarBinario(T elemento, string ruta)
        {
            throw new ComiqueriaException("pendiente", new Exception("No hay implementacion de SerializarBinario"));
        }
        public static void DeserializarBinario(T elemento, string ruta)
        {
            throw new ComiqueriaException("pendiente", new Exception("No hay implementacion de DeserializarBinario"));
        }
    }
}
