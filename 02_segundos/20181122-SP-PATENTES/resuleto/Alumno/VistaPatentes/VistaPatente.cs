using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Patentes
{
    public delegate void MostrarPatente(object patente);
    public delegate void FinExposicionPatente(VistaPatente vp);

    public partial class VistaPatente : UserControl
    {

        public event FinExposicionPatente FinExposicion;
        private CancellationTokenSource cancelarTarea;

        public CancellationTokenSource CancelarTarea { set => cancelarTarea = value; }

        public VistaPatente()
        {
            InitializeComponent();

            picPatente.Image = fondosPatente.Images[(int)Patente.Tipo.Mercosur];
        }
        
        public void MostrarPatente(object patente)
        {

            if (cancelarTarea != null && cancelarTarea.IsCancellationRequested)
            {
                return;
            }
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    Random r = new Random();

                    // Llamar al hilo principal
                    // ALUMNO
                    MostrarPatente metodo = this.MostrarPatente;
                    object[] parametros = new object[] { patente };
                    this.Invoke(metodo, parametros);

                    Thread.Sleep(r.Next(2000, 5000));


                    // Agregar evento de que finalizó la exposición de la patente
                    // ALUMNO
                    this.FinExposicion?.Invoke(this);
                }
                catch (Exception ex)
                {
                    MostrarError(ex);
                }

            }
            else
            {
                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();
            }
        }


        public static void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
