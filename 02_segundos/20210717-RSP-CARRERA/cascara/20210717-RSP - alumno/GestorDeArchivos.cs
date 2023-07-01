using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20210717_RSP___alumno
{
    public class GestorDeArchivos : IGuardar<Carrera>, IGuardar<AutoF1>
    {
        string archivo;

        public GestorDeArchivos(string ruta)
        {
            this.archivo = ruta;
        }

        public void Guardar(Carrera tipo)
        {
            using (XmlTextWriter xml = new XmlTextWriter(this.archivo, Encoding.UTF8) )
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer ser = new XmlSerializer(typeof(Carrera));
                    xml.Formatting = Formatting.Indented;
                    ser.Serialize(xml, tipo);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        void IGuardar<AutoF1>.Guardar(AutoF1 tipo)
        {
            using (StreamWriter escribir = new StreamWriter(this.archivo, true, Encoding.UTF8))
            {
                escribir.WriteLine(tipo.ToString());
            }
        }

        public Carrera LeerXML()
        {
            Carrera carrera = new Carrera();
            if (this.archivo.Contains(".xml"))
            {
                using (XmlTextReader xml = new XmlTextReader(this.archivo))
                {
                    try
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(Carrera));
                        carrera = ser.Deserialize(xml) as Carrera;

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            else 
            {
                throw new ArchivoException("Formato de archivo no permitido");
            }

            return carrera;
        }
    }
}
