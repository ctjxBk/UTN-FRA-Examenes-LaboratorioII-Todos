namespace BibliotecaDeClases
{
    public class Carrera
    {
        string nombre; // no modificar linea

        // no modificar metodo
        public Carrera(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; } // no modificar linea


        //completar
        public override string ToString()
        {
            return this.nombre + " - " + "Puntaje del curso: ";
        }



    }
}
