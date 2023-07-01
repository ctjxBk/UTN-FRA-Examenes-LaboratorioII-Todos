using System;

namespace BibliotecaDeClases
{
    public class Empleado :ICompensacion
    {
        decimal dni;
        string nombreCompleto;
        bool dolarizado;
        string posicion;
        int remuneracionPretendida;

        public float CalcularHonorarios 
        {
            get
            {
                if (this.dolarizado)
                {
                    return this.remuneracionPretendida / 300;
                }
                return this.remuneracionPretendida;
            }
        }

        public string Posicion
        {
            get
            {
                return posicion;
            }
            set
            {
                posicion = value;
            }
        }

        public decimal Dni { get => dni; set => dni = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public bool Dolarizado { get => dolarizado; set => dolarizado = value; }

        private Empleado()
        {
            this.remuneracionPretendida = GeneradorDeDatos.Rnd.Next(100000, 300001);
        }

        public Empleado(decimal dni, string nombreCompleto, string posicion, bool dolarizacion)
            :this()
        {
            this.dni = dni;
            this.nombreCompleto = nombreCompleto;
            this.posicion = posicion;
            this.dolarizado = dolarizacion;
            
        }
    }
}
