using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Vista
{

    public partial class FrmSerializacion : Form
    {

        public FrmSerializacion()
        {
            InitializeComponent();
        }


        //no cambiar
        private void ActualizarComponentesFormulario(string texto)
        {
            lb_mensaje.Text = texto;
            lb_mensaje.Visible = true;
            btn_deserializar.Enabled = false;
        }

        private void btn_deserializar_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaFile = string.Empty;
                Empleado empleado = GeneradorDeDatos.GetEmpleadoAleatorio;

                rutaFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RSP_2022\\";

                // desarrollar
                if (!Directory.Exists(rutaFile))
                {
                    Directory.CreateDirectory(rutaFile);
                }

                Serializador<Empleado>.Escribir(empleado, rutaFile, "agustin-c.json", this.ActualizarComponentesFormulario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
