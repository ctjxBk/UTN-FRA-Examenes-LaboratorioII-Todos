using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;


        public int Edad { get => edad; set => edad = value; }
        public bool EsAlfa { get => esAlfa; set => esAlfa = value; }

        public override bool Equals(object obj)
        {
            if(obj is Perro)
            {
                return this == (Perro)obj;
            }
            return false;
        }

        public static explicit operator int(Perro perro)
        {
            return perro.Edad;
        }

        protected override string Ficha()
        {
            string alfaMensaje = esAlfa ? ", alfa de la manada," : "";
            return $"{this.DatosCompletos()}{alfaMensaje} edad {(int)this}";
        }
        public static bool operator ==(Perro j1, Perro j2)
        {
            return j1.Nombre == j2.Nombre && j1.Raza == j2.Raza && j1.Edad == j2.Edad;
        }

        public static bool operator !=(Perro j1, Perro j2)
        {
            return !(j1 == j2);
        }

        public Perro(string nombre, string raza) : this(nombre, raza, 0, false)
        {
            
        }

        public Perro(string nombre, string raza, int edad, bool esAlfa) : base(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }

        public override string ToString()
        {
            return this.Ficha();
        }




    }
}
