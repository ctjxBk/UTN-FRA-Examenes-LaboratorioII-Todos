using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmProgramacionMultiHilo : Form
    {
        Task cargaAlumnos;
        CancellationTokenSource cts;
        List<Alumno> listaAlumnos;

        public FrmProgramacionMultiHilo()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
            cargaAlumnos = new Task(ComenzarCarga);
            listaAlumnos = new List<Alumno>();
        }

        private void ComenzarCarga()
        {

            while (true)
            {
                if (cts.IsCancellationRequested)
                {
                    return;
                }
                else if (this.dtg_listadoDeAlumnos.InvokeRequired)
                {
                    listaAlumnos.Add(GeneradorDeDatos.GetUnAlumno);

                    this.dtg_listadoDeAlumnos.BeginInvoke((MethodInvoker)delegate ()
                    {
                        dtg_listadoDeAlumnos.DataSource = null;
                        dtg_listadoDeAlumnos.DataSource = listaAlumnos;
                    });
                }
                Thread.Sleep(2000);
            }
        }

        private void btn_comenzarCarga_Click(object sender, EventArgs e)
        {
            btn_comenzarCarga.Enabled = false;
            cargaAlumnos.Start();
        }

        private void btn_cancelarCarga_Click(object sender, EventArgs e)
        {
            btn_cancelarCarga.Enabled = false;
            MessageBox.Show("Carga de alumnos cancelada");
            cts.Cancel();
        }
    }
}
