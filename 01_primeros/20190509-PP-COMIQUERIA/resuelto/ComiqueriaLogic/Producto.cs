using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    //14:05
    //15:17 termine la lógica
    //17:02 termine el formulario
    public abstract class Producto
    {
        private Guid codigo;
        private string descripcion;
        private double precio;
        private int stock;

        public string Descripcion { get => descripcion; }
        public double Precio { get => precio; }
        public int Stock 
        { 
            get => stock;
            set
            {
                if(value >= 0)
                {
                    this.stock = value;
                }
            }
        }

        public static explicit operator Guid(Producto p)
        {
            return p.codigo;
        }

        protected Producto(string descripcion, int stock, double precio)
        {
            this.codigo = Guid.NewGuid();
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Descripcion: {this.Descripcion} ");
            //sb.AppendLine($"Código: {this.codigo} ");
            sb.AppendLine($"Código: {(Guid)this} ");
            sb.AppendLine($"Precio: ${this.Precio}");
            sb.AppendLine(String.Format("Stock: {0} unidades",this.Stock));
            
            return sb.ToString();
        }
    }
}
