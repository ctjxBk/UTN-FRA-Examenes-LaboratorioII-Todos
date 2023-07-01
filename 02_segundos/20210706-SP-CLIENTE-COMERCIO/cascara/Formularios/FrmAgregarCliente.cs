using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmAgregarCliente : Form
    {
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        public string NombreCliente
        {
            get
            {
                return this.lblNombreCliente.Text;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblNombreCliente.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("El nombre no puede estar vacio", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
        }
    }
}
