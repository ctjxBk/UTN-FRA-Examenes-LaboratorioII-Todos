using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Audio;

namespace _20201203
{
    public partial class D10S : Form
    {
        private int estado;
        private GolDelSiglo golDelSiglo;
        private GestionarArchivosTextoPlano gestionarTexto;
        private GestionarBaseDeDatos gestionarBBDD;

        public D10S()
        {
            InitializeComponent();


            this.golDelSiglo = new GolDelSiglo();
            this.golDelSiglo.mostrarError += this.MostrarError;
            Relato.Avanzar += this.MostrarGrafico;
            Relato.Guardar += this.Guardar;
            this.gestionarTexto = new GestionarArchivosTextoPlano();
            this.gestionarBBDD = new GestionarBaseDeDatos();

            //debug
            //MessageBox.Show(pic5.UltimoCaracter());
        }

        private void MostrarGrafico()
        {
            
            if (this.InvokeRequired)
            {
                AvanceRelato metodo = this.MostrarGrafico;
                object[] parametros = new object[] { };
                this.Invoke(metodo, parametros);
            }
            else
            {
                /*
                if(estado.ToString() == pic1.UltimoCaracter())
                {
                    this.picFondo.Visible = false;
                }
                else if(estado.ToString() == pic2.UltimoCaracter())
                {
                    pic1.Visible = true;
                }
                else if(estado.ToString() == pic3.UltimoCaracter())
                {
                    pic1.Visible = false;
                    pic2.Visible = true;
                }
                else if(estado.ToString() == pic4.UltimoCaracter())
                {
                    pic2.Visible = false;
                    pic3.Visible = true;
                }
                else if (estado.ToString() == pic5.UltimoCaracter())
                {
                    pic3.Visible = false;
                    pic4.Visible = true;
                }
                else if (estado == 6)
                {
                    pic4.Visible = false;
                    pic5.Visible = true;
                }
                else if (estado == 7)
                {
                    pic5.Visible = false;
                    this.picFondo.Visible = true;
                    this.picFondo.Visible = true;
                    estado--;
                }*/

                
                switch (estado)
                {
                    case 1://.SePrepara:
                        this.picFondo.Visible = false;
                        break;
                        
                    case 2://.LaTieneMaradona:
                        pic1.Visible = true;
                        break;
                    case 3://.ArrancaConLaPelota:
                        pic1.Visible = false;
                        pic2.Visible = true;
                        break;
                    case 4://.DejaElTendal:
                        pic2.Visible = false;
                        pic3.Visible = true;
                        break;
                    case 5://.VaATocarPara:
                        pic3.Visible = false;
                        pic4.Visible = true;
                        break;
                    case 6://.Gooool:
                        pic4.Visible = false;
                        pic5.Visible = true;
                        break;
                    case 7://.Festeja:
                        pic5.Visible = false;
                        this.picFondo.Visible = true;
                        this.picFondo.Visible = true;
                        estado--;
                        break;
                        
                }
                estado++;
                
            }
        }

        private void btnGolDelSiglo_Click(object sender, EventArgs e)
        {
            this.golDelSiglo.IniciarJugada();
        }

        private void Guardar()
        {
            if (this.InvokeRequired)
            {
                Action metodo = Guardar;
                this.Invoke(metodo);
            }
            else
            {
                try
                {
                    gestionarTexto.Guardar($"Se disfrutó el gol del siglo a las {DateTime.Now.Hour}:{DateTime.Now.Minute} hs");
                    MessageBox.Show("Se guardo en el texto plano log.txt");
                }
                catch (ExcepcionPersonalizada ex)
                {
                    this.MostrarError(ex);
                }
                try
                {
                    gestionarBBDD.Guardar($"Se disfrutó el gol del siglo a las {DateTime.Now.Hour}:{DateTime.Now.Minute} hs");
                    MessageBox.Show("Se guardo en la base de datos [20201203-sp]");
                }
                catch (ExcepcionPersonalizada ex)
                {
                    this.MostrarError(ex);
                }
            }
        }

        private void D10S_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else// la respuesta es si. si quiere salir...
            {
                this.golDelSiglo.CerrarApp();
                
            }
        }

        private void MostrarError(Exception ex)
        {
            string mensaje = String.Empty;
            if(ex.InnerException != null)
            {
                mensaje = $"{ex.Message}{Environment.NewLine}{ex.InnerException.Message}";
            }
            else
            {
                mensaje = ex.Message;
            }
            MessageBox.Show(mensaje,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void MostrarLista(List<string> lista, string donde)
        {
            StringBuilder sb = new StringBuilder();
            if(lista.Count == 0)
            {
                sb.AppendLine($"No hay nada {donde}");
            }
            else
            {
                foreach (string item in lista)
                {
                    sb.AppendLine(item);
                }
            }
            MessageBox.Show(sb.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLeerLogTextoPlano_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lista = new List<string>();
                lista = this.gestionarTexto.Leer();
                this.MostrarLista(lista, " en el texto plano log.txt");

            }
            catch (ExcepcionPersonalizada ex)
            {
                this.MostrarError(ex);
            }
        }

        private void btnLeerLogBaseDeDatos_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lista = new List<string>();
                lista = this.gestionarBBDD.Leer();
                this.MostrarLista(lista, " en la base de datos [20201203-sp]");
            }
            catch (ExcepcionPersonalizada ex)
            {
                this.MostrarError(ex);
            }
        }
    }
}
