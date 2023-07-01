using System;
using Entidades;
using System.Windows.Forms;

namespace Atencion
{
    public partial class FrmAtencion : Form
    {
        public FrmAtencion()
        {
            InitializeComponent();
        }

        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            var d = new DateTime().Date;
            lstMedicos.Items.Add(new PersonalMedico("Fede", "Dávila", new DateTime(1999, 12, 12), false));
            lstMedicos.Items.Add(new PersonalMedico("Esteban", "Prieto", new DateTime(1951, 11, 12), true));

            lstPacientes.Items.Add(new Paciente("Diego", "Cagna", new DateTime(1998, 6, 16), "Tigre"));
            lstPacientes.Items.Add(new Paciente("Alfredo", "Moreno", new DateTime(1989, 1, 21), "DF"));
            lstPacientes.Items.Add(new Paciente("Blas", "Giunta", new DateTime(1912, 12, 12), "La Boca"));
            lstPacientes.Items.Add(new Paciente("John Jairo", "Trelles", new DateTime(1978, 8, 30), "Medellín"));
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
    }
}
