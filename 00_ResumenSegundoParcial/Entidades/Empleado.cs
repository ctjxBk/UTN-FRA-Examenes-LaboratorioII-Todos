using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Empleado
    {
        [XmlIgnoreAttribute]
        public int legajo;
        [XmlIgnoreAttribute]
        public string nombre;
        [XmlIgnoreAttribute]
        public DateTime fechaNacimiento;
        [XmlIgnoreAttribute]
        public bool esFumador;
        [XmlIgnoreAttribute]
        public double sueldo;
        [XmlIgnoreAttribute]
        public float altura;

        public int Legajo { get => legajo; set => legajo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public bool EsFumador { get => esFumador; set => esFumador = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public float Altura { get => altura; set => altura = value; }

        public Empleado()
        {
        }

        public Empleado(decimal legajo)
        {
            this.legajo = (int)legajo;
        }

        public Empleado(int legajo, string nombre, DateTime fechaNacimiento, bool fuma, double sueldo, float altura)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.esFumador = fuma;
            this.sueldo = sueldo;
            this.altura = altura;
        }

        public override string ToString()
        {
            return $"Legajo: {this.legajo} - " +
                $"Nombre: {this.nombre} - " +
                $"FechaNacimiento: {this.fechaNacimiento.ToString("dd/MM/yyyy")} - " +
                $"EsFumador/a: {String.Format("{0}",this.esFumador == true ? "Sí" : "No")} - " +
                $"Sueldo: {this.sueldo} - " +
                $"Altura: {this.altura}";
        }


        public static bool operator ==(Empleado e1, Empleado e2)
        {
            return e1.legajo == e2.legajo;
        }
        public static bool operator !=(Empleado e1, Empleado e2)
        {
            return !(e1 == e2);
        }

        public static Empleado operator ^(Empleado e1, Empleado e2)
        {
            if(e1 is not null && e2 is not null)
            {
                e1.nombre = e2.nombre;
                e1.fechaNacimiento = e2.fechaNacimiento;
                e1.esFumador = e2.esFumador;
                e1.sueldo = e2.sueldo;
                e1.altura = e2.altura;
            }
            return e1;
        }

        public static Empleado operator |(List<Empleado> empleados, Empleado e)
        {
            if(empleados is not null)
            {
                foreach(Empleado empleado in empleados)
                {
                    if(empleado == e)
                    {
                        return empleado;
                    }
                }
            }
            return null;
        }
    }
}
