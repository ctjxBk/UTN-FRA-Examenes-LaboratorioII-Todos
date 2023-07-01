namespace BibliotecaDeClases
{
    public class Carrera : ICalificacion
    {
        string nombre;

        public Carrera(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; }

        public decimal CalificacionFinal
        {
            get { return GeneradorDeDatos.Rnd.Next(1, 11); }
        }

        public override string ToString()
        {
            return this.nombre + " - " + "Puntaje del curso: " + CalificacionFinal.ToString();
        }
    }
}
