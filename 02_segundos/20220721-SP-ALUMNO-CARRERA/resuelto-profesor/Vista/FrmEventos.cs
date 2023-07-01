using BibliotecaDeClases;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmEventos : Form
    {
        Universidad unaUniversidad;
        public FrmEventos()
        {
            InitializeComponent();
            unaUniversidad = new Universidad(GeneradorDeDatos.Rnd.Next(5, 16));
            unaUniversidad.cupoLleno += MostrarMensajeAgradecimiento;
            unaUniversidad.cupoLleno += DesactivarComponentesFormularios;
        }

        private void btn_AgregarCarreras_Click(object sender, EventArgs e)
        {
            lbox_listado.DataSource = null;
            lbox_listado.DataSource = unaUniversidad.AgregarNuevaCarrera();
        }

        private void MostrarMensajeAgradecimiento(bool universidadCompleta)
        {
            if (universidadCompleta)
            {
                MessageBox.Show("La carrera se encuentra completa. Agradecemos su participacion.\n Los esperamos la proxima");
                this.lbox_listado.Enabled = !universidadCompleta;
            }
        }

        private void DesactivarComponentesFormularios(bool estado)
        {
            this.btn_AgregarCursos.Enabled = !estado;
        }
    }
}
