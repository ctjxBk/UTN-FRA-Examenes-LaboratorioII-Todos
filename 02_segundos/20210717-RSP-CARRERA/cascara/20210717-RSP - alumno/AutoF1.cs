using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210717_RSP___alumno
{
    public class AutoF1
    {
        string escuderia;
        int posicion;
        int puntoDePartida;
        int velocidad;

        public string Escuderia { get; set; }
        public int Posicion { get; set; }
        public int UbicacionEnPista 
        {
            get { return puntoDePartida; }
            set { puntoDePartida = value; }
        }
        public int Velocidad { get; set; }

        public AutoF1()
        {

        }

        public AutoF1(string escuderia, int velocidad, int puntoDePartida)
        {
            this.Escuderia = escuderia;
            this.velocidad = velocidad;
            this.puntoDePartida = puntoDePartida;

        }

        public void Acelerar()
        {
            this.puntoDePartida += this.velocidad;
        }

        public override string ToString()
        {
            return string.Format($"Escuderia: {this.Escuderia} - Posicion: {this.Posicion}");
        }
    }
}
