using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{

    //DESARROLLAR
    public class EmpleadoFreelance : Empleado
    {
        private bool dolarOficial;

        public EmpleadoFreelance
            (decimal dni, string nombre, string posicion, bool dolarOficial) 
            :base(dni, nombre, posicion)
        {
            this.dolarOficial = dolarOficial;
        }

        public override float CalcularHonorarios
        {
            get
            {
                int tipoCambio = this.dolarOficial ? 138 : 290;
                return this.remuneracionPretendida / tipoCambio;
                
            }
        }
    }
}
