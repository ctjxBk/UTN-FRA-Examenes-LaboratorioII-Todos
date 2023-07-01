using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    

    public class Alumno : Persona
    {
        private short anio;
        private Divisiones division;

        public string AnioDivision
        {
            get
            {
                return $"{this.anio}º{this.division}";
            }
        }
        public Alumno(string nombre, string apellido, string documento, short anio, Divisiones division) 
            : base(nombre, apellido, documento)
        {
            this.anio = anio;
            this.division = division;
        }

        public override string ExponerDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ExponerDatos());
            sb.AppendLine(this.AnioDivision);
            return sb.ToString();
        }

        public override bool ValidarDocumentacion(string doc)
        {
            if(doc is not null && doc.Length == 9)
            {
                for(int i = 0; i < doc.Length; i++)
                {
                    //(i != 2 && i != 7) en la posicion DOS o SIETE NO VERIFICO SI ES O NO NUMERICO
                    string caracter = doc[i].ToString();
                    int variableAuxiliar = 0;
                    if ( (!(i != 2 && i != 7) && int.TryParse(caracter,out variableAuxiliar)))
                    {
                        //no se cumple
                        return false;
                    }
                }
                //se cumple
                return true;
            }
            //error , no se cumple
            return false;
        }
    }
}
