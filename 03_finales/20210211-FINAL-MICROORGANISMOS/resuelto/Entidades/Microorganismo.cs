using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    //18:00 a 20:00 con test (completo)
    public abstract class Microorganismo
    {
        public enum EContagiosidad { Baja, Moderada, Alta}
        public enum ETipo { Virus, Bacteria }
        protected long contador;
        private EContagiosidad contagiosidad;
        private string nombre;
        private ETipo tipo;

        public abstract long IndiceDeContagios
        {
            get;
        }

        public string Informe()
        {
            return $"El {this.tipo} lleva el nombre de {this.nombre} y tiene una contagiosidad {this.contagiosidad}" +
                $"{Environment.NewLine}Su impacto de contagios se calcula en {this.IndiceDeContagios}";
        }

        public Microorganismo(string nombre)
        {
            this.nombre = nombre;
            
            if (this.contador == 0)
            {
                this.contador = 1;
            }
        }

        public Microorganismo(string nombre, ETipo tipo, EContagiosidad contagiosidad)
            :this(nombre)
            
        {
            this.tipo = tipo;
            this.contagiosidad = contagiosidad;
        }

    }
}
