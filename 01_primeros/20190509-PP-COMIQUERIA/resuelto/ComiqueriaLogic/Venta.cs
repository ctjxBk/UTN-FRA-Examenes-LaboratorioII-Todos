using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public sealed class Venta
    {
        private DateTime fecha;
        private static int porcentajeIva;
        private double precioFinal;
        private Producto producto;

        internal DateTime Fecha
        {
            get { return this.fecha; }
        }

        public static double CalcularPrecioFinal(double precioUnidad, int cantidad)
        {
            return precioUnidad * cantidad * ((100+Venta.porcentajeIva)/100);
        }

        public string ObtenerDescripcionBreve()
        {
            return $"{this.fecha} - {this.producto.Descripcion} - {Math.Round(this.precioFinal,2)}";
        }

        private void Vender(int cantidad)
        {
            this.producto.Stock = this.producto.Stock - cantidad;
            this.fecha = DateTime.Now;
            this.precioFinal = Venta.CalcularPrecioFinal(this.producto.Precio, cantidad);
        }

        static Venta()
        {
            Venta.porcentajeIva = 21;
        }

        internal Venta(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.Vender(cantidad);
        }
    }
}
