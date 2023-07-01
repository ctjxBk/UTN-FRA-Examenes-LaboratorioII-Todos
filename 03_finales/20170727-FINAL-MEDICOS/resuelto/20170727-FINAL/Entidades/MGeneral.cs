using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class MGeneral : Medico, IMedico
    {
        public MGeneral(string nombre, string apellido) : base(nombre, apellido)
        {
        }

        public void IniciarAtencion(Paciente p)
        {
            Task.Run(() => {
                this.AtenderA = p;
                this.Atender();
            });
        }

        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(1500, 2201));
            this.FinalizarAtencion();
        }
    }
}
