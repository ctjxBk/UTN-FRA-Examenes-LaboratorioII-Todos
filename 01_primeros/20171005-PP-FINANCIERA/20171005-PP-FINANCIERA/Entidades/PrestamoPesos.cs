using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoPesos : Prestamo
    {
        private float porcentajeInteres;

        public float Interes
        {
            get { return this.CalcularInteres(); }
        }

        private float CalcularInteres()
        {
            return base.Monto * this.porcentajeInteres;
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            int diasPasados = (nuevoVencimiento - base.Vencimiento).Days;
            if(diasPasados > 0)
            {
                this.porcentajeInteres = this.porcentajeInteres * (1+((0.0025f * diasPasados))) ;
                base.Vencimiento = nuevoVencimiento;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Intereses: {this.CalcularInteres()}");            

            return sb.ToString();
        }

        public PrestamoPesos(float monto, DateTime vencimiento, float interes) 
            : base(monto, vencimiento)
        {
            this.porcentajeInteres = interes;
        }

        public PrestamoPesos(Prestamo prestamo, float porcetajeInteres)
            :this(prestamo.Monto, prestamo.Vencimiento ,porcetajeInteres)
        {
            
        }

        
    }
}
