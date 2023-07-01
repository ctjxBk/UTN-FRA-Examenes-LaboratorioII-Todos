using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{    
    public class Juego
    {
        private static short velocidad;
        private short ubicacion;
        private object controlVisual;

        public Juego(short ubicacion, object objetoVisual)
        {
            this.ubicacion = ubicacion;
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

        public short Avanzar()
        {
            this.ubicacion += velocidad;
            return this.ubicacion;
        }

        /// <summary>
        /// Simular la animación del Carrusel
        /// </summary>
        public void IniciarCarrusel()
        {
            do
            {
                System.Threading.Thread.Sleep(60 + Juego.velocidad);
            } while (true);
        }
    }
}
