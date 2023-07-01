namespace BibliotecaDeClases
{

    // DESARROLLAR
    public class Puesto 
    {
        string nombrePuesto;
        float remuneraciónOfrecida;

        private Puesto()
        {
          
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
                return 0;
            }
        }

        public override string ToString()
        {
            return "Se busca "+ this.nombrePuesto + " - " + "Sueldo ofrecido: " + CalcularHonorarios.ToString();
        }
    }
}
