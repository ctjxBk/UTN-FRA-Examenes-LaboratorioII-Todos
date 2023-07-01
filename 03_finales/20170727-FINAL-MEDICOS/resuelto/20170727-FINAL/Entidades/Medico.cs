using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Medico : Persona
    {
        private Paciente pacienteActual;
        protected static Random tiempoAleatorio;
        public delegate void FinAtencionPaciente(Paciente p, Medico m);
        public event FinAtencionPaciente AtencionFinalizada;

        //// Esta propiedad GETTER no la piden, pero es para solucionar un bug
        //// el cual se produce si se le pide atender 2 veces seguidas 
        //// al mismo medico sin antes finalizar la primera consulta
        public Paciente AtenderA
        {
            set
            {
                this.pacienteActual = value;
            }
            get { return this.pacienteActual; }
        }

        public virtual string EstaAtendidoA
        {
            get
            {
                return this.pacienteActual.ToString();
            }
        }

        protected abstract void Atender();

        protected void FinalizarAtencion()
        {
            this.AtencionFinalizada?.Invoke(this.pacienteActual, this);
            this.pacienteActual = null;
        }

        static Medico()
        {
            Medico.tiempoAleatorio = new Random();
        }


        public Medico(string nombre, string apellido) : base(nombre, apellido)
        {
        }




    }
}
