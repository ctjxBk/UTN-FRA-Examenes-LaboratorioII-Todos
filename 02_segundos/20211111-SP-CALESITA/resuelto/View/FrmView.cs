using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using System.Threading.Tasks;
using System.Threading;

namespace View
{
    public partial class FrmView : Form
    {
        private const string archivoPath = "carrusel.json";
        private List<Juego> juegos;
        private bool ejecutando;
        private JsonFiler<List<Juego>> json;
        private CancellationTokenSource cancelTask;
        
        public FrmView()
        {
            InitializeComponent();

            this.ejecutando = false;

            this.juegos = new List<Juego>();
            this.json = new JsonFiler<List<Juego>>();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            this.numericUpDownVelocidad.Minimum = 2;
            this.numericUpDownVelocidad.Maximum = 8;
            this.numericUpDownVelocidad.Value = this.numericUpDownVelocidad.Maximum;

            // Leo mis juegos del archivo
            try
            {
                if (this.json.ExisteArchivo(FrmView.archivoPath))
                {
                    this.json.Leer(FrmView.archivoPath, out juegos);
                }
            }
            catch (ErrorArchivosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Text = "Nombre y apellido del alumno";

            this.InitializeJuegos();

            foreach (Juego p in this.juegos)
            {
                // Asociar Evento
                p.InformarAvance += this.AvanceJuegos;

                PictureBox pic = (PictureBox)p.ControlVisual;
                pic.Location = this.CalcularUbicacion(pic.Location, p.Ubicacion);
                this.Controls.Add(pic);
            }
        }

        private void FrmView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FinalizarTasks();

            // Guardo mis juegos del archivo
            try
            {
                this.json.Guardar(archivoPath, juegos);
            }
            catch (ErrorArchivosException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (!this.ejecutando)
            {
                new Juego().Velocidad = (short)this.numericUpDownVelocidad.Value;

                // Iniciar hilos
                this.cancelTask = new CancellationTokenSource();
                foreach (Juego juego in this.juegos)
                {
                    juego.CancelTask = this.cancelTask;
                    //Task.Run(juego.IniciarCarrusel);
                    Task task = new Task(juego.IniciarCarrusel);
                    task.Start();
                }


                this.btnSimular.Text = "Detener";
                this.ejecutando = true;
            }
            else
            {
                this.FinalizarTasks();
                this.btnSimular.Text = "Iniciar";
                
            }

        }

        private void InitializeJuegos()
        {
            // Creo mis juegos
            if (this.juegos.Count == 0)
            {
                new Juego().Velocidad = 10;

                Juego juego = new Juego(0, this.picHorse1);
                this.juegos.Add(juego);
                juego = new Juego(45, this.picHorse2);
                this.juegos.Add(juego);
                juego = new Juego(90, this.picHorse3);
                this.juegos.Add(juego);
                juego = new Juego(135, this.picHorse4);
                this.juegos.Add(juego);
                juego = new Juego(180, this.picHorse5);
                this.juegos.Add(juego);
                juego = new Juego(225, this.picHorse6);
                this.juegos.Add(juego);
                juego = new Juego(270, this.picHorse7);
                this.juegos.Add(juego);
                juego = new Juego(315, this.picHorse8);
                this.juegos.Add(juego);

            }
            else
            {
                this.juegos[0].ControlVisual = this.picHorse1;
                this.juegos[1].ControlVisual = this.picHorse2;
                this.juegos[2].ControlVisual = this.picHorse3;
                this.juegos[3].ControlVisual = this.picHorse4;
                this.juegos[4].ControlVisual = this.picHorse5;
                this.juegos[5].ControlVisual = this.picHorse6;
                this.juegos[6].ControlVisual = this.picHorse7;
                this.juegos[7].ControlVisual = this.picHorse8;
            }
        }

        /// <summary>
        /// necesario para pasar de grados a radianes, para poder operar con las funciones de seno y coseno
        /// </summary>
        /// <param name="grados"></param>
        /// <returns></returns>
        public static double GradosARadianes(short grados)
        {
            return grados * (Math.PI / 180);
        }

        private Point CalcularUbicacion(Point posicion, short avance)
        {
            int x = 0;
            int y = avance;
            int radio = 200;

            x = picCarrousel.Location.X + (int)Math.Round(Math.Cos(GradosARadianes(avance)) * radio);
            y = picCarrousel.Location.Y + (int)Math.Round(Math.Sin(GradosARadianes(avance)) * radio);

            return new Point(x, y);
        }

        private void FinalizarTasks()
        {
            if (this.ejecutando)
            {
                // Cancelar hilos
                this.cancelTask.Cancel();
                this.ejecutando = false;
            }
        }

        private void AvanceJuegos(object sender, short movimiento)
        {
            if (this.InvokeRequired)
            {
                InformacionDeAvance delegado = AvanceJuegos;
                object[] parametros = new object[] {sender, movimiento};
                this.Invoke(delegado, parametros);
            }
            else
            {
                
                //PictureBox pic = (PictureBox)((Juego)sender).ControlVisual;
                PictureBox pic = (PictureBox)sender;
                
                //Invocación del hilo principal
                pic.Location = this.CalcularUbicacion(pic.Location,movimiento);
            }
        }
    }
}
