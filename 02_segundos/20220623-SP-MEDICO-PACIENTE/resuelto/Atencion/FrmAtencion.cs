using System;
using Entidades;
using System.Windows.Forms;
using System.Text;
using Entidades;
using System.Collections.Generic;

namespace Atencion
{
    public partial class FrmAtencion : Form
    {
        private List<Paciente> pacientes;
        private List<PersonalMedico> medicos;
        public FrmAtencion()
        {
            InitializeComponent();
        }

        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            //var d = new DateTime().Date;
            //lstMedicos.Items.Add(new PersonalMedico("Fede", "Dávila", new DateTime(1999, 12, 12), false));
            //lstMedicos.Items.Add(new PersonalMedico("Esteban", "Prieto", new DateTime(1951, 11, 12), true));

            //lstPacientes.Items.Add(new Paciente("Diego", "Cagna", new DateTime(1998, 6, 16), "Tigre"));
            //lstPacientes.Items.Add(new Paciente("Alfredo", "Moreno", new DateTime(1989, 1, 21), "DF"));
            //lstPacientes.Items.Add(new Paciente("Blas", "Giunta", new DateTime(1912, 12, 12), "La Boca"));
            //lstPacientes.Items.Add(new Paciente("John Jairo", "Trelles", new DateTime(1978, 8, 30), "Medellín"));
            this.pacientes = new List<Paciente>();

            try
            {
                PersonalMedicoDao medicoDao = new PersonalMedicoDao();
                this.medicos = medicoDao.Leer(null);
                this.ActualizarMedicos();
            }
            catch (ExcepcionPersonalizada ex)
            {
                this.MostrarError(ex);
            }


            Mock.OnMostrarError += this.MostrarError;
            Mock.OnActualizarPacientes += this.ActualizarPacientes;
            Mock.OnFinalizo += this.FinalizoCarga;
            Mock.Mocking(this.pacientes);
        }


        private void ActualizarMedicos()
        {
            this.lstMedicos.DataSource = null;
            this.lstMedicos.DataSource = this.medicos;
        }

        private void ActualizarPacientes()
        {
            if (this.InvokeRequired)
            {
                Action metodo = this.ActualizarPacientes;
                this.Invoke(metodo);
            }
            else
            {
                this.lstPacientes.DataSource = null;
                this.lstPacientes.DataSource = this.pacientes;
            }
        }

        private void FinalizoCarga()
        {
            MessageBox.Show("Ya se cargaron todos los pacientes de la base de datos","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItems.Count > 0 && lstPacientes.SelectedItems.Count > 0)
            {
                PersonalMedico m = (PersonalMedico)lstMedicos.SelectedItem;
                Paciente p = (Paciente)lstPacientes.SelectedItem;

                p.Diagnostico += "Paciente curado";

                Consulta c = m + p;

                lstMedicos.SelectedItems.Clear();
                lstPacientes.SelectedItems.Clear();

                MessageBox.Show(c.ToString(), "Atención finalizada", MessageBoxButtons.OK);
                this.pacientes.Remove(p);
                this.ActualizarPacientes();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Medico y un Paciente para poder continuar.", "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void lstMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItems.Count > 0)
            {
                PersonalMedico m = (PersonalMedico)lstMedicos.SelectedItem;
                rtbInfoMedico.Text = Persona.FichaPersonal(m);
            }
        }

        private void MostrarError(Exception ex)
        {

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
            sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

            int contador = 1;
            sb.AppendLine($"Error nº{contador}: {ex.Message}");

            Exception inner = ex;
            while (inner != null)
            {
                contador++;
                sb.AppendLine($"Error nº{contador}: {inner.Message}");
                inner = inner.InnerException;
            }
            sb.AppendLine($"{Environment.NewLine}------------------------------------{Environment.NewLine}");
            
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.lstMedicos.SelectedItem is not null)
            {
                PersonalMedico? medico = this.lstMedicos.SelectedItem as PersonalMedico;
                if(medico is not null)
                {
                    try
                    {
                        PersonalMedico.exportarXML(medico);
                    }
                    catch (Exception ex)
                    {
                        this.MostrarError(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Error al momento de traer el médico del listBox");
                }
            }
            else
            {
                MessageBox.Show("Seleccione a un medico por favor");
            }
        }
    }
}
