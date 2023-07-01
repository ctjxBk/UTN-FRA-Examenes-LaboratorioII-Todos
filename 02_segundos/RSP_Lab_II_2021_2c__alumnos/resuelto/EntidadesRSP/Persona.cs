
using System;

namespace EntidadesRSP
{
    //18:45 - termine 20:45
    public class Persona
    {
        private int dni;
        private string nombre;
        private string apellido;

        public Persona()
        {

        }

        public Persona(int dni, string nombre, string apellido)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre}. DNI: {Dni}";
        }
    }
}
