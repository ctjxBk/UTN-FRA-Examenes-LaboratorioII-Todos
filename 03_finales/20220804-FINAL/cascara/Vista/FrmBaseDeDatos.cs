using BibliotecaDeClases;
using System;
using System.Windows.Forms;

namespace Vista
{


    public partial class FrmBaseDeDatos : Form
    {
        SqlManejador manejador;
        public FrmBaseDeDatos()
        {
            InitializeComponent();
            manejador = new SqlManejador();
        }


        // DESARROLLAR
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
            
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
