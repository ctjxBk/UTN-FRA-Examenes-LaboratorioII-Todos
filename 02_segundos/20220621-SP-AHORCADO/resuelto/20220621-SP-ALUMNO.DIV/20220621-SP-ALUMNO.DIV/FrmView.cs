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
using Entidades.Exceptions;
using Entidades.Files;
using Entidades.Models;

namespace _20220621_SP_ALUMNO.DIV
{

    public partial class FrmView : Form
    {
        Ahorcado<Pais> ahorcado;

        public FrmView()
        {
            InitializeComponent();
            InicializarAbecedario();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            //Alumnos: Instanciar Ahoracado y agregar manejadores
            this.ahorcado = new Ahorcado<Pais>();
            this.ahorcado.OnPalabra = this.MostrarPalabra;
            this.ahorcado.OnTemporizador = this.MostrarConteo;
            //AGREGO. No lo pedia
            this.ahorcado.OnMensaje = this.Mensaje;
            this.ahorcado.OnMensajeErrorOtroHilo = this.MensajeErrorOtroHilo;

            this.lblPalabraSecreta.Text = string.Empty;
            this.lblPalabraIngresada.Text = string.Empty;
        }

        //AGREGO. No lo pedia
        private void Activar()
        {
            if (this.ahorcado.Activar)
            {
                this.ahorcado.Activar = false;
                this.btnIniciar.Text = "Activar";
            }
            else
            {
                this.ahorcado.Activar = true;
                this.btnIniciar.Text = "Desactivar";

            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Activar();
        }

        //Alumno: Realizar los cambios necesarios sobre Mostrar conteo de manera que se refleje
        //en el formulario el tiempo restante de cada iteracion del juego
        private void MostrarConteo(int segundo)
        {
            
            if (this.InvokeRequired)
            {
                DelegadoTemporizador metodo = MostrarConteo;
                object[] parametros = new object[] { segundo };
                this.Invoke(metodo, segundo);
            }
            else
            {
                this.lblTiempo.Text = $"Tiempo Restante: {segundo}";

            }

        }
        //AGREGO. No lo pedia
        private void Mensaje(string mensaje, bool bandera)
        {
            if (this.InvokeRequired)
            {
                Action<string,bool> metodo = Mensaje;
                object[] parametros = new object[] { mensaje, bandera };
                this.Invoke(metodo, parametros);
            }
            else
            {
                if (bandera)
                {
                    this.Activar();
                }
                MessageBox.Show(mensaje);
            }
        }

        //Alumno: Realizar los cambios necesarios sobre Mostrar Palabra de manera que se refleje
        //en el fomrulario la palabra secreta y la cantidad de intentos para esta.
        private bool MostrarPalabra(string palabra)
        {

            if (this.InvokeRequired)
            {
                DelegadoNuevaPalabra metodo = MostrarPalabra;
                object[] parametros = new object[] { palabra };
                this.Invoke(metodo, palabra);
            }
            else
            {
                try
                {
                    this.lblPalabraSecreta.Text = $"{palabra[0]}{string.Concat(Enumerable.Repeat(" _ ", (palabra.Length - 2)))}{palabra[palabra.Length - 1]}";
                    this.lblPalabraIngresada.Text = string.Empty;
                    this.lblIntentos.Text = $"Intentos: {this.ahorcado.CantidadIntentosPorPalabra}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }

            //esto lo agrego porque modifique la firma. Para que haga match con el delegado del evento
            //la otra opcion es modificar el delegado y su evento asociado
            return true;

        }

        private void MensajeErrorOtroHilo(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblPalabraIngresada.Text = string.Empty;
        }
        //Alumno: Serializar la clase Ahorcado antes de cerrar el formulario
        private void FrmView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                FileManager.Guardar<Ahorcado<Pais>>(ahorcado, "serializador.json");
            }
            catch (FileManagerException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        #region "No Tocar"
        private void InicializarAbecedario()
        {
            int ejeX = 10;
            int ejeY = 150;
            for (int i = 0; i < 26; i++)
            {
                Button btn = new Button();
                btn.Name = char.ConvertFromUtf32(i + 65);
                btn.Text = char.ConvertFromUtf32(i + 65);
                btn.Size = new Size(64, 64);
                btn.Location = new Point(ejeX, ejeY);
                btn.Click += EventoCaracter;
                if (ejeX + 130 > this.Size.Width)
                {
                    ejeX = 10;
                    ejeY += 65;
                }
                else
                {
                    ejeX += 65;
                }

                this.Controls.Add(btn);
            }
        }

        private void EventoCaracter(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                this.lblPalabraIngresada.Text += btn.Text;
                if (this.ahorcado.AsertarPalabra(this.lblPalabraIngresada.Text))
                {
                    MessageBox.Show("Adivinaste", "Acierto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                this.lblAciertos.Text = $"Aciertos: {this.ahorcado.CantidadDeAciertos}";
                this.lblIntentos.Text = $"Intentos: {this.ahorcado.CantidadIntentosPorPalabra}";
            }
        }


        #endregion


    }
}
