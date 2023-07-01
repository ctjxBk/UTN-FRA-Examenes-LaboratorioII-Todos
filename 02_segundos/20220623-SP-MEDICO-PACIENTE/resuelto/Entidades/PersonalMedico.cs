using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class PersonalMedico : Persona
    {
        private List<Consulta> consultas;
        private bool esResidente;

        public List<Consulta> Consultas { get => consultas; set => consultas = value; }
        public bool EsResidente { get => esResidente; set => esResidente = value; }

        public PersonalMedico()
        {
            //para xml
        }

        public PersonalMedico(string nombre, string apellido, DateTime nacimiento, bool esRecidente)
            : base(nombre, apellido, nacimiento)
        {
            this.esResidente = esRecidente;
            this.consultas = new List<Consulta>();
        }

        internal override string FichaExtra()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("¿Finalizó residencia?" + (this.esResidente?"NO":"SI"));

            sb.AppendLine("ATENCIONES:");
            foreach (Consulta consulta in consultas)
            {
                sb.Append(Persona.FichaPersonal(consulta.Paciente));
            }


            return sb.ToString();
        }

        public static Consulta operator +(PersonalMedico doctor, Paciente paciente)
        {
            Consulta c = new Consulta(DateTime.Now, paciente);
            doctor.consultas.Add(c);
            return c;
        }

        public static void exportarXML(PersonalMedico medico)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "agustin-c.xml");

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(PersonalMedico));
                    serializer.Serialize(stream, medico);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al exportar un XML", ex);
            }
        }
    }
}
