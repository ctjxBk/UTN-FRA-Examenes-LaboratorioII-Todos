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

namespace FormVista
{
    public partial class FrmPickup : Form
    {
        public FrmPickup()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string patente = txtPatente.Text;
            string modelo = txtModelo.Text;
            PickUp pickup = new PickUp(patente, modelo);
            MessageBox.Show(pickup.ConsultarDatos(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
