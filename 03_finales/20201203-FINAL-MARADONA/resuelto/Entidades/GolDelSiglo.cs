using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Audio;

namespace Entidades
{
    //21:00 - 23:11 sin test

    public class GolDelSiglo
    {
        private Task hilo;
        private CancellationTokenSource cancelarHilo;
        //esto no lo pide,. lo hago para practicar
        public event Action<Exception> mostrarError;

        public void CerrarApp()
        {
            //verifico porque podrían abrir la aplicación y cerrar sin crear la task, por ende
            //podrían cancelar el hilo usando .Cancel del CancellationTokenSource que NUNCA se instancio !
            if(this.cancelarHilo != null)
            {
                this.cancelarHilo.Cancel();
            }
        }
        
        public void IniciarJugada()
        {
            if(this.hilo != null
                && (this.hilo.Status == TaskStatus.Running
                //|| this.hilo.Status == TaskStatus.WaitingToRun
                ))
            {
                try
                {
                    throw new JugadaActivaException();
                }
                catch(JugadaActivaException ex)
                {
                    //esto no lo pide,. lo hago para practicar
                    this?.mostrarError(ex);
                }
            }
            else
            {
                this.hilo = Task.Run(() =>
                {
                    this.cancelarHilo = new CancellationTokenSource();
                    while (!this.cancelarHilo.IsCancellationRequested)
                    {
                        Relato.VictorHugoMorales();
                    }
                });
            }
            
        }

    }
}
