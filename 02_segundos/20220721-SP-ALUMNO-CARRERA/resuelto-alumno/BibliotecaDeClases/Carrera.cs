namespace BibliotecaDeClases
{
    public class Carrera :ICalificacion
    {
        string nombre; // no modificar linea
        private int notaFinal;

        // no modificar metodo
        public Carrera(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; } // no modificar linea

        public decimal CalificacionFinal
        {
            get
            {
                if(this.notaFinal == 0)
                {
                    this.notaFinal = GeneradorDeDatos.Rnd.Next(1, 11);
                }
                return this.notaFinal;
            }
        }


        //completar
        public override string ToString()
        {
            return this.nombre + " - " + "Puntaje del curso: " + this.CalificacionFinal;
        }



    }
}
