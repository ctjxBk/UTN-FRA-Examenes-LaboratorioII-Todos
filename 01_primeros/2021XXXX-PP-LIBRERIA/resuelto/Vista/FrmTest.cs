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
    public partial class FrmTest : Form
    {
        private Vendedor vendedor;
        public FrmTest()
        {
            InitializeComponent();
            this.vendedor = new Vendedor("Agustin");
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            Biografia p1 = (Biografia)"Life (Keith Richards)";
            Biografia p2 = new Biografia("White line fever (Lemmy)", 5);
            Biografia p3 = new Biografia("Commando (Johnny Ramone)", 2, 5000);
            Comic p4 = new Comic("La Muerte de Superman (Superman)", true, 1, 1850);
            Comic p5 = new Comic("Año Uno (Batman)", false, 3, 1270);


            this.lstStock.Items.Add(p1);
            this.lstStock.Items.Add(p2);
            this.lstStock.Items.Add(p3);
            this.lstStock.Items.Add(p4);
            this.lstStock.Items.Add(p5);
            this.lstStock.SelectedItem = null;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if(this.lstStock.SelectedItem is not null)
            {
                Publicacion? publicacion = this.lstStock.SelectedItem as Publicacion;
                if(publicacion is not null)
                {
                    bool seVendio = this.vendedor + publicacion;
                    if (seVendio)
                    {
                        MessageBox.Show(publicacion.ObtenerInformacion(),"Información de la venta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo concretar la venta. Podría ser que no hay stock","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Al traer los datos del listBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnVerInforme_Click(object sender, EventArgs e)
        {
            this.rtbInforme.Text = Vendedor.ObtenerInformeDeVentas(vendedor);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void FrmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿ Quiere Salir ?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
