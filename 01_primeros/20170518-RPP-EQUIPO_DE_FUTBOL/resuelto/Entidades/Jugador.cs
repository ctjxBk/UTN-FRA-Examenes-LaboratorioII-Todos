using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        private bool esCapitan;
        private int numero;

        public bool EsCapitan { get => esCapitan; set => esCapitan = value; }
        public int Numero { get => numero; set => numero = value; }

        public override bool Equals(object obj)
        {
            if (obj is Jugador)
            {
                return this == (Jugador)obj;
            }
            return false;
        }

        public static explicit operator int(Jugador jugador)
        {
            return jugador.Numero;
        }

        protected override string FichaTecnica()
        {
            string EsCapitanMesanje = esCapitan ? ", capitán del equipo," : "";
            return $"{this.NombreCompleto()}{EsCapitanMesanje} camiseta {(int)this}";
        }

        public Jugador(string nombre, string apellido) : this(nombre, apellido, 0, false)
        {
        }

        public Jugador(string nombre, string apellido, int numero, bool capitan)
            :base(nombre, apellido)
        {
            this.numero = numero;
            this.esCapitan = capitan;
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            return j1.Nombre == j2.Nombre && j1.Apellido == j2.Apellido && j1.numero == j2.numero;
        }

        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }


    }
}
