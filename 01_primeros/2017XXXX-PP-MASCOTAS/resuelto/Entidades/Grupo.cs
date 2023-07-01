using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    //17:50 - 18:40 (tener en cuenta que el codigo de la consola lo copie)
    public class Grupo
    {
        private List<Mascota> manada;
        private string nombre;
        private static TipoManada tipo;
        public enum TipoManada { Unica, Mixta }

        public static TipoManada Tipo
        {
            set { tipo = value; }
        }

        static Grupo()
        {
            Tipo = TipoManada.Unica;
        }

        private Grupo()
        {
            this.manada = new List<Mascota>();
        }

        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Grupo(string nombre, TipoManada tipo) : this(nombre)
        {
            Tipo = tipo;
        }

        public static implicit operator string(Grupo e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"**{e.nombre} {Grupo.tipo}**");
            sb.AppendLine($"Integrantes: ");
            foreach (Mascota mascota in e.manada)
            {
                sb.AppendLine($"{mascota.ToString()}");
            }

            return sb.ToString();
        }

        public static bool operator ==(Grupo e, Mascota j)
        {
            if(e is not null && j is not null)
            {
                foreach(Mascota m in e.manada)
                {
                    if (m.Equals(j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Grupo e, Mascota j)
        {
            return !(e == j);
        }

        public static Grupo operator -(Grupo e, Mascota j)
        {
            if(e == j)
            {
                e.manada.Remove(j);
            }
            return e;
        }

        public static Grupo operator +(Grupo e, Mascota j)
        {
            if(e != j)
            {
                e.manada.Add(j);
            }
            return e;
        }
    }
}
