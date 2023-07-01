using System;
using System.Windows.Forms;
using EntidadesRSP;


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
            this.Text = "Agregar Alumno";
        }

        public FrmAlumno(Alumno alumno, string queEs) : this()
        {
            
            this.alumno = alumno;
            if(queEs == "modificar")
            {
                this.Text = "Modificar Alumno";
                this.ModificarOElimnar(false);
            }
            else if(queEs == "eliminar")
            {
                this.Text = "Eliminar Alumno";
                this.ModificarOElimnar(true);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.alumno = new Alumno(Int32.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, double.Parse(txtNota.Text));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void ModificarOElimnar(bool eliminar)
        {
            txtDNI.Enabled = false;
            txtDNI.Text = this.alumno.Dni.ToString();
            txtNombre.Text = this.alumno.Nombre;
            txtApellido.Text = this.alumno.Apellido;
            txtNota.Text = this.alumno.Nota.ToString();

            if (eliminar)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtNota.Enabled = false;
            }
        }

    }
}
