using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20210717_RSP___alumno
{
    public class Carrera
    {
        public delegate void InformacionDeAvance();
        public delegate void InformacionLlegada(string mensaje);

        public event InformacionDeAvance InformarAvance;
        public event InformacionLlegada InformarLlegada;

        List<AutoF1> autos;
        int kms;

        public List<AutoF1> Autos{ get => autos ; set => autos = value; }
        public int Kms{ get; set; }

        public Carrera()
        {

        }

        public Carrera(int kms)
        {
            this.autos = new List<AutoF1>();
            this.kms = kms;
        }

        public void IniciarCarrera()
        {
            GestorBaseDeDatos gdb = new GestorBaseDeDatos();
            GestorDeArchivos gda = new GestorDeArchivos("Resultados-Carrera.txt");
            int autoEnMeta = 0;

            if (this.InformarAvance != null)
            {
                do
                {
                    foreach (AutoF1 auto in this.autos)
                    {
                        auto.Acelerar();
                        this.InformarAvance.Invoke();
                        Thread.Sleep(10);
                        if (auto.UbicacionEnPista > this.kms && auto.Posicion == 0)
                        {
                            autoEnMeta++;
                            auto.Posicion = autoEnMeta;
                            gdb.Guardar(auto);
                            ((IGuardar<AutoF1>)gda).Guardar(auto);
                            if (this.InformarLlegada != null)
                            {
                                this.InformarLlegada.Invoke($"Llegada de {auto.Escuderia}");
                            }
                        }
                    }
                } while (autoEnMeta < this.autos.Count);
            }


        }

        public static Carrera operator +(Carrera carrera, AutoF1 auto)
        {

            carrera.Autos.Add(auto);
            return carrera;
        }
    }
}
