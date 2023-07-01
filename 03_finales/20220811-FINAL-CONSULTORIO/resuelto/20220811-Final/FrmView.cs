using Entidades.DataBase;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Interfaces;
using Entidades.Files;
using Entidades.Exceptions;

namespace _20220811_Final
{
    public partial class FrmView : Form
    {
        private Queue<IPaciente> pacientes;
        Consultorio<Paciente> consultorio;
        public FrmView()
        {
            InitializeComponent();
            this.pacientes = new Queue<IPaciente>();
            this.consultorio = new Consultorio<Paciente>("24 Hs");
        }
        private void FrmView_Load(object sender, EventArgs e)
        {
            //Alumno agregar manejadores
            this.consultorio.OnDemora += this.MostrarConteo;
            this.consultorio.OnIngreso += this.MostrarPaciente;
            this.consultorio.OnMostrarError += this.MostrarError;
        }


        //Alumno: Realizar los cambios necesarios sobre MostrarPaciente
        //de manera que en lblNombrePaciente se refleje el indentificador del paciente y
        //se agregue el paciente a la Queue

        private void MostrarPaciente(IPaciente paciente)
        {
            if (this.InvokeRequired)
            {
                DelegadoNuevoIngreso metodo = MostrarPaciente;
                object[] parametros = new object[] { paciente };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.pacientes.Enqueue(paciente);
                this.lblNombrePaciente.Text = paciente.Identificador;
            }
        }

        //Alumno: Realizar los cambios necesarios sobre Mostrar conteo de manera que se refleje
        //en el fomrulario el tiempo transcurrido de cada iteracion con el paciente
        private void MostrarConteo(double tiempo)
        {
            if (this.InvokeRequired)
            {
                DelegadoDemoraAtencion metodo = MostrarConteo;
                object[] parametros = new object[] { tiempo };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.lblTiempo.Text = $"{tiempo} segundos";
                this.lblTma.Text = $"{this.consultorio.TiempoMedioDeAtencion.ToString("00.0")} segundos";
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!this.consultorio.AbrirConsultorio)
            {
                this.consultorio.AbrirConsultorio = true;
                this.btnAbrir.Image = Properties.Resources.close;
            }
            else
            {
                this.consultorio.AbrirConsultorio = false;
                this.btnAbrir.Image = Properties.Resources.open;

                //Alumno serializar this.lstAtendidos.Item en ListadoDeAtendidos.json
                try
                {
                    FileManager.Guardar(this.lstAtendidos.Items, "ListadoDeAtendidos.json");
                }
                catch (FileManagerException ex)
                {
                    this.MostrarError(ex);
                }

            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.pacientes.Count > 0)
            {
                IPaciente paciente = this.pacientes.Dequeue();
                paciente.Atender();
                this.ActualizarAtendidos(paciente);
            }
            else
            {
                MessageBox.Show("El consultorio no posee pacientes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ActualizarAtendidos(IPaciente paciente)
        {
            this.lstAtendidos.Items.Add(paciente);
        }


        private void MostrarError(Exception ex)
        {

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
            sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

            int contador = 0;

            Exception? inner = ex;
            while (inner != null)
            {
                contador++;
                sb.AppendLine($"Error nº{contador}: {inner.Message}");
                inner = inner.InnerException;
            }
            sb.AppendLine($"{Environment.NewLine}------------------------------------{Environment.NewLine}");

            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
