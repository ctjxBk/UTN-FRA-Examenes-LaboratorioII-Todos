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


        }

        private void ComenzarCarga()
        {

            while (true) 
            {
             

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
            cts.Cancel();
            MessageBox.Show("Carga de alumnos cancelada");

        }
    }
}
