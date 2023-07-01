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

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (manejador.Insertar(new Alumno(int.Parse(tb_dni.Text), tb_nombre.Text, int.Parse(tb_nota1.Text), int.Parse(tb_nota2.Text))) == 1)
                {
                    MessageBox.Show("Se ha insertado el alumno correctamente");
                }
                else
                {
                    MessageBox.Show("No se ha podido insertar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
