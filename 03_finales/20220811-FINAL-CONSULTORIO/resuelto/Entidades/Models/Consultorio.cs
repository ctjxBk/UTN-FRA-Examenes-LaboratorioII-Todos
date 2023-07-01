using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades.Interfaces;

namespace Entidades.Models
{
    //    14.	Consultorio, será genérica, solo podrá recibir tipos que implementen la interfaz IPaciente y posean un constructor publico sin parámetros:
    //a.En su constructor publico inicializara un nombre para el consultorio y ademas:
    //i.Inicializar:
    //1.	demoraAtencionTotal en 0 (cero).
    //2.	cantAtendidos en 0 (cero).
    //15.	La propiedad AbrirConsultorio:
    //a.El GET retornara True, si la tares no es nula y estado de la tarea es Running o WaitingToRun o WaitingForActivation.
    //b.En el SET, si el valor recibido es TRUE y la tarea es nula o su estado no es Running o no es WaitingToRun o no es WaitingForActivation, se instanciará un nuevo CancelationTokenSource y se llamará a IniciarIngreso. De lo contrario se llamará al método Cancel de cancellation.
    //16.	El método IniciarIngreso será privado y:
    //a.Ejecutará en un hilo secundario la acción de que:
    //i.Mientras no se requiera cancelación de la tarea invocara a los métodos NotificarNuevoIngreso, EsperarProximoIngreso y luego incrementar en 1 la cantidad de atendidos. 
    //17.	El método NotificarNuevoIngreso, verificara si el evento OnIngreso posee suscriptores y en caso exitoso realizara:
    //a.Instanciar el paciente.
    //b.Anunciará el ingreso del paciente.
    //c.Notificar el paciente instanciado
    //18.	El método EsperarProximoIngreso si posee un suscriptor notificara los segundos transcurridos mientras que el paciente no sea atendido o no se requiera cancelacion (Utilizar Thread.Sleep para dormir el hilo 1 segundo antes de ir incrementando)
      
    public delegate void DelegadoDemoraAtencion(double demora);
    public delegate void DelegadoNuevoIngreso(IPaciente paciente);
    public class Consultorio<T> where T : Paciente, new()
    {
        private CancellationTokenSource cancellation;
        private int cantAtendidos;
        private double demoraAtencionTotal;
        private string nombre;
        private T paciente;
        private Task tarea;
        public event DelegadoDemoraAtencion OnDemora;
        public event DelegadoNuevoIngreso OnIngreso;
        public event Action<Exception> OnMostrarError;

        public bool AbrirConsultorio
        {
            get
            {
                if (this.tarea is not null
                    &&
                    (this.tarea.Status == TaskStatus.Running
                    || this.tarea.Status == TaskStatus.WaitingToRun
                    || this.tarea.Status == TaskStatus.WaitingForActivation)
                    )
                {
                    return true;
                }
                return false;   
            }
            set
            {
                if (value == true && AbrirConsultorio == false)
                {
                    this.cancellation = new CancellationTokenSource();
                    this.IniciarIngreso();
                }
                else
                {
                    this.cancellation.Cancel();
                }
            }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public double TiempoMedioDeAtencion
        {
            get
            {
                if(this.cantAtendidos == 0)
                {
                    return 0;
                }
                return this.demoraAtencionTotal / this.cantAtendidos;
            }
        }

        public Consultorio(string nombre)
        {
            this.nombre = nombre;
            this.demoraAtencionTotal = 0;
            this.cantAtendidos = 0;
            
        }

        private void EsperarProximoIngreso()
        {
            if(this.OnDemora is not null)
            {
                while (!this.paciente.EstaAtendido && !this.cancellation.IsCancellationRequested)
                {
                    double tiempo = 1000;
                    Thread.Sleep((int)tiempo);
                    this.demoraAtencionTotal += tiempo;
                    this.OnDemora(this.demoraAtencionTotal);
                }
            }
        }

        private void IniciarIngreso()
        {
            tarea = Task.Run(() =>
            {
                while (!this.cancellation.IsCancellationRequested)
                {
                    this.NotificarNuevoIngreso();
                    this.EsperarProximoIngreso();
                    this.cantAtendidos++;
                }
            });
        }

        private void NotificarNuevoIngreso()
        {
            if(this.OnIngreso is not null)
            {
                try
                {
                    Paciente paciente = new Paciente();
                    paciente.Anunciarse();
                    this.paciente = paciente as T;
                    if(this.paciente is not null)
                    {
                        this.OnIngreso(paciente);
                    }
                }
                catch (Exception ex)
                {
                    this.OnMostrarError?.Invoke(ex);
                }
            }
        }

    }
}
