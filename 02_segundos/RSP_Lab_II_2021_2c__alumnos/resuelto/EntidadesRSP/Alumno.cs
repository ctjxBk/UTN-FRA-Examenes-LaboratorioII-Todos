using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRSP
{
    public delegate void delegadoClasificacion(object obj, EventArgs argumentos);
    public class Alumno : Persona
    {
        private double nota;
        public event delegadoClasificacion Aprobar;
        public event delegadoClasificacion NoAprobar;
        public event delegadoClasificacion Promocionar;

        public Alumno()
        {

        }

        public Alumno(int dni, string nombre, string apellido, double nota) : base(dni, nombre, apellido)
        {
            this.Nota = nota;
        }

        public double Nota { get => nota; set => nota = value; }

        public override string ToString()
        {
            return $"{base.ToString()}, nota: {Nota}";
        }

        public void Clasificar()
        {
            if(Nota < 4)
            {
                NoAprobar?.Invoke(this,null);
            }else if(Nota >= 4 && Nota <6)
            {
                Aprobar?.Invoke(this, null);
            }
            else if(Nota >= 6)
            {
                Promocionar?.Invoke(this,null);
            }
        }
    }
}
