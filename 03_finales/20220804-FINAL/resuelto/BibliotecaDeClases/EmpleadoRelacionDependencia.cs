using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{

    public enum EBono
    {
        Basico = 15000,
        Medio = 25000,
        Alto = 40000
    }


    // DESARROLLAR
    public class EmpleadoRelacionDependencia : Empleado
    {

        private EBono bono;

        public EmpleadoRelacionDependencia
            (decimal dni, string nombreCompleto, string posicion, EBono bono)
            :base (dni, nombreCompleto, posicion)
        {
            this.bono = bono;
        }

        public override float CalcularHonorarios
        {
            get
            {
                float descuento = this.remuneracionPretendida > 250000 ? 0.7f : 1f;
                return this.remuneracionPretendida * descuento;
            }
        }
        public float SueldoConAguinaldoActualizado
        {
            get
            {
                return this.CalcularHonorarios * 1.5f + (float)bono;
            }
        }
    }
}
