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
    public class Torneo:IEntradaSalida<bool>
    {
        public const int MAX_EQUIPOS_GRUPO = 4;

        private List<Grupo> grupos;
        private string nombre;

        public Torneo()
        {

        }

        public Torneo(string nombre)
        {
            this.grupos = new List<Grupo>();
            this.nombre = nombre;
        }

        public List<Grupo> Grupos { get => grupos; set => grupos = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public bool Guardar()
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                foreach (Grupo grupo in grupos)
                {
                    string path = Path.Combine(ruta, $"grupo-{grupo.GrupoLetra}.xml");
                    bool apenda = false;
                    using (StreamWriter stream = new StreamWriter(path, apenda))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Grupo));
                        serializer.Serialize(stream, grupo);
                        //XmlSerializer serializer = new XmlSerializer(typeof(Prueba));
                        //serializer.Serialize(stream, new Prueba);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new ExcepcionPersonalizada($"Error al guardar los grupos en formato XML - {ex.Message}");
            }
        }

        public bool Leer()
        {
            try
            {
                int cantidadInicial = this.grupos.Count;

                //primero todas las letras
                List<string> letras = new List<string>();
                foreach (string letra in Enum.GetNames(typeof(Letras)))
                {
                    letras.Add(letra);
                }

                //luego saco las letras que tengo , por ende me queda las que faltarían 
                foreach(Grupo grupo in this.grupos)
                {
                    letras.Remove(grupo.GrupoLetra.ToString());
                }

                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                foreach (string letra in letras)
                {
                    string path = Path.Combine(ruta, $"grupo-{letra}.xml");
                    if (File.Exists(path))
                    {
                        using (StreamReader stream = new StreamReader(path))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Grupo));
                            Grupo grupo = xmlSerializer.Deserialize(stream) as Grupo;
                            this.grupos.Add(grupo);
                        }
                    }
                }
                //retorno "true" si agregue almenos un grupo, caso contrario "false"
                return cantidadInicial != this.grupos.Count;

            }
            catch (Exception ex)
            {

                throw new ExcepcionPersonalizada($"Error al leer los grupos en formato XML - {ex.Message}");
            }
        }
    }

}
