using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
    {
        private List<Alumno> alumnos;
        private short anio;
        private Divisiones division;
        private Profesor profesor;

        public string AnioDivision
        {
            get
            {
                return $"{this.anio}º{this.division}";
            }
        }

        private Curso()
        {
            this.alumnos = new List<Alumno>();
        }

        public Curso(short anio, Divisiones division, Profesor profesor)
            :this()
        {
            this.anio = anio;
            this.division = division;
            this.profesor = profesor;
        }

        public static explicit operator string(Curso c)
        {
            StringBuilder sb = new StringBuilder();
            if(c is not null)
            {
                sb.AppendLine($"Año: {c.anio} - División: {c.division}");
                sb.AppendLine($"Profesor: {c.profesor.ExponerDatos()}");
                if(c.alumnos is not null && c.alumnos.Count > 0)
                {
                    sb.AppendLine("Los alumnos son: ");
                    foreach (Alumno alumno in c.alumnos)
                    {
                        sb.AppendLine(alumno.ExponerDatos());
                    }
                }
                else
                {
                    sb.AppendLine("No tiene alumnos");
                }

            }
            return sb.ToString();
        }

        public static bool operator ==(Curso c, Alumno a)
        {
            if(c is not null && a is not null)
            {
                if (a.AnioDivision == c.AnioDivision)
                {
                    return true;
                }                
            }
            return false;
        }

        public static bool operator !=(Curso c, Alumno a)
        {
            return !(c == a);
        }

        public static Curso operator +(Curso c, Alumno a)
        {
            if(c == a)
            {
                c.alumnos.Add(a);
            }
            return c;
        }

    }
}
