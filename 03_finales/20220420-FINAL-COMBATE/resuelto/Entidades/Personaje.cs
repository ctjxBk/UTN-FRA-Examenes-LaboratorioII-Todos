using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void Delegado(Personaje personaje, int entero);
    public abstract class Personaje : IJugador
    {
        private decimal id;
        private short nivel;
        private string nombre;
        protected int puntosDeDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;
        private Random random;
        private string titulo;
        private const int nivelMinimo = 1;
        private const int nivelMaximo = 100;
        public event Delegado AtaqueLanzado;
        public event Delegado AtaqueRecibido;



        public int PuntosDeDefensa
        {
            get
            {
                return this.puntosDeDefensa;
            }
            set
            {
                this.puntosDeDefensa = value;
                if(this.puntosDeDefensa < 0)
                {
                    this.puntosDeDefensa = 0;
                }
            }

            //get
            //{
            //    return this.puntosDeDefensa;
            //}
            //set
            //{
            //    if(value > 0)
            //    {
            //        int cuantoSaco = this.puntosDeDefensa - value;
            //        if(cuantoSaco > 0)
            //        {
            //            this.puntosDeDefensa -= value;
            //        }
            //        else
            //        {
            //            this.puntosDeDefensa = 0;
            //            if(cuantoSaco > this.puntosDeVida)
            //            {
            //                this.puntosDeVida = 0;
            //            }
            //            else
            //            {
            //                this.puntosDeVida += cuantoSaco;
            //            }
            //        }
            //    }
            //}
        }

        public int PuntosDeVida
        {
            get
            {
                return this.puntosDeVida;
            }
            set
            {
                this.puntosDeVida = value;
                if (this.puntosDeVida < 0)
                {
                    this.puntosDeVida = 0;
                }
            }
        }

        public Personaje()
        {
            this.puntosDeDefensa = 100;
            this.puntosDePoder = 100;
            this.puntosDeVida = 500;
            this.random = new Random();
        }

        public Personaje(decimal id, string nombre)
            : this(id, nombre, 1)
        {

        }

        public Personaje(decimal id, string nombre, short nivel)
            :this()
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                this.nombre = nombre.Trim();
            }
            else
            {
                throw new ArgumentNullException("El nombre no puede ser null o estar vacio");
            }
            this.id = id;
            

            if(nivel >= nivelMinimo && nivel <= nivelMaximo)
            {
                this.nivel = nivel;
            }
            else
            {
                throw new BusinessException("El nivel no esta dentro del rango");
            }

        }

        public string Titulo
        {
            set { titulo = value; }
        }

        public abstract void AplicarBeneficiosDeClase();
        
        public static bool operator ==(Personaje personaje, Personaje otroPersonaje)
        {
            return personaje.id == otroPersonaje.id;
        }

        public static bool operator !=(Personaje personaje, Personaje otroPersonaje)
        {
            return !(personaje==otroPersonaje);
        }

        public override bool Equals(object otroPersonaje)
        {
            return this == (Personaje)otroPersonaje;
        }
        
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
        
        public short Nivel => this.nivel;

        //protected int PuntosDePoder { get => puntosDePoder; set => puntosDePoder = value; }

        public int Atacar()
        {
            Thread.Sleep(random.Next(1000, 5001));
            int ataque = this.Random10a100Porciento(this.puntosDePoder);
            this.AtaqueLanzado?.Invoke(this, ataque);
            //throw new NotImplementedException();
            return ataque;
        }

        public void RecibirAtaque(int puntosDeAtaque)
        {
            int ataque = this.Random10a100Porciento(puntosDeAtaque);
            int cuantoQueda = this.CuantoQuedaAtaque(ataque);
            
            if (cuantoQueda < 0)
            {
                this.PuntosDeVida += cuantoQueda;
            }
            this.AtaqueRecibido?.Invoke(this, cuantoQueda);
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.titulo))
            {
                return $"{nombre}, {titulo}";
            }
            return nombre;
        }

        private int CuantoQuedaAtaque(int ataque)
        {
            int cuantoQuedaAtaque = this.puntosDeDefensa - ataque;
            this.PuntosDeDefensa -= ataque;
            return cuantoQuedaAtaque;
        }

        private int Random10a100Porciento(int numero)
        {
            return (numero * random.Next(10, 101)) / 100;
        }
    }
}
