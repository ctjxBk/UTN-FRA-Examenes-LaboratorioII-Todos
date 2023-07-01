using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    {
        public string diagnostico;
        public Paciente(string nombre, string apellido, DateTime nacimiento, string barrioResidencia)
            : base (nombre, apellido, nacimiento, barrioResidencia)
        { }

        public string Diagnostico
        {
            get
            {
                return this.diagnostico;
            }
            set
            {
                this.diagnostico = value;
            }
        }

        internal override string FichaExtra()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Recide en: " + base.barrioResidencia);
            sb.AppendLine(this.diagnostico);

            return sb.ToString();
        }
    }
}
