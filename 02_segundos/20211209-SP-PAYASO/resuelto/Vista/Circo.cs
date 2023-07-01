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

namespace Vista
{
    public partial class Circo : Form
    {
        private List<PictureBox> globos;
        private Payaso payaso;
        private Serializadora serializadora;
        private CancellationTokenSource cancellationTokenSource;
        private Task tarea;
        private event Action<Exception> catchEnOtroHilo;

        public Circo()
        {
            InitializeComponent();

            this.globos = new List<PictureBox>();
            this.serializadora = new Serializadora();
            this.payaso = new Payaso("Pennywise", new DateTime(2021,5,12),"payaso.xml");

            this.globos.Add(balloon1);
            this.globos.Add(balloon2);
            this.globos.Add(balloon3);
            this.globos.Add(balloon4);
            this.globos.Add(balloon5);
        }

        public bool EstaActivo
        {
            get
            {
                return this.tarea is not null &&
                    (this.tarea.Status == TaskStatus.Running ||
                    this.tarea.Status == TaskStatus.WaitingToRun ||
                    this.tarea.Status == TaskStatus.WaitingForActivation);
            }
        }

        

        public void Detener()
        {
            this.cancellationTokenSource.Cancel();
        }

        private void RegalarGlobos()
        {
            //Inicio y arranco la Task
            if (!this.EstaActivo
                //&& this.tarea.IsCompleted
                )
            {
                this.cancellationTokenSource = new CancellationTokenSource();
                this.payaso.CancelTask = this.cancellationTokenSource;
                this.tarea = new Task(

                    () => {

                        try
                        {
                            this.payaso.Flotar();
                        }
                        catch (DatosException ex)
                        {
                            this.catchEnOtroHilo?.Invoke(ex);
                        }
                    
                    }
                    );

                this.tarea.Start();
            }
        }
     
        private void MostrarGlobos(int index)//, bool estado)
        {
            if (this.InvokeRequired)
            {
                DesplegarGlobos metodo = MostrarGlobos;
                object[] parametros = new object[] { index };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.globos[index].Visible = true;
            }
        }

        private void Circo_Load(object sender, EventArgs e)
        {
            //Asocio el evento
            this.payaso.AparecerGlobo += this.MostrarGlobos;
            this.catchEnOtroHilo += this.MostrarErrorEnOtroHilo;
        }

        private void MostrarErrorEnOtroHilo(Exception ex)
        {
            MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFlotar_Click(object sender, EventArgs e)
        {
            this.RegalarGlobos();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = this.serializadora.IGuardar(this.payaso) ? "Se pudo serializar" : "no se pudo serializar";
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DatosException ex)
            {
                try
                {
                    Logger.Log(ex.Message);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show($"{ex.Message} {Environment.NewLine} {ex2.Message}", "Error al guardar un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        
        private void Circo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //eligio Cerrar, uso Detener() para cerrar el hilo abierto 
                this.Detener();
            }
        }
    }
}
