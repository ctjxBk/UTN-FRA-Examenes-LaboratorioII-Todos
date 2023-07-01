using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestamosPersonales;

namespace EntidadFinanciera
{
    public class Financiera
    {
        private List<Prestamo> listaDePrestamos;
        private string razonSocial;

        public float InteresesEnDolar
        {
            get { return this.CalcularInteresGanado(TipoDePrestamo.Dolares); }
        }

        public float InteresesEnPesos
        {
            get { return this.CalcularInteresGanado(TipoDePrestamo.Pesos); }
        }

        public float InteresesTotales
        {
            get { return this.CalcularInteresGanado(TipoDePrestamo.Todos); }
        }

        public List<Prestamo> ListaDePrestamos
        {
            get { return this.listaDePrestamos; }
        }

        public string RazonSocial
        {
            get { return this.razonSocial;}
        }

        private float CalcularInteresGanado(TipoDePrestamo tipoPrestamo)
        {
            float prestamos = 0;
            
            foreach (Prestamo prestamo in this.ListaDePrestamos)
            {
                if(prestamo is PrestamoPesos 
                    && ((tipoPrestamo == TipoDePrestamo.Pesos)
                    || tipoPrestamo == TipoDePrestamo.Todos))
                {
                    prestamos += ((PrestamoPesos)prestamo).Interes;
                }
                if (prestamo is PrestamoDolar
                    && ((tipoPrestamo == TipoDePrestamo.Dolares)
                    || tipoPrestamo == TipoDePrestamo.Todos))
                {
                    prestamos += ((PrestamoDolar)prestamo).Interes;
                }
            }
            
            return prestamos;
        }

        public static explicit operator string(Financiera financiera)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(financiera.RazonSocial);
            sb.AppendLine($"Intereses totales: {financiera.InteresesTotales}");
            sb.AppendLine($"Intereses en pesos: {financiera.InteresesEnPesos}");
            sb.AppendLine($"Intereses en dólares: {financiera.InteresesEnDolar}");
            financiera.OrdenarPrestamos();
            
            foreach(Prestamo prestamo in financiera.ListaDePrestamos)
            {
                sb.AppendLine(prestamo.Mostrar());
            }

            return sb.ToString();
        }

        private Financiera()
        {
            this.listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial)
            :this() 
        {
            this.razonSocial = razonSocial;
        }

        public static string Mostrar(Financiera financiera)
        {
            return (string)financiera;
        }

        public static bool operator ==(Financiera financiera, Prestamo prestamo)
        {
            if(financiera is not null && prestamo is not null)
            {
                foreach(Prestamo p in financiera.ListaDePrestamos)
                {
                    if(p == prestamo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Financiera financiera, Prestamo prestamo)
        {
            return !(financiera == prestamo);
        }

        public static Financiera operator +(Financiera financiera, Prestamo prestamo) 
        {
            if (financiera is not null && prestamo is not null)
            {
                if(financiera != prestamo)
                {
                    financiera.ListaDePrestamos.Add(prestamo);
                }
            }
            return financiera;
        }

        public void OrdenarPrestamos()
        {
            this.listaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }


    }

}
