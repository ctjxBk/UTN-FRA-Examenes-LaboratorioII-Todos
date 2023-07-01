using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    //    12.	Persona, será abstracta.
    //a.Sus dos atributos serán privados.
    //b.MostrarDatos protegido y abstracto.
    //c.Sobre escribir Equals y comparar las personas por apellido.

    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;

        public override bool Equals(object obj)
        {
            return (obj is Persona) && ((Persona)obj).apellido == this.apellido;
        }

        protected abstract string MostrarDatos();
        
    }
}
