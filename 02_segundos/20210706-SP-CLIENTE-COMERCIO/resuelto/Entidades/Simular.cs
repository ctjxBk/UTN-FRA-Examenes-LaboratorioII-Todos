using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void Delegado(Object o);
    public class Simular
    {
        public static event Delegado ActualizarCliente;
        public static event Action ActualizarBD;
        public static event Action FinalizarAtencion;
        static Thread hilo;
        static Comercio c;
        public Simular(Comercio c)
        {
            Simular.c = c;
            hilo = new Thread(Simulador);
            hilo.Start();

        }

        public static void Simulador()
        {
            while (c.Clientes.Count != 0)
            {

                ActualizarCliente.Invoke(c.LlamarCliente());
                Thread.Sleep(2000);

            }
            FinalizarAtencion.Invoke();
        }

        public static void Cerrar()
        {
            if (hilo.IsAlive)
            {

                hilo.Abort();
                //ActualizarBD.Invoke();
            }
        }

    }
}
