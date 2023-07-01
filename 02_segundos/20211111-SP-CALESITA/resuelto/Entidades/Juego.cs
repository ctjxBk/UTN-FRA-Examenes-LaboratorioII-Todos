using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{    
    //20:30 a 20:45
    //21:05 a 22:45 sin test, 23:18 con test

    public delegate void InformacionDeAvance(object sender, short movimiento);

    public class Juego
    {
        private object controlVisual;
        private short ubicacion;
        private static short velocidad;
        public event InformacionDeAvance InformarAvance;
        private CancellationTokenSource cancelTask;

        public Juego()
        {
            //para serializar
        }

        public Juego(short ubicacion, object objetoVisual)
        {
            if(Juego.velocidad == 0)
            {
                Juego.velocidad = 8;
            }

            this.Ubicacion = ubicacion;
            this.controlVisual = objetoVisual;
        }

        [System.Text.Json.Serialization.JsonIgnore]
        public object ControlVisual
        {
            get
            {
                return this.controlVisual;
            }
            set
            {
                this.controlVisual = value;
            }
        }

        [System.Text.Json.Serialization.JsonIgnore]
        public CancellationTokenSource CancelTask
        {
            set
            {
                this.cancelTask = value;
            }
        }

        public short Ubicacion { get => ubicacion; set => ubicacion = value; }
        public short Velocidad { get => Juego.velocidad; set => Juego.velocidad = value; }

        public short Avanzar()
        {
            this.Ubicacion += Velocidad;
            this.InformarAvance?.Invoke(this.controlVisual,this.Ubicacion);
            return this.Ubicacion;
        }

        /// <summary>
        /// Simular la animación del Carrusel
        /// </summary>
        public void IniciarCarrusel()
        {
            while(!cancelTask.IsCancellationRequested)//do
            {
                this.Avanzar();
                Thread.Sleep(60 + Juego.velocidad);
            }// while (true);
        }

        //para el test, no funciona en Asser.AreEquals
        public static bool operator ==(Juego j1, Juego j2)
        {
            return j1.ubicacion == j2.ubicacion;
        }

        public static bool operator !=(Juego j1, Juego j2)
        {
            return !(j1 == j2);
        }
    }
}
