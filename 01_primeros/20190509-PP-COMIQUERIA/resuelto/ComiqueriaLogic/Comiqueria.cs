using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Comiqueria
    {
        private List<Producto> productos;
        private List<Venta> ventas;

        public Producto this[Guid codigo]
        {
            get
            {
                foreach(Producto p in this.productos)
                {
                    if(codigo == (Guid)p)
                    {
                        return p;
                    }
                }
                return null;
            }
        }

        public Comiqueria()
        {
            this.productos = new List<Producto>();
            this.ventas = new List<Venta>();
        }

        public Dictionary<Guid, String> ListarProductos()
        {
            Dictionary<Guid, String> dic = new Dictionary<Guid, String>();
            foreach(Producto p in this.productos)
            {
                dic[(Guid)p] = p.ToString();
            }
            return dic;
        }

        public static int Ordenamiento(Venta v1, Venta v2)
        {
            return (int)(v2.Fecha - v1.Fecha).TotalSeconds;
        }

        public string ListarVentas()
        {
            StringBuilder sb = new StringBuilder();
            this.ventas.Sort(Comiqueria.Ordenamiento);            
            foreach(Venta v in this.ventas)
            {
                sb.AppendLine(v.ObtenerDescripcionBreve());
            }
            return sb.ToString();
        }

        public static bool operator ==(Comiqueria comiqueria, Producto producto)
        {
            //no se puede usar is not null porque es de .net core y no de .net framework
            //no se puede usar != porque ya esta sobre cargado y tira una excepcion de overflow
            //if(comiqueria != null && producto != null)
            {
                foreach(Producto p in comiqueria.productos)
                {
                    if(p.Descripcion == producto.Descripcion)
                    {
                        return true;
                    }
                }   
            }
            return false;
        }

        public static bool operator !=(Comiqueria comiqueria, Producto producto)
        {
            return !(comiqueria == producto);
        }

        public static Comiqueria operator +(Comiqueria comiqueria, Producto producto)
        {
            if(comiqueria != producto)
            {
                comiqueria.productos.Add(producto);
            }
            return comiqueria;
        }

        public void Vender(Producto producto)
        {
            this.Vender(producto, 1);
        }

        public void Vender(Producto producto, int cantidad)
        {
            Venta venta = new Venta(producto, cantidad);
            this.ventas.Add(venta);
        }

    }
}
