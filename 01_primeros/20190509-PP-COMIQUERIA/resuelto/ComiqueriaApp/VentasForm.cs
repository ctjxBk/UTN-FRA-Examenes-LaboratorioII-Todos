using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComiqueriaLogic;

namespace ComiqueriaApp
{
    public partial class VentasForm : Form
    {
        private Producto producto;
        private Comiqueria comiqueria;
        private Venta venta;
        public VentasForm()
        {
            InitializeComponent();
        }

        public VentasForm(Producto producto, Comiqueria comiqueria)
            : this()
        {
            this.producto = producto;
            this.comiqueria = comiqueria;
        }

        private void VentasForm_Load(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = producto.Descripcion;
            SimularVenta();
        }

        private void SimularVenta()
        {
            double precio = (double)this.numericUpDownCantidad.Value * this.producto.Precio;
            this.lblPrecioFinal.Text = $"Precio Final: ${precio.ToString()}";
        }

        private void numericUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            SimularVenta();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            int cantidad = (int)this.numericUpDownCantidad.Value;
            if(cantidad <= this.producto.Stock)
            {
                this.comiqueria.Vender(producto, (int)this.numericUpDownCantidad.Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay suficiente stock, por favor disminuya la cantidad de compra",
                    "Información",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
