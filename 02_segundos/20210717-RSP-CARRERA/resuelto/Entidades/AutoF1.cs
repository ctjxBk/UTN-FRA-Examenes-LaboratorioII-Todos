using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //18:45 - 20:15 sin testing
    //20:30 con testing
    public class AutoF1
    {
        private string escuderia;
        private int posicion;
        private int puntoPartida;
        private int velocidad;

        public string Escuderia { get => escuderia; set => escuderia = value; }
        public int Posicion { get => posicion; set => posicion = value; }
        public int UbicacionEnPista { get => puntoPartida; set => puntoPartida = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }

        public void Acelerar()
        {
            this.UbicacionEnPista += this.Velocidad;
        }

        public AutoF1()
        {

        }

        public AutoF1(string escuderia, int velocidad, int puntoPartida)
        {
            this.escuderia = escuderia;
            this.velocidad = velocidad;
            this.puntoPartida = puntoPartida;
        }

        public override string ToString()
        {
            return $"Escuderia: {this.Escuderia} - Posicion: {this.Posicion}{Environment.NewLine}";
        }

        
    }
}
