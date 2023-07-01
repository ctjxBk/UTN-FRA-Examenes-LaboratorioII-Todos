using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FrmAtencion : Form
    {
        Comercio comercio;
        static int atendidos;

        public static int Atendidos { get => atendidos; set => atendidos = value; }

        public FrmAtencion()
        {
            InitializeComponent();
            FrmSimularAtencion.ActualizarBD += Guardar;
            comercio = new Comercio();

        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Filter = "Clientes Bk (*.xml) | *.xml";
           
              
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    comercio.Ruta = openFileDialog.OpenFile();

                    comercio.LoadBackup();




                }
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog1.Filter = "Clientes Bk (*.xml) | *.xml";
          
            saveFileDialog1.RestoreDirectory = true;
          
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                comercio.Ruta = saveFileDialog1.OpenFile();
                comercio.SaveBackup();
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente frm = new FrmAgregarCliente();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(frm.textBox1.Text);
                comercio += new Cliente(frm.textBox1.Text);
                
            }

            

        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            FrmSimularAtencion frm = new FrmSimularAtencion(comercio);
            frm.Show();

        }
        private void Guardar()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@" Server = .\SQLEXPRESS01 ; Database = 20210706-SP ; Trusted_Connection = true ; "))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    int noAtendidos = new Random().Next(Atendidos);
                    command.CommandText = $"INSERT INTO atenciones (atendidos, noAtendidos, alumno) VALUES(@atendido, @noatendido, @alum) ";
                    command.Parameters.AddWithValue("@atendido", Atendidos - noAtendidos);
                    command.Parameters.AddWithValue("@noatendido", noAtendidos);
                    command.Parameters.AddWithValue("@alum", 1);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void abrirRecienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
