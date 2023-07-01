using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmSerializacionDeserializacion : Form
    {

        public FrmSerializacionDeserializacion()
        {
            InitializeComponent();
        }

        private void FrmSerializacionDeserializacion_Load(object sender, EventArgs e)
        {
            dt_informacion.Visible = false;
        }

        // no modificar metodo
        private void ActualizarComponentesFormulario(string texto)
        {
            lb_mensaje.Text = texto;
            lb_mensaje.Visible = true;
            dt_informacion.Visible = true;
            btn_deserializar.Enabled = false;
        }


        private void btn_deserializar_Click(object sender, EventArgs e)
        {
            string rutaFile = string.Empty;

            OpenFileDialog buscadorArchivos = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Buscar archivo Json a deserializar",
                DefaultExt = "json",
                Filter = "json files (*.json)|*.json"
            };

            if (buscadorArchivos.ShowDialog() == DialogResult.OK)
            {
                rutaFile = buscadorArchivos.FileName;

                //completar


            }
            else
            {
                MessageBox.Show("Accion Cancelada por el usuario");
            }
        }

    }
}
