using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public static class Tienda
    {
        private static List<Producto> stockTienda;
        public delegate void DelegadoProducto();
        public static DelegadoProducto eventoObtenerDatos;

        public static List<Producto> StockTienda { get { return stockTienda; } }

        public static void CargarDatos()
        {
            eventoObtenerDatos?.Invoke();
        }

        public static string InfoTienda()
        {
            return stockTienda.InfoDeLaLista();
        }

        private static void ObtenerCelulares()
        {
            ManejadorDeArchivos<Producto> manejador = new ManejadorDeArchivos<Producto>();
            List<Producto> celulares = manejador.Leer();


                foreach(Producto p in celulares)
                {

                    if (stockTienda.Count == 0)
                    {
                        stockTienda.Add(p);
                    }
                    else
                    {
                        if(stockTienda != p)
                        {
                            stockTienda.Add(p);
                        }
                    }
                }
        }

        private static void ObtenerTelevisores()
        {
            stockTienda.AddRange(ManejadorBaseDeDatos.ObtenerProductos());
        }

        static Tienda()
        {
            stockTienda = new List<Producto>();
            eventoObtenerDatos += ObtenerCelulares;
            eventoObtenerDatos += ObtenerTelevisores;
        }

        
        

    }
}
