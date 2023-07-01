using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoMostrarError(Exception ex);

    public delegate void DelegadoMostrarCliente(Cliente cliente);
    public class Simular
    {
        public event DelegadoMostrarCliente CambioCliente;
        public event DelegadoMostrarError ErrorMostrado;
        public event Action Finalizo;
        private Comercio comercio;
        private CancellationToken token;
        public Simular(Comercio comercio, CancellationToken token)
        {
            this.comercio = comercio;
            this.token = token;
        }

        public void Simulador()
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    this.CambioCliente?.Invoke(this.comercio.LlamarCliente());
                    Thread.Sleep(new Random().Next(1000, 2000));
                }
            }
            catch (SinClientesException ex)
            {
                this.ErrorMostrado?.Invoke(ex);
            }
            this.Finalizo?.Invoke();
        }
        
    }
}
