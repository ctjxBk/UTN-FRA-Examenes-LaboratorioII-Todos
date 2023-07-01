using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;



namespace _20210717_RSP___alumno
{
    public partial class FrmCarrera : Form
    {
        private Carrera carrera;
        private Task tarea;
        private AutoF1 v1;
        private AutoF1 v2;

        public FrmCarrera()
        {
            InitializeComponent();
            this.pcbAutoUno.Image = this.imgListAutos.Images[0];
            this.pcbAutoDos.Image = this.imgListAutos.Images[0];
        }

        private void InitializeAutosYCarrera()
        {
            Random random = new Random();
            this.v1 = new AutoF1("Ferrari", random.Next(5, 20), this.pcbAutoUno.Location.X);
            Thread.Sleep(2000);//pongo un sleep para el random
            this.v2 = new AutoF1("Renault", random.Next(5, 20), this.pcbAutoDos.Location.X);

            this.carrera = new Carrera(this.Size.Width); //instancion la carrera y le envio el maximo del form

            //Agrego vehiculos a la carrera
            this.carrera += v1;
            this.carrera += v2;

        }

        private void FrmCarrera_Shown(object sender, EventArgs e)
        {
            //cuando se muestra el FRM instancio el Hilo y lo inicio
            this.tarea = Task.Run(() =>
            {
                //try
                //{
                    this.carrera.IniciarCarrera();
                //}
                //catch(Exception ex)
                //{
                //    this.ErrorEnHiloSecundario(ex.Message);
                //}
            });
        }

        private void ErrorEnHiloSecundario(string mensaje)
        {
            if (this.InvokeRequired)
            {
                Action<string> metodo = this.ErrorEnHiloSecundario;
                object[] parametros = new object[] { mensaje };
                this.Invoke(metodo, parametros);
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Dibujar avance de Auto segun su nueva ubicacion
        /// </summary>
        /// <param name="avanzar"></param>
        private void AvanzarAuto()
        {
            //Alumno:Metodo que maneja el evento InformarAvance
            if (this.InvokeRequired)
            {
                //Action metodo = AvanzarAuto;
                InformacionAvance metodo = AvanzarAuto;
                object[] parametros = new object[] { };
                this.Invoke(metodo, parametros);
            }
            else
            {
                this.pcbAutoUno.Location = new Point(this.v1.UbicacionEnPista, this.pcbAutoUno.Location.Y);
                this.pcbAutoDos.Location = new Point(this.v2.UbicacionEnPista, this.pcbAutoDos.Location.Y);
            }
            
           
        }

        private void FrmCarrera_Load(object sender, EventArgs e)
        {
            this.InitializeAutosYCarrera();
            //Alumno:Metodo donde se agregaran los manejadores al evento de carrera
            this.carrera.InformarAvance += this.AvanzarAuto;
            this.carrera.InformarLlegada += this.ImprimirMensaje;
            this.carrera.MensajeError += this.ErrorEnHiloSecundario;
        }

        /// <summary>
        /// Imprime los mensajes de llegada
        /// </summary>
        /// <param name="mensaje"></param>
        private void ImprimirMensaje(string mensaje)
        {
            //Alumno:Metodo que maneja el evento InformarLlegada
            if (this.InvokeRequired)
            {
                //Action<string> metodo = ImprimirMensaje;
                InformacionLlegada metodo = ImprimirMensaje;
                object[] parametros = new object[] { mensaje };
                this.Invoke(metodo, parametros);
            }
            else
            {
                MessageBox.Show(mensaje, "Llegadas", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void FrmCarrera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.tarea.IsCompleted)
            {
                this.DialogResult = DialogResult.OK; //Establezco el resultado en OK para finalizar el primer FORM
                //Alumno:serializar carrera
                GestorDeArchivos gestorDeArchivos = new GestorDeArchivos("carreras.xml");
                gestorDeArchivos.Guardar(carrera);
            }
            else
            {
                e.Cancel = true;
            }


        }
    }
}
