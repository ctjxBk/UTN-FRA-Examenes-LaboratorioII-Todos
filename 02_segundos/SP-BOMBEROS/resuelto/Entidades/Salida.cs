using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void FinDeSalida(int bomberoIndex);
    public class Salida 
    {
        private DateTime fechaFin;
        private DateTime fechaInicio;

        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }

        public double TiempoTotal
        {
            get
            {
                return this.fechaInicio.CalcularSegundos(FechaFin);
            }
        }

        public Salida()
        {
            this.FechaInicio= DateTime.Now;
        }

        public void FinalizarSalida()
        {
            this.FechaFin= DateTime.Now;
        }
    }
}
