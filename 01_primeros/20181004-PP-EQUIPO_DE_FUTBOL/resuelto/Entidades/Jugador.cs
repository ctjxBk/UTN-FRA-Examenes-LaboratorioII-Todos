using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Posicion { Arquero, Defensor, Central, Delantero };
    public class Jugador : Persona
    {
        private float altura;
        private float peso;
        private Posicion posicion;

        public float Altura { get => altura; }
        public float Peso { get => peso; }
        public Posicion Posicion { get => posicion; }


        public Jugador(string nombre, string apellido, int edad, int dni, float peso, float altura, Posicion posicion) 
            : base(nombre, apellido, edad, dni)
        {
            this.peso = peso;
            this.altura = altura;
            this.posicion = posicion;
        }
        
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine($"Peso: {this.Peso}, Altura: {this.Altura}, Posicion: {this.Posicion}");
            return sb.ToString();
        }



        public override bool ValidarAptitud()
        {
            return this.Edad < 41 && this.ValidarEstadoFisico();
        }

        public bool ValidarEstadoFisico()
        {
            float imc = this.peso / (this.altura * this.altura);

            return imc >= 18.5 && imc <= 25;
        }
    }
}
