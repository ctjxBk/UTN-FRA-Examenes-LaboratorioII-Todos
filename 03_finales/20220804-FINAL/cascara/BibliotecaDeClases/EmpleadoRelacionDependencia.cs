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
    public class EmpleadoRelacionDependencia
    {

        EBono bono;

        public EmpleadoRelacionDependencia(decimal dni, string nombreCompleto, string posicion, EBono bono)
        {
            this.bono = bono;
        }



    }
}
