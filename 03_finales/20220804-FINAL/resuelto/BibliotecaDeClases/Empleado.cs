using System;

namespace BibliotecaDeClases
{
    //11:50 - 12:40 
    //13:30 - 14:40 (testing incluido)

    //DESARROLLAR 
    public abstract class Empleado : ICompensacion
    {
        protected decimal dni;
        protected string nombreCompleto;
        protected string posicion;
        protected int remuneracionPretendida;

        protected Empleado()
        {
            this.remuneracionPretendida = GeneradorDeDatos.Rnd.Next(100000,250000);
        }

        public Empleado(decimal dni, string nombre, string posicion)
            :this()
        {
            this.dni = dni;
            this.nombreCompleto = nombre;
            this.posicion = posicion;

        }

        public abstract float CalcularHonorarios { get; }

        public string Posicion
        {
            get { return posicion; }
        }

        public decimal Dni { get => dni; set => dni = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }


    }
}
