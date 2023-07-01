using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonalMedico : Persona
    {
        private List<Consulta> consultas;
        private bool esResidente;
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
    }
}
