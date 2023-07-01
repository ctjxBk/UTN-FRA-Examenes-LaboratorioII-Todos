using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmSerializacion : Form
    {

        //no modificar
        public FrmSerializacion()
        {
            InitializeComponent();
        }

        //no modificar
        private void ActualizarComponentesFormulario(string texto)
        {
            lb_mensaje.Text = texto;
            lb_mensaje.Visible = true;
            btn_deserializar.Enabled = false;
        }


        //
        private void btn_Serializar_Click(object sender, EventArgs e)
        {
            string rutaFile = string.Empty;
            Empleado empleado = GeneradorDeDatos.GetEmpleado;

            rutaFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RSP_2022\\";

            //desarrollar
            try
            {
                if (!Directory.Exists(rutaFile))
                {
                    Directory.CreateDirectory(rutaFile);
                }
                Serializador<Empleado>.Escribir(empleado, rutaFile, "empleado-agustin-c.json", ActualizarComponentesFormulario);
                MessageBox.Show("Se serializo correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

    }
}
