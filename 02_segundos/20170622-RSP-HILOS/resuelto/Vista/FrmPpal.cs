using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmPpal : Form
    {

        private LosHilos hilos;
        private int cantidad;
        private InfoHilo infohilos;
        

        public FrmPpal()
        {
            InitializeComponent();

            this.cantidad = 1;
            this.hilos = new LosHilos();
            this.hilos.AvisoFin += MostrarMensajeFin;
            this.hilos.MensajeError += MensajeError;
        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            this.hilos = this.hilos + cantidad;
            cantidad++;
            
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(this.hilos.Bitacora, "Bitacora", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.MensajeError(ex);
            }
            //for(int i = 0; i < cantidad; i++)
            //{
            //    try
            //    {
            //        this.hilos.RespuestaHilo(i);
            //    }
            //    catch(Exception ex)
            //    {
            //        this.MensajeError(ex);
            //    }
            //}
        }

        private void MostrarMensajeFin(string mensaje)
        {
            MessageBox.Show(mensaje, "Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(Exception ex)
        {
            if (this.InvokeRequired)
            {
                Action<Exception> metodo = this.MensajeError;
                object[] parametros = new object[] { ex };
                this.Invoke(metodo, parametros );
            }
            else
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
