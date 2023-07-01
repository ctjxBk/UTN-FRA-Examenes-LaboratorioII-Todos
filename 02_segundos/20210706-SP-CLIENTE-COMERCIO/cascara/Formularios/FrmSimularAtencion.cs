using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    
    public partial class FrmSimularAtencion : Form
    {
        private Comercio comercio;
        private CancellationTokenSource cancelTask;
        public FrmSimularAtencion(Comercio comercio)
        {
            InitializeComponent();
            this.comercio = comercio;
            this.cancelTask = new CancellationTokenSource();
        }

        private void FrmSimularAtencion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Cerrar();
        }

        private void Cerrar()
        {
            if (this.InvokeRequired)
            {
                Action metodo = Cerrar;
                this.Invoke(metodo);
            }
            else
            {
                this.Close();
            }
        }

        private void CambiarCliente(Cliente cliente)
        {
            if (this.InvokeRequired)
            {
                DelegadoMostrarCliente metodo = CambiarCliente;
                object[] parametros = new object[] { cliente };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.lblCliente.Text = $"{cliente.Numero} - {cliente.Nombre}";
            }
        }

        private void FrmSimularAtencion_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Simular simular = new Simular(this.comercio, cancelTask.Token);
                simular.ErrorMostrado += this.MostrarErrorNoHayMasClientes;
                simular.CambioCliente += CambiarCliente;
                simular.Finalizo += Cerrar;
                simular.Simulador();
            });
        }

        private void MostrarErrorNoHayMasClientes(Exception ex)
        {
            if (this.InvokeRequired)
            {
                DelegadoMostrarError metodo = MostrarErrorNoHayMasClientes;
                object[] parametros = new object[] { ex };
                this.Invoke(metodo, parametros);
            }
            else
            {
                MessageBox.Show(ex.Message,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void FrmSimularAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancelTask.Cancel();
        }
    }
}
