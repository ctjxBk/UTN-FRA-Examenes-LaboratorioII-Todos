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
    public class GestorDeArchivos : IGuardar<Carrera>, IGuardar<AutoF1>
    {
        private string archivo;

        public GestorDeArchivos(string archivo)
        {
            this.archivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),archivo);
        }

        public void Guardar(Carrera carrera)
        {
            try
            {
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(this.archivo, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Carrera));
                    serializer.Serialize(stream, carrera);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al guardar una serializacion XML", ex);
            }
        }
        
        void IGuardar<AutoF1>.Guardar(AutoF1 item)
        {
            try
            {
                bool apenda = true;
                using (StreamWriter stream = new StreamWriter(this.archivo, apenda))
                {
                    stream.Write(item.ToString());
                }
                
                //throw new ArchivoException("Probando agarrar el error desde un hilo secundario");
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al guardar texto plano",ex);
            }
        }

        public Carrera LeerXML()
        {
            try
            {
                if (Path.GetExtension(this.archivo) == ".xml")
                {
                    using (StreamReader stream = new StreamReader(this.archivo))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Carrera));
                        Carrera carrera = xmlSerializer.Deserialize(stream) as Carrera;
                        return carrera;
                    }
                }
                else
                {
                    throw new ArchivoException("Error, la extensión del archivo no es XML");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error en la lectura del archivo XML", ex);
            }
        }
    }
}
