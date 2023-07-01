using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class FormDT : Form
    {
        private DirectorTecnico dt;

        public FormDT()
        {
            InitializeComponent();
        }

        private void FormDT_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            int dni = (int)this.nudDNI.Value;
            int edad = (int)this.nudEdad.Value;
            int añosExperiencia = (int)this.nudExperiencia.Value;
            
            this.dt = new DirectorTecnico(nombre,apellido,edad,dni,añosExperiencia);
            MessageBox.Show("Se ha creado el DT!","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if(this.dt is not null)
            {
                if (this.dt.ValidarAptitud())
                {
                    MessageBox.Show("El DT es apto","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El DT NO es apto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se ha creado al DT","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
