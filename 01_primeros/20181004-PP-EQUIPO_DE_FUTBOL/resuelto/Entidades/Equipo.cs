using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private const int cantidadMaximaJugadores = 6;
        private DirectorTecnico directorTecnico;
        private List<Jugador> jugadores;
        private string nombre;

        public DirectorTecnico DirectorTecnico
        {
            set
            {
                if (value.ValidarAptitud())
                {
                    this.directorTecnico = value;
                }
            }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(string nombre)
            : this()
        {
            this.nombre = nombre;
        }

        public static explicit operator string(Equipo e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre del equipo: {e.Nombre}");
            sb.AppendFormat("{0}{1}", e.directorTecnico is not null ? e.directorTecnico.Mostrar() : "Sin DT asignado", Environment.NewLine);
            if(e.jugadores is not null && e.jugadores.Count > 0)
            {
                foreach (Jugador jugador in e.jugadores)
                {
                    sb.AppendLine(jugador.Mostrar());
                }
            }
            else
            {
                sb.AppendLine("El equipo no tiene jugadores");
            }

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
                if(e.jugadores.Count < Equipo.cantidadMaximaJugadores)
                {
                    if(j.ValidarAptitud())// && j.ValidarEstadoFisico())
                    {
                        e.jugadores.Add(j);
                    }
                }
            }
            return e;
        }

        public static bool ValidarEquipo(Equipo e)
        {
            int cantidadArquero = 0;
            int cantidadDefensor = 0;
            int cantidadCentral = 0;
            int cantidadDelantero = 0;
            if(e is not null)
            {
                if(e.directorTecnico is not null)
                {
                    if(e.jugadores.Count == Equipo.cantidadMaximaJugadores)
                    {
                        foreach (Jugador j in e.jugadores)
                        {
                            switch (j.Posicion)
                            {
                                case Posicion.Arquero:
                                    cantidadArquero++;
                                    break;
                                case Posicion.Defensor:
                                    cantidadDefensor++;
                                    break;
                                case Posicion.Central:
                                    cantidadCentral++;
                                    break;
                                case Posicion.Delantero:
                                    cantidadDelantero++;
                                    break;
                            }
                        }
                        if(cantidadArquero == 1 
                            && cantidadDefensor > 0
                            && cantidadCentral >0
                            && cantidadDelantero > 0
                            )
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
