using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class MEspecialista : Medico, IMedico
    {
        public enum Especialidad { Traumatologo, Odontologo};
        private Especialidad especialidad;
        public MEspecialista(string nombre, string apellido, Especialidad e) : base(nombre, apellido)
        {
            this.especialidad = e;
        }

        public void IniciarAtencion(Paciente p)
        {
            Task.Run(() => {
                this.AtenderA = p;
                this.Atender();
            });
            //Task.Run(this.Atender);
        }

        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(5000, 10001));
            this.FinalizarAtencion();
        }
    }
}
