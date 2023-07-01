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
    //    12.	Paciente, implementará la interfaz IPaciente.
    //a.Atender, cambiara el estado del paciente a True.
    //b.Anunciarse, cargara en el atributo identificador de paciente el valor leído desde la BD.El Id del paciente a obtener será aleatorio hasta un número máximo de 100. (reutilizar código).
    //c.Sobrescribir el toString y retornar el identificador

    public class Paciente : IPaciente
    {
        private bool estado;
        private string identificador;

        public bool EstaAtendido => this.estado;

        public string Identificador
        {
            get
            {
                return this.identificador;
            }
            set
            {
                this.identificador = value;
            }
        }

        public void Anunciarse()
        {
            Random random = new Random();
            this.identificador = DataBaseManager.ObtenerPaciente(random.NumeroRandom(100));
        }

        public void Atender()
        {
            this.estado = true;
        }

        public override string ToString()
        {
            return this.identificador;
        }

    }
}
