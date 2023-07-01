using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    //18:40 - 19:20 (tener en cuenta que copie el código de consola)
    public abstract class Persona
    {
        private string apellido;
        private string nombre;

        public string Apellido { get => apellido; }
        public string Nombre { get => nombre; }

        protected abstract string FichaTecnica();

        protected virtual string NombreCompleto()
        {
            return string.Format("{0} {1}", this.Nombre, this.Apellido);
        }

        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
