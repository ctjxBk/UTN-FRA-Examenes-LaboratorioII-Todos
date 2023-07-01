using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        public enum Deportes { Basquet, Futbol, Handball, Rugby }
        private static Deportes deporte;
        private DirectorTecnico dt;
        private List<Jugador> jugadores;
        private string nombre;

        public static Deportes Deporte
        {
            set { deporte = value; }
        }

        static Equipo()
        {
            Deporte = Deportes.Futbol;
        }

        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(string nombre, DirectorTecnico dt) : this()
        {
            this.nombre = nombre;
            this.dt = dt;
        }

        public Equipo(string nombre, DirectorTecnico dt, Deportes deporte)
            : this(nombre, dt)
        {
            Deporte = deporte;
        }

        public static explicit operator string(Equipo e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{e.nombre} {Equipo.deporte}");
            sb.AppendLine("Nómina Jugadores");
            foreach(Jugador jugador in e.jugadores)
            {
                sb.AppendLine(jugador.ToString());
            }
            sb.AppendLine($"Dirigido por: {e.dt}");

            return sb.ToString();
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            if(e is not null && j is not null)
            {
                foreach(Jugador jugador in e.jugadores)
                {
                    if (jugador.Equals(j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if(e != j)
            {
                e.jugadores.Add(j);
            }
            return e;
        }

        public static Equipo operator -(Equipo e, Jugador j)
        {
            if (e == j)
            {
                e.jugadores.Remove(j);
            }
            return e;
        }

    }
}
