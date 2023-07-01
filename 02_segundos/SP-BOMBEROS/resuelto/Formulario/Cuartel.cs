using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Formulario
{
    public partial class Cuartel2 : Form
    {
        //11:20
        private List<Bombero> bomberos;
        private List<PictureBox> fuegos;
        private CancellationTokenSource cancelTask;
        public Cuartel2()
        {
            InitializeComponent();

            fuegos = new List<PictureBox>();
            fuegos.Add(fuego1);
            fuegos.Add(fuego2);
            fuegos.Add(fuego3);
            fuegos.Add(fuego4);
            
            this.cancelTask = new CancellationTokenSource();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            bomberos = new List<Bombero>();
            Bombero b1 = new Bombero("M. Palermo");
            b1.MarcarFin += FinalDeSalida;
            bomberos.Add(b1);
            Bombero b2 = new Bombero("G. Schelotto");
            b2.MarcarFin += FinalDeSalida;
            bomberos.Add(b2);
            Bombero b3 = new Bombero("C. Tevez");
            b3.MarcarFin += FinalDeSalida;
            bomberos.Add(b3);
            Bombero b4 = new Bombero("F. Gago");
            b4.MarcarFin += FinalDeSalida;
            bomberos.Add(b4);
            
        }
        #region botones
        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            DespacharServicio(0);
        }

        private void btnEnviar2_Click(object sender, EventArgs e)
        {
            DespacharServicio(1);
        }

        private void btnEnviar3_Click(object sender, EventArgs e)
        {
            DespacharServicio(2);
        }

        private void btnEnviar4_Click(object sender, EventArgs e)
        {
            DespacharServicio(3);
        }
#endregion

        private void DespacharServicio(int index)
        {
            try
            {
                VerificarSiBomberoEstaEnSalida(index);
            }
            catch (BomberoOcupadoException ex)
            {
                this.Mensaje(ex);
            }
            fuegos[index].Visible = true;
            Bombero bombero = bomberos[index];
            
            Task task = new Task(() => bombero.AtenderSalida(index), this.cancelTask.Token );
            task.Start();
        }

        private void VerificarSiBomberoEstaEnSalida(int index)
        {
            foreach(Salida salida in this.bomberos[index].Salidas)
            {
                if(salida.FechaFin == default)
                {
                    throw new BomberoOcupadoException("Bombero Ocupado");
                }
            }
        }

        private void OcultarBombero(int bomberoIndex)
        {
            fuegos[bomberoIndex].Visible = false;
        }
        

        private void FinalDeSalida(int bomberoIndex)
        {
            if (this.InvokeRequired)
            {
                FinDeSalida metodo = FinalDeSalida;
                object[] parametros = new object[] { bomberoIndex };  
                this.Invoke(metodo, parametros);
            }
            else
            {
                OcultarBombero(bomberoIndex);
            }
        }

        private void Cuartel2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancelTask.Cancel();
        }

        private void btnReporte1_Click(object sender, EventArgs e)
        {
            bomberos[0].Guardar(bomberos[0]);
        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            bomberos[1].Guardar(bomberos[1]);
        }

        private void btnReporte3_Click(object sender, EventArgs e)
        {
            bomberos[2].Guardar(bomberos[2]);
        }

        private void btnReporte4_Click(object sender, EventArgs e)
        {
            bomberos[3].Guardar(bomberos[3]);
        }

        private void Mensaje(Exception ex)
        {
            MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
