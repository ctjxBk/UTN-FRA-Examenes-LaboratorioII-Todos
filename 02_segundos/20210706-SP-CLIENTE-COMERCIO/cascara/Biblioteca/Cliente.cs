using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //18:40
    public class Cliente
    {
        private string nombre;
        private int numero;

        public Cliente()
        {

        }

        public Cliente(string nombre)
        {
            this.nombre = nombre;   
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero { get => numero; set => numero = value; }

        // Para los test unitarios
        //public static bool operator ==(Cliente c1, Cliente c2)
        //{
        //    return c1.nombre == c2.nombre && c1.numero == c2.numero;
        //}
        //public static bool operator !=(Cliente c1, Cliente c2)
        //{
        //    return !(c1 == c2);
        //}
    }
}
