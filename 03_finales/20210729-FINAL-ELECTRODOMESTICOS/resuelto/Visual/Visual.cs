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

namespace Visual
{
    public partial class Visual : Form
    {
        private Task hilo;
        private CancellationTokenSource cancelarHilo;
        
        public Visual()
        {
            InitializeComponent();

            this.cancelarHilo = new CancellationTokenSource();

            this.hilo = new Task(() => {
                this.MostrarOfertar();    
            });
        }


        private void MostrarOfertar()
        {
            
            foreach (Producto p in Tienda.StockTienda)
            {
                if(p is Celular && !this.cancelarHilo.IsCancellationRequested)
                {
                    if (((Celular)p).EnOferta)
                    {
                        this.ActualizarCampo(p);
                        //PARA DEBUGIAR puse 20 milisegundos, para no esperar tanto, pero en realidad es 2000 milisegundos = 2 segundos
                        Thread.Sleep(200);
                    }
                }
            }
            MessageBox.Show("Terminaron las ofertas","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ActualizarCampo(Producto p)
        {
            if (this.InvokeRequired)
            {
                Action<Producto> metodo = this.ActualizarCampo;
                object[] parametros = new object[] { p };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.rtb_oferta.Text += p.ToString();
            }
        }

        private void Visual_Load(object sender, EventArgs e)
        {
            try
            {
                Tienda.eventoObtenerDatos();
            }
            catch (NoExisteFileException ex)
            {
                MostrarError(ex, "Error no existe archivo");
            }
            catch (ExcepcionPersonalizada ex)
            {
                MostrarError(ex, "Error Excepcion personalizada");
            }
            catch (Exception ex)
            {
                MostrarError(ex,"Error generico");
            }
        }

        private void Visual_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancelarHilo?.Cancel();
        }

        private void btn_MostrarOfertas_Click(object sender, EventArgs e)
        {
            if(this.hilo.Status != TaskStatus.Running && this.hilo.Status != TaskStatus.RanToCompletion)
            {
                this.hilo.Start();
            }
            else if(this.hilo.Status == TaskStatus.Running)
            {
                MessageBox.Show("Se están mostrandon las ofertas","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if(this.hilo.Status == TaskStatus.RanToCompletion)
            {
                MessageBox.Show("Ya se mostraron las ofertas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void MostrarError(Exception ex, string donde)
        {
            MessageBox.Show(ex.Message,donde,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
