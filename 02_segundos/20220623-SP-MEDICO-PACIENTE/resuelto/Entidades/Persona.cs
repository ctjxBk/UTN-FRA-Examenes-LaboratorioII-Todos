using System;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(PersonalMedico))]
    [XmlInclude(typeof(Paciente))]

    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        protected DateTime nacimiento;
        protected string barrioResidencia;


        public Persona()
        {
            //para xml
        }

        public Persona(string nombre, string apellido, DateTime nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
        }

        public Persona(string nombre, string apellido, DateTime nacimiento, string barrioResidencia)
            : this(nombre, apellido, nacimiento)
        {
            this.barrioResidencia = barrioResidencia;
        }

        public string NombreCompleto
        {
            get {
                return String.Format("{0}, {1}", this.apellido, this.nombre);
            }
        }
        public int Edad
        {
            get
            {
                return DateTime.Today.AddTicks(-this.nacimiento.Ticks).Year - 1;
            }

        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public string BarrioResidencia { get => barrioResidencia; set => barrioResidencia = value; }

        internal abstract string FichaExtra();

        public static string FichaPersonal(Persona p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(p.NombreCompleto);
            sb.AppendLine("EDAD:" + p.Edad);
            sb.Append(p.FichaExtra());

            return sb.ToString();
        }
        public override string ToString()
        {
            return this.NombreCompleto;
        }
    }
}
