using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Comercio comercio;
        private string ultimoArchivo;
        private static string path;
        private List<string> rutasDeImportacion;
               

        public void ActualizarRutas(string ruta)
        {
            if(this.rutasDeImportacion.Count == 10)
            {
                this.rutasDeImportacion.RemoveAt(9);
            }
            this.rutasDeImportacion.Insert(0, ruta);
        }

        public string ObtenerRutas()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string ruta in this.rutasDeImportacion)
            {
                sb.AppendLine(ruta);
            }
            return sb.ToString();
        }

        static FrmAtencion()
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
        }
        
        public FrmAtencion()
        {
            InitializeComponent();
            this.comercio = new Comercio();
            this.rutasDeImportacion = new List<string>();
        }

        public void GuardarRutasEnArchivo()
        {
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(path, "recientes.txt")))
            {
                streamWriter.Write(this.ObtenerRutas());
            }
        }

        public void CargarRutasEnArchivos()
        {
            using (StreamReader streamReader = new StreamReader(Path.Combine(path, "recientes.txt")))
            {
                string line;
                List<string> nuevasRutas = new List<string>();
                while ((line = streamReader.ReadLine()) != null)
                {
                    nuevasRutas.Add(line);
                }
                this.rutasDeImportacion = nuevasRutas;
            }
        }
        

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ultimoArchivo = openFileDialog.FileName;
                    this.comercio.LoadBackup(UltimoArchivo);

                    //punto 14
                    this.ActualizarRutas(ultimoArchivo);
                    this.GuardarRutasEnArchivo();
                }
                catch (Exception ex)
                {
                    MensajeError(ex);
                }
            }
        }

        private void MensajeError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFileDialog.ShowDialog();
            try
            {
                UltimoArchivo = SeleccionarUbicacionGuardado();
                this.comercio.SaveBackup(UltimoArchivo);
            }
            catch(Exception ex) 
            {
                MensajeError(ex);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente frm = new FrmAgregarCliente();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                Cliente cliente = new Cliente(frm.NombreCliente);
                if(this.comercio + cliente)
                {
                    //MessageBox.Show("Se Agrego el cliente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se Agrego el cliente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            //DEBUG
            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comercio.xml");
            //this.comercio.SaveBackup(path);
            //MessageBox.Show(path);

            int clientesAntes = this.comercio.Clientes.Count;
            FrmSimularAtencion frm = new FrmSimularAtencion(this.comercio);
            frm.ShowDialog();
            int clientesDespues = this.comercio.Clientes.Count;
            try
            {
                EstadisticasDAO.Guardar(clientesAntes - clientesDespues);
            }
            catch (Exception ex)
            {
                MensajeError(ex);
            }
        }


        private string UltimoArchivo
        {
            get
            {
                if (string.IsNullOrEmpty(ultimoArchivo))
                {
                    return path;
                }
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ultimoArchivo = value;
                }
            }
        }

        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            //DEBUG
            this.CargarRutasEnArchivos();
        }

        public void ImportarDeRutaEspecificaRecientes(object sender, EventArgs e)
        {
            string rutaEspecifica = ((ToolStripMenuItem)sender).Text;
            if (File.Exists(rutaEspecifica))
            {
                this.comercio.LoadBackup(rutaEspecifica);
            }
            else
            {
                MessageBox.Show($"path: {rutaEspecifica}", "La ruta no existe en esta computadora",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void abrirRecienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("Esta seguro de abrir recientes", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.CargarRutasEnArchivos();
                    this.abrirRecienteToolStripMenuItem.DropDownItems.Clear();
                    int contador = 0;
                    foreach (string ruta in this.rutasDeImportacion)
                    {
                        ToolStripItem aux = new ToolStripMenuItem();
                        aux.Text = ruta;
                        this.abrirRecienteToolStripMenuItem.DropDownItems.Add(aux);
                        this.abrirRecienteToolStripMenuItem.DropDownItems[contador].Click += ImportarDeRutaEspecificaRecientes;
                        

                        //ultima linea del for
                        contador++;
                    }
                    
                }
                catch (Exception ex)
                {
                    MensajeError(ex);
                }
            }
        }
    }
}
