using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void InformacionAvance();
    public delegate void InformacionLlegada(string mensaje);
    public class Carrera
    {
        private List<AutoF1> autos;
        private int kms;
        public event InformacionAvance InformarAvance;
        public event InformacionLlegada InformarLlegada;
        public event Action<string> MensajeError;

        public List<AutoF1> Autos { get => autos; set => autos = value; }
        public int Kms { get => kms; set => kms = value; }

        public Carrera()
        {
           
        }

        public Carrera(int kms)
        {
            this.kms = kms;
            this.autos = new List<AutoF1>();
        }

        public void IniciarCarrera()
        {
            GestorDeArchivos gestorDeArchivos = new GestorDeArchivos("autos.txt");
            GestorBaseDeDatos gestorBaseDeDatos = new GestorBaseDeDatos();

            int posicion = 0;
            int cantidadDeAutos = this.autos.Count;

            while (posicion != cantidadDeAutos )
            {
                foreach (AutoF1 auto in this.autos)
                {
                    auto.Acelerar();
                    this?.InformarAvance();
                    Thread.Sleep(10);
                    if (auto.UbicacionEnPista > this.kms && auto.Posicion == 0)
                    {
                        posicion++;
                        auto.Posicion = posicion;
                        this?.InformarLlegada(auto.ToString());

                        try
                        {
                            gestorBaseDeDatos.Guardar(auto);
                        }
                        catch (ArchivoException ex)
                        {

                            this?.MensajeError(ex.Message);
                        }

                        try
                        {
                            ((IGuardar<AutoF1>)gestorDeArchivos).Guardar(auto);
                        }
                        catch (ArchivoException ex)
                        {

                            this?.MensajeError(ex.Message);
                        }

                        
                    }
                }
            }
        }

        public static Carrera operator +(Carrera carrera, AutoF1 auto)
        {
            if (carrera is not null && auto is not null)
            {
                carrera.autos.Add(auto);
            }
            return carrera;
        }
    }
}
