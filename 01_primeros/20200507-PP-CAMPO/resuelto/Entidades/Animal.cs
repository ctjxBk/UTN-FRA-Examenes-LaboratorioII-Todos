using System;
using System.Text;

namespace Entidades
{
    //19:50
    public  abstract class Animal
    {
        private int kilosAlimento;
        private string nombre;

        public abstract bool ComeBalanceado { get; }
        public abstract bool ComePasto { get; }

        public int KilosAlimento
        {
            get { return this.kilosAlimento; }
        }

        public Animal(string nombre, int volumen)
        {
            this.nombre = nombre;
            this.kilosAlimento = volumen;
        }

        public virtual string Datos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format($"{this.nombre} come {this.KilosAlimento} kg"));
            sb.AppendLine(String.Format("Consume balanceado {0}",this.ComeBalanceado ? "SI" : "NO"));
            sb.AppendLine(String.Format("Consume pasto {0}", this.ComePasto ? "SI" : "NO"));
            return sb.ToString();
        }

        

    }
}
