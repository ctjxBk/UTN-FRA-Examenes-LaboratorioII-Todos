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
    public partial class FormVista : Form
    {
        private Curso curso;
        public FormVista()
        {
            InitializeComponent();
            this.cmbDivision.DataSource = Enum.GetValues(typeof(Divisiones));
            this.cmbDivisionCurso.DataSource = Enum.GetValues(typeof(Divisiones));
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Profesor profe = new Profesor(this.txtNombreProfe.Text, this.txtApellidoProfe.Text, this.txtDocumentoProfe.Text);
            
            Divisiones division;
            Enum.TryParse<Divisiones>(cmbDivisionCurso.SelectedValue.ToString(), out division);

            this.curso = new Curso((short)this.nudAnioCurso.Value, division, profe);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(this.curso is not null)
            {
                this.rtbDatos.Text = (string)this.curso;
            }
            else
            {
                MessageBox.Show("No se creo el curso aún","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.curso is not null)
            {
                Divisiones division;
                Enum.TryParse<Divisiones>(cmbDivision.SelectedValue.ToString(), out division);
                Alumno alumno = new Alumno(this.txtNombre.Text, this.txtApellido.Text, this.txtDocumento.Text ,(short)this.nudAnio.Value, division);
                this.curso = this.curso + alumno;
            }
            else
            {
                MessageBox.Show("No se creo el curso aún", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormVista_Load(object sender, EventArgs e)
        {

        }
    }
}
