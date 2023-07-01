using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    //21:50 - 23:24 sin test (y no tengo celulares.xml)
    //ahora tengo celulares.xml 23:57 sigo .... 00:30 resolvi el problema de celulares duplicados (TENIA LA SOBRECARGA Y NO LA USABA)
    //00:45 para los test
    //TIEMPO TOTAL 142 minutos = 2 horas y 22 minutos
    //Nota: si no hubiera demorado 33 minutos con el problema de los celulares duplicados hubiera terminado en menos de 2 horas

    [XmlInclude(typeof(Celular))]
    public abstract class Producto
    {
        protected string marca;
        protected string modelo;
        protected float precio;

        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public float Precio { get => precio; set => precio = value; }

        public abstract string Garantia { get; }

        public Producto()
        {

        }

        public Producto(string mod, float precio, string marca)
        {
            this.Modelo = mod;
            this.Precio = precio;
            this.Marca = marca;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Marca: {this.Marca} - Modelo: {this.Modelo} - Precio: {this.Precio} - Garantia: {this.Garantia}");
            return sb.ToString();
        }

        public static bool operator ==(List<Producto> p1, Producto p2)
        {
            if(p1 is not null && p2 is not null)
            {
                foreach(Producto p in p1)
                {
                    if(p == p2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(List<Producto> p1, Producto p2)
        {
            return !(p1 == p2);
        }


        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.Marca == p2.Marca && p1.Modelo == p2.Modelo && p1.GetType() == p2.GetType();
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
    }




}
