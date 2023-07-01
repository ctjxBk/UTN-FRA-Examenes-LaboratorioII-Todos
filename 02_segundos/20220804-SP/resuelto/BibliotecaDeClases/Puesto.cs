namespace BibliotecaDeClases
{
    public class Puesto : ICompensacion
    {
        string nombrePuesto;
        float remuneraciónOfrecida;

        /// <summary>
        /// constructor privadao para inicializar la remuneraciónOfrecida
        /// </summary>
        private Puesto()
        {
            this.remuneraciónOfrecida = GeneradorDeDatos.Rnd.Next(100000, 300001);
        }

        /// <summary>
        /// constructor para inicializar el nombre del puesto
        /// </summary>
        /// <param name="nombre">nombre del puesto</param>
        public Puesto(string nombre):this()
        {
            this.nombrePuesto = nombre;
            
        }
        
        /// <summary>
        /// propiedad para retornar el nombre del puesto
        /// </summary>
        public string Posicion { get => nombrePuesto; }

        /// <summary>
        /// propiedad para calcular los honorarios del puesto
        /// </summary>
        public float CalcularHonorarios
        {
            get
            {
                if (this.remuneraciónOfrecida > 200000)
                {
                    return this.remuneraciónOfrecida * 0.75f;
                }
                return this.remuneraciónOfrecida;
            }
        }

        /// <summary>
        /// sobre carga del Tostring() con informacion personalizada
        /// </summary>
        /// <returns>retorna un string con informacion del puesto</returns>
        public override string ToString()
        {
            return "Se busca " + this.nombrePuesto + " - " + "Sueldo ofrecido: " + this.CalcularHonorarios;
        }
    }
}
