using BibliotecaDeClases;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmEventos : Form
    {
        Universidad unaUniversidad;  // no modificar
        public FrmEventos()
        {
            InitializeComponent();
            int cupoUniversidad = GeneradorDeDatos.Rnd.Next(5, 16);   // no modificar
            unaUniversidad = new Universidad(cupoUniversidad);  // no modificar

        }

        // no modificar metodo
        private void btn_AgregarCarreras_Click(object sender, EventArgs e)
        {
            lbox_listado.DataSource = null;
            lbox_listado.DataSource = unaUniversidad.AgregarNuevaCarrera();
        }


        // no modificar metodo
        private void MostrarMensajeAgradecimiento(bool universidadCompleta)
        {
            if (universidadCompleta)
            {
                MessageBox.Show("La carrera se encuentra completa. Agradecemos su participacion.\n Los esperamos la proxima");
                this.lbox_listado.Enabled = !universidadCompleta;
            }
        }

        // no modificar metodo
        private void DesactivarComponentesFormularios(bool estado)
        {
            this.btn_AgregarCursos.Enabled = !estado;
        }
    }
}
