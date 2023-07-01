using System;

namespace BibliotecaDeClases
{
    //DESARROLLAR 
    public class Empleado
    {
        decimal dni;
        string nombreCompleto;
        string posicion;
        int remuneracionPretendida;


        public Empleado(decimal dni, string nombre, string posicion)
        {
            this.dni = dni;
            this.nombreCompleto = nombre;
            this.posicion = posicion;

        }

        public string Posicion
        {
            get { return posicion; }
        }

        public decimal Dni { get => dni; set => dni = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }


    }
}
