using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaFrm
{
    public partial class FormArchivos : Form
    {

        DiscoElectronico electronico;
        ArchiveroFisico fisico;

        public FormArchivos()
        {
            InitializeComponent();
        }

        //a.En el evento Load del formulario instanciar el DiscoElectrónico y el ArchiveroFísico del Form con capacidad para 3 archivos c/uno.
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.electronico = new DiscoElectronico(3);
                this.electronico.CancelarHilo = new CancellationTokenSource();
                this.electronico.MostrarInfo += this.MostrarArchivo;
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
            try
            {
                this.fisico = new ArchiveroFisico(3);
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }

        private void MostrarError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
            sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

            int contador = 1;
            //sb.AppendLine($"Error nº{contador}: {ex.Message}");

            Exception inner = ex;
            while (inner != null)
            {
                sb.AppendLine($"Error nº{contador}: {inner.Message}");
                inner = inner.InnerException;
                contador++;
            }
            
            MessageBox.Show(sb.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        //instanciar un archivo a partir de los datos obtenidos de los controles del formulario.
        //Agregar el archivo a la lista del DiscoElectrónico siempre y cuando haya capacidad.
        //Si se pudo agregar a la lista, guardarlo también en la base de datos.
        //Finalmente limpiar el contenido de los controles del formulario.
        private void btnAlmacenarElectronico_Click(object sender, EventArgs e)
        {
            //Código Alumno
            Archivo archivo = new Archivo(this.txtNombreArchivo.Text, this.rtbContenido.Text);

            try
            {
                if(this.electronico + archivo)
                {
                    this.electronico.Guardar(archivo);
                }
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }

            this.txtNombreArchivo.Text = "";
            this.rtbContenido.Text = "";
        }

        //Instanciar un archivo a partir de los datos obtenidos de los controles del formulario.
        //Guardarlo en un archivo de texto
        //Finalmente limpiar el contenido de los controles del formulario.
        private void btnAlmacenarFisico_Click(object sender, EventArgs e)
        {
            //Código Alumno
            Archivo archivo = new Archivo(this.txtNombreArchivo.Text, this.rtbContenido.Text);
            try
            {
                this.fisico.Guardar(archivo);
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }

            this.txtNombreArchivo.Text = "";
            this.rtbContenido.Text = "";
        }

        //Asociar el manejador del formulario MostrarArchivo al evento MostrarInfo de la clase DiscoElectronico.
        //Ejecutar en un hilo el método MostrarArchivos de la clase DiscoElectronico.
        private void btnLeerElectronico_Click(object sender, EventArgs e)
        {
            //sique que hay que asociar el evento acá. PERO se debe asociar una sola vez
            // por lo cual lo hare en el manejador Load de este Formulario
            //this.electronico.MostrarInfo += this.MostrarArchivo;
            Task.Run(() => {
                this.electronico.MostrarArchivos();
            });
        }

        public void MostrarArchivo(string info)
        {
            MessageBox.Show(info);
        }

        //En el manejador del botón LeerFisico se deberá, a partir del nombre ingresado en 
        //txtNombreArchivo, recuperar el contenido del archivo y mostrarlo en el rtbContenido.
        private void btnLeerFisico_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtNombreArchivo.Text))
                {
                    MessageBox.Show("Por favor ponga un nombre al archivo que quiere leer", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.rtbContenido.Text = this.fisico.Leer(this.txtNombreArchivo.Text);
                }
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }

        //Antes de cerrar, en el evento FormClosing, abortar el hilo del formulario en caso de que siga vivo.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.electronico?.CancelarHilo.Cancel();
        }
    }
}
