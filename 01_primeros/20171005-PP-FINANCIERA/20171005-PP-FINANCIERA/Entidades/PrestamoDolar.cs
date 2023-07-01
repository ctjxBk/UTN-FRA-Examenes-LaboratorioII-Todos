using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoDolar : Prestamo
    {
        private PeriodicidadDePagos periodicidad;

        public float Interes
        {
            get { return this.CalcularInteres(); }
        }

        public PeriodicidadDePagos Periodicidad
        {
            get { return this.periodicidad; }
        }

        private float CalcularInteres()
        {
            switch (this.periodicidad)
            {
                case PeriodicidadDePagos.Mensual:
                    return 0.25f * this.monto;
                case PeriodicidadDePagos.Bimestral:
                    return 0.35f * this.monto;
                case PeriodicidadDePagos.Trimestral:
                    return 0.40f * this.monto ;
                default:
                    return 0;
            }
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            int diasPasados = (nuevoVencimiento - base.Vencimiento).Days;
            if (diasPasados > 0)
            {
                this.monto = this.monto + 2.5f * diasPasados;
                base.Vencimiento = nuevoVencimiento;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Intereses: {this.CalcularInteres()}");
            sb.AppendLine($"Periodo: {this.Periodicidad}");

            return sb.ToString();
        }

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad)
            : base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo prestamo, PeriodicidadDePagos periodicidad)
            : this (prestamo.Monto, prestamo.Vencimiento, periodicidad)
        {
            
        }


    }
}
