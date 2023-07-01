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
                Empleado empleado = new Empleado(dni, puestoACubrir, nombre, esDolarizado);
                if (manejador.Insertar(empleado)>0)
                {
                    MessageBox.Show("Se inserto correctamente el empleado en la BBDD");
                    this.tb_dni.Text = "";
                    this.tb_nombre.Text = "";
                    this.tb_puestoACubrir.Text = "";
                    this.checkbtn_dolarizado.Checked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
