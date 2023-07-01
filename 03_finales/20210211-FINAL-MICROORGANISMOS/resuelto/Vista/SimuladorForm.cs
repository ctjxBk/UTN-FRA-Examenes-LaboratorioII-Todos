using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class SimuladorForm : Form
    {
        private Task hilo;
        private CancellationTokenSource cancelarHilo;
        private Microorganismo microorganismo;
        private List<string> enfermedades;
        //private Entidades.GrupoDePrueba<Microorganismo> hola;

        public SimuladorForm()
        {
            InitializeComponent();



            this.enfermedades = new List<string>() { "Covid-19", "Gripe" };
            this.cmbMicroorganismo.DataSource = enfermedades;
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            
            if(hilo is null)
            {
                if (this.cmbMicroorganismo.SelectedItem == enfermedades[0])//covid
                {
                    //this.txtEvolucion.Text = "Su impacto de contagios se calcula en 5";
                    Covid19 enfermedad = new Covid19("Cepa Británica");
                    this.txtEvolucion.Text = enfermedad.Informe();
                    this.Ejecutar<Covid19>(enfermedad);
                }
                else if (this.cmbMicroorganismo.SelectedItem == enfermedades[1])//gripe
                {
                    //this.txtEvolucion.Text = "Su impacto de contagios se calcula en 2";
                    Gripe enfermedad = new Gripe("Cepa BritÁnica", Microorganismo.ETipo.Bacteria, Microorganismo.EContagiosidad.Moderada);
                    this.txtEvolucion.Text = enfermedad.Informe();
                    this.Ejecutar<Gripe>(enfermedad);
                }
            }
            else
            {
                MessageBox.Show("Ya se hizo la simulación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            
        }

        private void Final()
        {
            if (this.InvokeRequired)
            {
                FinInfectacion metodo = Final;
                object[] parametros = new object[] { };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.txtEvolucion.Text = $"¡Toda la población fue infectada! {Environment.NewLine}{this.txtEvolucion.Text}";
            }
        }

        private void Ejecutar<T>(T enfermedad) where T : Microorganismo
        {
            

            //asocio los eventos
            GrupoDePrueba<T>.FinalizaSimulacion += this.Final;
            GrupoDePrueba<T>.InformeDeAvance += this.Informe;
            GrupoDePrueba<T>.seCancelo += this.InformeSeCancelo;

            long poblacion = 0;
            //si no entra en el if, la poblacion esta como defecto en la clase GrupoDePrueba.cs
            if (long.TryParse(this.txtPoblacion.Text, out poblacion))
            {
                GrupoDePrueba<T>.Poblacion = poblacion;
            }
            else
            {
                this.txtPoblacion.Text = GrupoDePrueba<T>.poblacionPorDefecto.ToString();
            }
            if(this.hilo is null)
            {
                
                this.hilo = Task.Run(() =>
                {
                    this.cancelarHilo = new CancellationTokenSource();
                    GrupoDePrueba<T>.CancelarHilo = this.cancelarHilo;
                    GrupoDePrueba<T>.InfectarPoblacion(enfermedad);
                });
            }
            
            
        }

        private void Informe(int dia, long infectados)
        {
            if (this.InvokeRequired)
            {
                AvanceInfectados metodo = Informe;
                object[] parametros = new object[] {dia, infectados};
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.txtEvolucion.Text = $"Día {dia}: {infectados} infectados de la poblaciób total.{Environment.NewLine}{this.txtEvolucion.Text}";
            }
        }

        private void InformeSeCancelo()
        {
            if (this.InvokeRequired)
            {
                Action metodo = InformeSeCancelo;
                object[] parametros = new object[] {};
                this.Invoke(metodo, parametros);
            }
            else
            {
                string mensaje = "Se cancelo la tarea";
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtEvolucion.Text = $"{mensaje}.{Environment.NewLine}{this.txtEvolucion.Text}";
            }
            
        }

        private void Cancelar()
        {
            if (this.cancelarHilo is not null)
            {
                this.cancelarHilo.Cancel();
            }
        }

        private void SimuladorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                path = Path.Combine(path, "11-02-2011.txt");
                File.WriteAllText(path, this.txtEvolucion.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la informacion en el escritorio{Environment.NewLine}{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cancelar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
    }
}
