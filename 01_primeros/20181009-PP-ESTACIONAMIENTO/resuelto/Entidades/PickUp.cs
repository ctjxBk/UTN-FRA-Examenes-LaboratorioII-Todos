using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PickUp : Vehiculo
    {
        private string modelo;
        private static int valorHora;

        public override string ConsultarDatos()
        {
            return $"{base.ToString()}. Modelo: {this.modelo}";
        }

        public override bool Equals(object obj)
        {
            return obj is PickUp;
        }

        public override string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();
            double tiempo = (DateTime.Now - ingreso).Hours;
            double estadia = PickUp.valorHora * tiempo;
            sb.AppendLine($"{base.ImprimirTicket()}. Costo de estadia: {estadia}");
            return sb.ToString();
        }

        static PickUp()
        {
            PickUp.valorHora = 70;
        }

        public PickUp(string patente, string modelo) : base(patente)
        {
            this.modelo = modelo;
        }

        public PickUp(string patente, string modelo, int valorHora)
            :this(patente, modelo)
        {
            PickUp.valorHora = valorHora;
        }


    }
}
