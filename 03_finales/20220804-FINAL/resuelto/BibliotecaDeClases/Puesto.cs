using System;

namespace BibliotecaDeClases
{

    // DESARROLLAR
    public class Puesto : ICompensacion
    {
        private string nombrePuesto;
        private float remuneraciónOfrecida;

        private Puesto()
        {
            this.remuneraciónOfrecida = GeneradorDeDatos.Rnd.Next(100000, 300000);
        }

        public Puesto(string nombre) : this()
        {
            this.nombrePuesto = nombre;
        }

        public string Posicion { get => nombrePuesto; }

        public float CalcularHonorarios
        {
            get
            {
                return this.remuneraciónOfrecida;
            }
        }

        public override string ToString()
        {
            return "Se busca "+ this.nombrePuesto + " - " + "Sueldo ofrecido: " + CalcularHonorarios.ToString();
        }
    }
}
