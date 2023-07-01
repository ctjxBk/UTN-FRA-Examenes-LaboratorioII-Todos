using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consulta
    {
        private DateTime fecha;
        private Paciente paciente;

        public Consulta()
        {
            //para xml
        }

        public Consulta(DateTime fecha, Paciente paciente)
        {
            this.fecha = fecha;
            this.paciente = paciente;
        }

        public Paciente Paciente
        {
            get
            {
                return this.paciente;
            }
            set
            {
                this.paciente = value;
            }
        }
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;  
            }
        }

        public override string ToString()
        {
            return this.Fecha.ToString() + " se ha atendido a " + this.Paciente.NombreCompleto;
        }
    }
}
