using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        private int añosExperiencia;
        public int AñosExperiencia { get => añosExperiencia; set => añosExperiencia = value; }

        public DirectorTecnico(string nombre, string apellido, int edad, int dni, int añosExperiencia) 
            : base(nombre, apellido, edad, dni)
        {
            this.añosExperiencia = añosExperiencia;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Mostrar()}Años de experiencia: {this.añosExperiencia}");
            return sb.ToString();
        }

        public override bool ValidarAptitud()
        {
            ///evitar el >= 2. con >1
            return this.Edad < 65 && this.añosExperiencia > 1;
        }
    }
}
