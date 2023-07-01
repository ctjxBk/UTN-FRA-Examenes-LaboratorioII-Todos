using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //9:30 - 10:37 solo la lógica
    //11:00 termine el form
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private int edad;
        private string nombre;

        public string Apellido { get => apellido; }
        public int Dni { get => dni; }
        public int Edad { get => edad; }
        public string Nombre { get => nombre; }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.apellido}, {this.nombre}. Edad {this.Edad}. DNI: {this.dni}.");

            return sb.ToString();
        }

        public Persona(string nombre, string apellido, int edad, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
        }

        public abstract bool ValidarAptitud();

    }
}
