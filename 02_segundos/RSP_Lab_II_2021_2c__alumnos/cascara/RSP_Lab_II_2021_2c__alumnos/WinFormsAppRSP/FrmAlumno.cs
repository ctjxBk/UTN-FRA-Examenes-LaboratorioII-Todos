using System;
using System.Windows.Forms;


namespace WinFormsAppRSP
{
    public partial class FrmAlumno : Form
    {
        private Alumno alumno;

        public Alumno Alumno
        {
            get { return alumno; }
        }

        public FrmAlumno()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
