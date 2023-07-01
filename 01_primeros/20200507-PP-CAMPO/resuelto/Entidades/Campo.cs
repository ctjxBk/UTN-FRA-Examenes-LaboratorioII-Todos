using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Campo
    {
        public enum Tipo { Pastoreo, Engorde}
        private int alimentoDisponible;
        private List<Animal> animales;
        public static Tipo servicio;

        private Campo()
        {
            this.animales = new List<Animal>();
        }

        static Campo()
        {
            Campo.servicio = Tipo.Engorde;
        }

        public Campo(int alimento) : this()
        {
            this.alimentoDisponible = alimento;
        }

        public static Tipo TipoServicio
        {
            set
            {
                Campo.servicio = value;
            }
        }

        public static bool operator +(Campo campo, Animal animal)
        {
            if(campo is not null && animal is not null)
            {
                if(campo.alimentoDisponible >= campo.AlimentoComprometido(animal))
                {
                    campo.animales.Add(animal);
                    return true;
                }
            }
            return false;            
        }

        private int AlimentoComprometido(Animal animal)
        {
            return this.AlimentoComprometido() + animal.KilosAlimento;
        }

        private int AlimentoComprometido()
        {
            int alimentoQueConsumen = 0;
            foreach (Animal animalDelCampo in this.animales)
            {
                alimentoQueConsumen += animalDelCampo.KilosAlimento;
            }
            return alimentoQueConsumen;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Servicio del campo: {Campo.servicio}");
            sb.AppendLine($"Alimento comprometido: {this.alimentoDisponible} de {this.AlimentoComprometido()}");
            foreach(Animal animal in this.animales)
            {
                sb.AppendLine(animal.Datos());
            }
            return sb.ToString();
        }

    }
}
