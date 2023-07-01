using Entidades.DataBase;
using Entidades.Extension;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades.Models
{
    //    13.	Paciente, heredará de persona e implementará la interfaz IPaciente
    //a.Atender, cambiara el estado del paciente a True.
    //b.La propiedad Identificarse retornara un string con el texto “Paciente” + el HashCode de la instancia + el nombre y el apellido separados por coma.
    //c.Anunciarse, leerá desde la BD una paciente de manera aleatoria (entre 1 y 100), separara el nombre y apellido de la cadena y los asignará a los atributos de la instancia.
    //d.MostrarDatos retorna el nombre y el apellido separado por coma.
    //e.Sobrescribir el toString y exponer MostrarDatos.

    public class Paciente : Persona, IPaciente
    {
        private bool estado;

        public bool EstaAtendido => this.estado;

        public string Identificador
        {
            get
            {
                return $"Paciente, {this.GetHashCode()}, {this.MostrarDatos()}";
            }
        }

        public void Anunciarse()
        {
            Random random = new Random();
            string nombreCompleto = DataBaseManager.ObtenerPaciente(random.Next(1,100));
            string[] arrayNombreCompleto = nombreCompleto.ObtenerNombreYApellido();
            this.nombre = arrayNombreCompleto[0];
            this.apellido = arrayNombreCompleto[1];
        }

        public void Atender()
        {
            this.estado = true;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            return $"{this.nombre}, {this.apellido}";
        }
    }
}
