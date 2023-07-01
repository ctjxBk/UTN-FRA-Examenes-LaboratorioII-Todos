using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{
    //14:45 -16:00 sin test
    //16:30 termine los test (me mate en un error tonto en el segundo test)
    public class Votacion
    {
        public enum EVoto { Afirmativo, Negativo, Abstencion, Esperando }

        private string nombreLey;
        private Dictionary<string, EVoto> senadores;

        private short contadorAfirmativo;
        private short contadorNegativo;
        private short contadorAbstencion;
        public delegate void Voto(string senador, Votacion.EVoto voto);
        public event Voto EventoVotoEfectuado;

        public string NombreLey { get => nombreLey; set => nombreLey = value; }
        public short ContadorAfirmativo { get => contadorAfirmativo; set => contadorAfirmativo = value; }
        public short ContadorNegativo { get => contadorNegativo; set => contadorNegativo = value; }
        public short ContadorAbstencion { get => contadorAbstencion; set => contadorAbstencion = value; }



        //se creo para la segunda prueba unitaria
        private int cantidadDeEventos;
        public int CantidadDeEventos { get => cantidadDeEventos; }
        public void VerificarEventos(string senador, Votacion.EVoto voto)
        {
            this.cantidadDeEventos++;   
        }


        public Votacion()
        {
            //para la serialización
        }

        public Votacion(string nombreLey, Dictionary<string, EVoto> senadores)
        {
            this.nombreLey = nombreLey;
            this.senadores = senadores;
            //para el test . igualmente C# los enteros los inicializa en cero
            this.cantidadDeEventos = 0;
        }

        public void Simular()
        {
            // Reseteo contadores
            this.contadorAbstencion = 0;
            this.contadorAfirmativo = 0;
            this.contadorNegativo = 0;
            // Itero todos los Senadores
            for (int index = 0; index < this.senadores.Count; index++)
            {
                // Duermo el hilo
                //System.Threading.Thread.Sleep(2134);
                System.Threading.Thread.Sleep(10);

                // Leo el senador actual
                KeyValuePair<string, EVoto> k = this.senadores.ElementAt(index);
                // Generador de número aleatorio
                Random r = new Random(k.Key.ToString().Length + DateTime.Now.Millisecond);
                // Modifico el voto de forma aleatoria
                this.senadores[k.Key] = (EVoto)r.Next(0, 3);

                // Invocar Evento
                this.EventoVotoEfectuado?.Invoke(k.Key,this.senadores[k.Key]);


                // Incrementar contadores

                if (this.senadores[k.Key] == EVoto.Afirmativo)
                {
                    contadorAfirmativo++;
                }
                else if (this.senadores[k.Key] == EVoto.Negativo)
                {
                    contadorNegativo++;
                }
                else if (this.senadores[k.Key] == EVoto.Abstencion)
                {
                    contadorAbstencion++;
                }

            }

            this.ContadorAbstencion = contadorAbstencion;
            this.ContadorAfirmativo = contadorAfirmativo;
            this.ContadorNegativo = contadorNegativo;
        }

        public static bool Guardar(string rutaArchivo, Votacion votacion)
        {
            try
            {
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(rutaArchivo, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Votacion));
                    serializer.Serialize(stream, votacion);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al guardar en XML",ex);
            }

        }
    }
}
