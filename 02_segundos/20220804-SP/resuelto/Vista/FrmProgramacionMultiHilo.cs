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
        Task cargaEmpleados;
        CancellationTokenSource cts;
        List<Empleado> postulantes;
        List<Puesto> puestosLibres;



        //completar
        public FrmProgramacionMultiHilo()
        {
            InitializeComponent();

            postulantes = new List<Empleado>();
            puestosLibres = new List<Puesto>();
            this.cts = new CancellationTokenSource();
            this.ComenzarCarga();
        }



        //no modificar
        private void FrmProgramacionMultiHilo_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                puestosLibres.Add(GeneradorDeDatos.GetUnPuesto);
            }
        }


        private void ComenzarCarga()
        {
            //desarrollar
            this.cargaEmpleados = new Task(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    //deveria funcionar con ==, pero por las dudas ponemos >=
                    if(this.postulantes.Count >= this.puestosLibres.Count)
                    {
                        this.CancelarProceso();
                        return;
                    }
                    Empleado empleado = GeneradorDeDatos.GetEmpleado;

                    foreach (Puesto puesto in this.puestosLibres)
                    {
                        if (empleado.Posicion == puesto.Posicion
                        && empleado.CalcularHonorarios < puesto.CalcularHonorarios
                            )
                        {
                            this.postulantes.Add(empleado);
                            this.Actualizar();
                            Thread.Sleep(500);
                        }
                    }
                }
            });
        }

        private void Actualizar()
        {
            if (this.InvokeRequired)
            {
                Action metodo = this.Actualizar;
                this.Invoke(metodo);
            }
            else
            {
                dtg_ListadoPuestosEncontrados.DataSource = null;
                dtg_ListadoPuestosEncontrados.DataSource = this.postulantes;
            }
        }



        // completar
        private void CancelarProceso()
        {

            btn_comenzarCarga.Enabled = false;
            MessageBox.Show("Se han cubierto todos los puestos de trabajo!!!");
            cts.Cancel();

        }



        //no modificar
        private void btn_comenzarCarga_Click(object sender, EventArgs e)
        {
            btn_comenzarCarga.Enabled = false;
            cargaEmpleados.Start();
        }

        private void FrmProgramacionMultiHilo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CancelarProceso();
        }
    }
}
