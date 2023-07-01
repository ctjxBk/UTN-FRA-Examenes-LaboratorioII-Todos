using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{

    public delegate void AvanceInfectados(int dia, long infectados);
    public delegate void FinInfectacion();

    public static class GrupoDePrueba<T> where T : Microorganismo
    {
        private static T enfermedad;
        private static long poblacion;
        public static event AvanceInfectados InformeDeAvance;
        public static event FinInfectacion FinalizaSimulacion;
        private static CancellationTokenSource cancelarHilo;
        public static event Action seCancelo;
        public const long poblacionPorDefecto = 10000000;

        public static long Poblacion { set => poblacion = value; }
        public static CancellationTokenSource CancelarHilo { set => cancelarHilo = value; }

        static GrupoDePrueba()
        {
            GrupoDePrueba<T>.poblacion = poblacionPorDefecto;
            GrupoDePrueba<T>.cancelarHilo = new CancellationTokenSource();
        }

        public static void InfectarPoblacion(object obj)
        {
            //enfermedad = obj as T;
            //if(enfermedad is not null)
            if(obj is T)
            {
                enfermedad = (T)obj;
                
                int dia = 1;
                while(enfermedad.IndiceDeContagios<= poblacion)
                {
                    if (cancelarHilo.IsCancellationRequested)
                    {
                        break;
                    }
                    InformeDeAvance?.Invoke(dia, enfermedad.IndiceDeContagios);
                    Thread.Sleep(75);
                    dia++;
                }
                if (!(enfermedad.IndiceDeContagios <= poblacion))
                {
                    InformeDeAvance?.Invoke(dia, poblacion);
                    FinalizaSimulacion?.Invoke();
                }
                else
                {
                    seCancelo?.Invoke();
                }
            }

        }

    }
}
