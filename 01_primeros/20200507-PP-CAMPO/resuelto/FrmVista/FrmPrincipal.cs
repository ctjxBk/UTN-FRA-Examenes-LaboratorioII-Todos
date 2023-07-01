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

namespace FrmVista
{
    public partial class Campo : Form
    {
        public Entidades.Campo campo;
        public Campo()
        {
            InitializeComponent();
            this.campo = new Entidades.Campo(1500);
        }

        private void Campo_Load(object sender, EventArgs e)
        {

            Entidades.Campo.TipoServicio = Entidades.Campo.Tipo.Pastoreo;
            bool pudo = this.campo + new Cerdo("Pegy", 300);
            pudo = this.campo + new Cerdo("Babe", 250);
            pudo = this.campo + new Vaca("Rosalinda", 450, Vaca.Clasificacion.Lechera);
            pudo = this.campo + new Vaca("Lola", 325);
            pudo = this.campo + new Caballo("Secretariat", 175, true);
            if (!(this.campo + new Caballo("BoJack", 1, false)))
            {
                MessageBox.Show("No hay alimento", "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnMostrarEstado_Click(object sender, EventArgs e)
        {
            this.rtbSalidaDeTest.Text = this.campo.ToString();
        }
    }
}
