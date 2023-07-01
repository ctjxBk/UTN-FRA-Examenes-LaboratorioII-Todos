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
                decimal dni;
                decimal.TryParse(this.tb_dni.Text, out dni);
                string nombre = this.tb_nombre.Text;
                string puesto = this.tb_puestoACubrir.Text;

                EmpleadoFreelance empleado = new EmpleadoFreelance(dni, nombre, puesto, GeneradorDeDatos.DevolverBoleanoAleatorio);
                SqlManejador sqlManejador = new SqlManejador();
                if (sqlManejador.Insertar(empleado)>0)
                {
                    MessageBox.Show("Se inserto el empleado en la base de datos","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Limpiar();
                    
                }
                else
                {
                    MessageBox.Show("No se inserto el empleado en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Limpiar()
        {
            this.tb_dni.Text = "";
            this.tb_nombre.Text = "";
            this.tb_puestoACubrir.Text = "";

        }


    }
}
