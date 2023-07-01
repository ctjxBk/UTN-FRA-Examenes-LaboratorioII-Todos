using BibliotecaDeClases;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmBaseDeDatos : Form
    {
        SqlManejador manejador;


        //no modificar
        public FrmBaseDeDatos()
        {
            InitializeComponent();
            manejador = new SqlManejador();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int dni = int.Parse(tb_dni.Text);
                string puestoACubrir = tb_puestoACubrir.Text;
                string nombre = tb_nombre.Text;
                bool esDolarizado = checkbtn_dolarizado.Checked;

                // desarrollar

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
