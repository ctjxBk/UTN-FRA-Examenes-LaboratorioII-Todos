using Entidades;
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

namespace Vista
{
    public partial class Circo : Form
    {
        private Payaso payaso;
        private Serializadora serializadora;
        private List<PictureBox> globos;
        private CancellationTokenSource cancellationTokenSource;
        private Task tarea;

        public bool EstaActivo
        {
            get
            {
                return tarea is not null && 
                    (tarea.Status == TaskStatus.Running ||
                    tarea.Status == TaskStatus.WaitingToRun ||
                    tarea.Status == TaskStatus.WaitingForActivation);;
            }
        }

        public Circo()
        {
            InitializeComponent();

            globos = new List<PictureBox>();
            payaso = new Payaso("Pennywise", new DateTime(2021, 5, 12), "payaso.json");
            serializadora = new Serializadora();

            globos.Add(balloon1);
            globos.Add(balloon2);
            globos.Add(balloon3);
            globos.Add(balloon4);
            globos.Add(balloon5);

        }

        private void RegalarGlobos()
        {
            if (tarea is null || tarea.IsCompleted)
            {
                cancellationTokenSource = new CancellationTokenSource();
                tarea = new Task(() => payaso.Flotar());
            }

            if (!EstaActivo)
            {
                tarea.Start();
            }
        }

        public void Detener()
        {
            if (EstaActivo)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void MostrarGlobos(int index)
        {
            if (InvokeRequired)
            {
                DesplegarGlobos callback = new DesplegarGlobos(MostrarGlobos);
                object[] args = new object[] { index };
                Invoke(callback, args);
            }
            else
            {
                globos[index].Visible = true;
            }
        }

        private void Circo_Load(object sender, EventArgs e)
        {
            payaso.AparecerGlobo += MostrarGlobos;

        }

        private void btnFlotar_Click(object sender, EventArgs e)
        {
            try
            {
                RegalarGlobos();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                if (serializadora.Guardar(payaso))
                {
                    MessageBox.Show("Serializado");
                }
                else
                {
                    MessageBox.Show("No Serializado");
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Circo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea salir?", "Atencion", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            Detener();
        }
    }
}
