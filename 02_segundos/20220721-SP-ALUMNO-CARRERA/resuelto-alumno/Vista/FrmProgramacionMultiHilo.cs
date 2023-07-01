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
        Task cargaAlumnos;   // no modificar
        CancellationTokenSource cts;  // no modificar 
        List<Alumno> listaAlumnos;  // no modificar

        public FrmProgramacionMultiHilo()  
        { 
            InitializeComponent();   // no modificar linea
            listaAlumnos = new List<Alumno>();  // no modificar linea

            this.cargaAlumnos = new Task(this.ComenzarCarga);
            this.cts = new CancellationTokenSource();
        }

        private void ComenzarCarga()
        {
            while (!this.cts.IsCancellationRequested) 
            {
                this.listaAlumnos.Add(GeneradorDeDatos.GetUnAlumno);
                this.ActualizarDataGrid();
                Thread.Sleep(2000);
            }
        }


        // no modificar metodo
        private void btn_comenzarCarga_Click(object sender, EventArgs e)
        {
            btn_comenzarCarga.Enabled = false;  
            cargaAlumnos.Start();
        }


        // no modificar metodo
        private void btn_cancelarCarga_Click(object sender, EventArgs e)
        {
            btn_cancelarCarga.Enabled = false;
            cts?.Cancel();
            MessageBox.Show("Carga de alumnos cancelada");

        }

        private void ActualizarDataGrid()
        {
            if (this.InvokeRequired)
            {
                Action metodo = ActualizarDataGrid;
                this.Invoke(metodo);
            }
            else
            {
                this.dtg_listadoDeAlumnos.DataSource = null;
                this.dtg_listadoDeAlumnos.DataSource = this.listaAlumnos;
            }
        }

    }
}
