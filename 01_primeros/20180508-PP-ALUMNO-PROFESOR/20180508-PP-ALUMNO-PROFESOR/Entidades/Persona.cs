using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // 18:30
    // 20:00
    public abstract class Persona
    {
        private string apellido;
        private string documento;
        private string nombre;

        public string Apellido { get => apellido;}
        public string Documento
        {
            get
            {
                if (ValidarDocumentacion(this.documento))
                {
                    return this.documento;
                }
                return "DOCUMENTO INVALIDO";
            }
            set => documento = value; 
        }
        public string Nombre { get => nombre;}

        public virtual string ExponerDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre completo: {this.Apellido}, {this.Nombre}");
            sb.Append($". Documentación: {this.Documento}");
            return sb.ToString();
        }

        public Persona(string nombre, string apellido, string documento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
        }

        public abstract bool ValidarDocumentacion(string doc);

    }
}
