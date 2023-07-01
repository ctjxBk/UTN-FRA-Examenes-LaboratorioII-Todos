using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{

    // DESARROLLAR
    public partial class FrmProgramacionMultiHilo : Form
    {

        CancellationTokenSource cts;
        List<Empleado> listaEmpleados;
        private const int tiempo = 200;

        public FrmProgramacionMultiHilo()
        {
            InitializeComponent();

            this.cts = new CancellationTokenSource();
            this.listaEmpleados = new List<Empleado>();
        }

        private void ComenzarCarga()
        {
            float sueldosDolarizados = 0;
            float sueldosPesificados = 0;
            float montoTotalAguinaldos = 0;
            bool banderaDolar = false;
            bool banderaPesos = false;

            while (true)
            {
                if (this.cts.IsCancellationRequested)
                {
                    break;
                }

                Empleado unEmpleado = GeneradorDeDatos.GetEmpleadoAleatorio;
                float honorarios = unEmpleado.CalcularHonorarios;

                if(unEmpleado is EmpleadoFreelance)
                {
                    if(honorarios + sueldosDolarizados < 10000)
                    {
                        this.listaEmpleados.Add(unEmpleado);
                        sueldosDolarizados += honorarios;
                        Thread.Sleep(tiempo);
                    }
                    else
                    {
                        banderaDolar = true;
                    }
                }
                if(unEmpleado is EmpleadoRelacionDependencia)
                {
                    float aguinaldo = ((EmpleadoRelacionDependencia)unEmpleado).SueldoConAguinaldoActualizado;
                    if(aguinaldo + montoTotalAguinaldos < 2000000
                        &&  honorarios + sueldosPesificados < 1000000)
                    {
                        this.listaEmpleados.Add(unEmpleado);
                        sueldosPesificados += honorarios;
                        montoTotalAguinaldos += aguinaldo;
                        Thread.Sleep(tiempo);
                    }
                    else
                    {
                        banderaPesos = true;
                    }
                    
                }

                this.Actualizar(sueldosDolarizados,montoTotalAguinaldos,sueldosPesificados);
                
                if(banderaPesos && banderaDolar)
                {
                    this.CancelarProceso();
                }
                
                
            }

        }

        private void Actualizar(float dolares, float aguinaldos, float pesos)
        {
            if (this.InvokeRequired)
            {
                Action<float, float, float> metodo = Actualizar;
                object[] parametros = new object[] {dolares, aguinaldos, pesos};
                this.Invoke(metodo, parametros);
            }
            else
            {
                dtg_ListadoPuestosEncontrados.DataSource = null;
                dtg_ListadoPuestosEncontrados.DataSource = listaEmpleados;

                lb_SueldoDolarizado.Text = "Sueldos Dolarizados a Liquidar mensualmente: " + dolares;
                lb_MontoAguinaldo.Text = "Monto a liquidar en Aguinaldos: " + aguinaldos;
                lb_SueldoPesificado.Text = "Sueldos Pesificados a Liquidar mensualmente:  " + pesos;
            }
        }


        private void CancelarProceso()
        {
            //this.btn_comenzarCarga.BeginInvoke((MethodInvoker)delegate ()
            //{

            //});
            if (this.InvokeRequired)
            {
                Action metodo = CancelarProceso;
                this.Invoke(metodo);
            }
            else
            {
                cts.Cancel();
                MessageBox.Show($"Hasta aqui dan las finanzas: Se les pagará a {listaEmpleados.Count} empleados");
                btn_comenzarCarga.Enabled = false;
            }
        }


        private void btn_comenzarCarga_Click(object sender, EventArgs e)
        {
            btn_comenzarCarga.Enabled = false;
            Task CargaEmpleados = new Task(this.ComenzarCarga);
            CargaEmpleados.Start();
        }

        
    }
}
