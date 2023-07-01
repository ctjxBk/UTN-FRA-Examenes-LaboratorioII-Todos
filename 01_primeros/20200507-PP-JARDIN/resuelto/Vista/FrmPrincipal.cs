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

namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        public Jardin jardin;
        
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            richTxtInfo.Text = jardin.ToString();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //probar con 5 para que salga el MessageBox
            //this.jardin = new Jardin(5);
            this.jardin = new Jardin(100);
            bool pudo = this.jardin + new Arbusto("Arbusto 1", 10);
            pudo = this.jardin + new Arbusto("Arbusto 2", 15);
            pudo = this.jardin + new Rosal("Rosa 1", 20, Rosal.Color.Amarilla);
            pudo = this.jardin + new Rosal("Rosa clásica", 25);
            pudo = this.jardin + new Banano("Banano ecuador", 30, "ECU001");
            if (!(this.jardin + new Banano("No carga", 1, "ARG028")))
            {
                MessageBox.Show("Error","No hay lugar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
