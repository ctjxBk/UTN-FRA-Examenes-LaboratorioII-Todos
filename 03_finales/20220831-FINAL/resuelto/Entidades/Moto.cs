using System;

namespace Entidades
{
    public class Moto : Vehiculo, IInflable
    {
        bool chequeado;
        private delegate void MotoDelegado();
        private event MotoDelegado EventoInterno;

        /* 
           Cada vez que una moto circula, pierde 10 unidades de presion de inflado. 
        Al llegar a 0 o menos su presion de inflado
        deberá ejecutarse un evento. 
        Dicho evento lo que hará es setear la moto como no reparada y tambien lanzará una excepcion de tipo
        rueda en llanta.

        Comprobar que la excepcion se lanza correctamente,que la presion de la rueda queda en 0,
        y que la moto no queda reparada.
         */

        public Moto(float presionInflado, string patente) : base(presionInflado, 200, patente)
        {
            this.EventoInterno += DejarDeCircular;
        }

        public Moto() : base()
        {
            this.EventoInterno += DejarDeCircular;
        }

        private void DejarDeCircular()
        {
            this.estaInflado = false;
            this.presionInflado = 0;
            this.estaReparado = false;
            throw new RuedaEnLLantaException();
        }



        public bool EstaInflado { get => base.estaInflado; set => base.estaInflado = value; }
        public bool  EstaReparado { get => base.estaReparado; set => base.estaReparado = value; }

        public override void CircularVehiculo()
        {
            this.presionInflado -= 10;
            if(this.presionInflado <= 0)
            {
                this.EventoInterno?.Invoke();
            }           
        }

        public void Reparar()
        {
            this.estaReparado = true;
        }
    }
}
