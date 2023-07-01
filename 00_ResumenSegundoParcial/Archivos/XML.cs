using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Entidades;

namespace Archivos
{

    //esto se pone en la clase padre
    //[XmlInclude(typeof(CLASE_HEREDADA))]

    //constructor sin parametros y propiedades publicas (GET y SET)
    public class XML
    {
        public void Guardar(Empleado empleado)
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.xml");

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Empleado));
                    serializer.Serialize(stream, empleado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar XML", ex);
            }
        }

        public Empleado Leer()
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.xml");

                using (StreamReader stream = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Empleado));
                    return xmlSerializer.Deserialize(stream) as Empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer XML", ex);
            }
        }
    }
}
