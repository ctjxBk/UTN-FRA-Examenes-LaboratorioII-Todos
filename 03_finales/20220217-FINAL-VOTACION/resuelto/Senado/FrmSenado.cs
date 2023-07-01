using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CoreLibraries;

namespace Senado
{
    public partial class FrmSenado : Form
    {
        Parlamento<Senador> parlamento;
        public FrmSenado()
        {
            InitializeComponent();

            this.parlamento = new Parlamento<Senador>(this.CrearSenador("P", 160, 382));
            
            this.parlamento.OcupaBanca += this.CambioPresentismo;
            this.parlamento.ParlamentariosRegistrados += this.FinCambioPresentismo;
            this.parlamento.VotoEmitido += this.RegistrarVoto;
            this.parlamento.FinVotacion += this.FinalizaVotacion;
            this.parlamento.MostrarError += this.MostrarError;
        }

        private void MostrarError(Exception ex)
        {

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
            sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

            int contador = 0;

            Exception inner = ex;
            while (inner != null)
            {
                contador++;
                sb.AppendLine($"Error nº{contador}: {inner.Message}");
                inner = inner.InnerException;
            }
            sb.AppendLine($"{Environment.NewLine}------------------------------------{Environment.NewLine}");

            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void FrmSenado_Load(object sender, EventArgs e)
        {
            int top = 125;
            int left;
            int cont = 1;

            for (int i = 1; i <= 4; i++)
            {
                left = 172 - (35 * i);
                for (int j = 1; j < 14 + (i * 2); j++)
                {
                    this.AgregarSenador(cont.ToString(), top, left);

                    left += 35;
                    cont++;
                }
                top -= 35;
            }
        }

        private Senador CrearSenador(string cod, int top, int left)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Location = new Point(left, top);
            label.Name = "label" + cod;
            label.Size = new Size(30, 30);
            label.ForeColor = Color.White;
            label.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label.TabIndex = 0;
            label.Text = cod;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.DarkBlue;

            this.Controls.Add(label);

            return new Senador(cod, label);
        }

        private void AgregarSenador(string cod, int top, int left)
        {
            Senador senador = this.CrearSenador(cod, top, left);
            this.parlamento.Bancas.Add(senador);
        }

        public void CambioPresentismo(Senador banca)
        {
            if (this.InvokeRequired)
            {
                Action<Senador> metodo = CambioPresentismo;
                this.Invoke(metodo, banca);
            }
            else
            {
                Label label = (Label)banca.ControlVisual;

                label.BackColor = banca.ColorDeBanca;
            }
        }

        public void FinCambioPresentismo()
        {
            if (this.InvokeRequired)
            {
                Action metodo = this.FinCambioPresentismo;
                this.Invoke(metodo);
            }
            else
            {
                this.btnActivarSesion.Enabled = true;
                this.btnVotar.Enabled = true;
            }
                
        }

        public void RegistrarVoto(Senador banca)
        {
            if (this.InvokeRequired)
            {
                Action<Senador> metodo = RegistrarVoto;
                this.Invoke(metodo, banca);
            }
            else
            {
                Label label = (Label)banca.ControlVisual;

                label.BackColor = banca.ColorDeBanca;
            }
        }

        public void FinalizaVotacion()
        {
            if (this.InvokeRequired)
            {
                Action metodo = FinalizaVotacion;
                this.Invoke(metodo);
            }
            else
            {
                this.btnActivarSesion.Enabled = true;
                this.btnVotar.Enabled = true;

                lblAfirmativos.Text = this.parlamento.VotosAfirmativos.ToString();
                lblNegativos.Text = this.parlamento.VotosNegativos.ToString();
                lblAbstenciones.Text = this.parlamento.VotosAbstenciones.ToString();
            }
        }

        private void btnActivarSesion_Click(object sender, EventArgs e)
        {
            this.btnActivarSesion.Enabled = false;
            this.btnVotar.Enabled = false;
            this.parlamento.EstadioSesion = true;
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            this.btnActivarSesion.Enabled = false;
            this.btnVotar.Enabled = false;
            this.parlamento.IniciarVotacion();
        }

        private void FrmSenado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parlamento.CancelarVotacion();
        }
    }
}
