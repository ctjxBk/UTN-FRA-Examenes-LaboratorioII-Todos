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
    public partial class Receta : Form
    {
        Entidades.Receta receta;
        public Receta()
        {
            InitializeComponent();
            //para no tener warning la receta la instancio en este constructor en lugar del evento Load
            this.receta = new Entidades.Receta(45);
        }

        private void Receta_Load(object sender, EventArgs e)
        {
            bool pudo = this.receta + new Rucula("Eruca sativa", 10);
            pudo = this.receta + new Rucula("Diplotaxis muralis", 15);
            pudo = this.receta + new QuesoAzul("Roquefort", 3, QuesoAzul.Procedencia.Francia);
            pudo = this.receta + new QuesoAzul("Clásico", 5);
            pudo = this.receta + new Pera("Dulce", 12, "Williams");
            //hay que negarlo. esta mal como lo marca el enunciado
            if (!(this.receta + new Pera("Seca", 1, "Blanquilla")))
            {
                MessageBox.Show("No se puede agregar otro ingrediente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnImprimirReceta_Click(object sender, EventArgs e)
        {
            this.rtbSalidaDeTest.Text = this.receta.ToString();
        }
    }
}
