using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    // 19:15 - 19:45
    // 17:50 - 18:30 sin verificar si los intereses estan bien

    public enum PeriodicidadDePagos { Mensual, Bimestral, Trimestral }
    public enum TipoDePrestamo { Pesos, Dolares, Todos }

    public abstract class Prestamo
    {
        protected float monto;
        protected DateTime vencimiento;

        public float Monto { get => monto; }
        public DateTime Vencimiento 
        { 
            get => vencimiento;
            set
            {
                this.vencimiento = value > DateTime.Now ? value : DateTime.Now;
            } 
        }

        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

        public virtual string Mostrar()
        {
            return $"Vecimiento {this.vencimiento} - Monto: ${this.monto}";
        }


        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            return (p1.vencimiento - p2.vencimiento).Days;
        }

        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            this.Vencimiento = vencimiento;
        }
    }
}
