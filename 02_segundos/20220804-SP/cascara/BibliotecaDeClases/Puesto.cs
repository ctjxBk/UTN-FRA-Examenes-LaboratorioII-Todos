namespace BibliotecaDeClases
{
    public class Puesto : ICompensacion
    {
        string nombrePuesto;
        float remuneraciónOfrecida;

        public Puesto(string nombre)
        {
            this.nombrePuesto = nombre;
        }

        public string Posicion { get => nombrePuesto; }

      

        public override string ToString()
        {
            return "Se busca " + this.nombrePuesto + " - " + "Sueldo ofrecido: ";
        }
    }
}
