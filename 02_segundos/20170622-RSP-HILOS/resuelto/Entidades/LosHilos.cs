using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Entidades
{
    //21:00 a 21:15;
    //23:40 a 00:30
    public class LosHilos : IRespuesta<int>
    {

        private int id;
        private List<InfoHilo> misHilos;
        public event Action<string> AvisoFin;
        public event Action<Exception> MensajeError;

        public string Bitacora
        {
            get
            {
                try
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "bitacora.txt");
                    using (StreamReader stream = new StreamReader(path))
                    {
                        return stream.ReadToEnd();
                        //string line;
                        //while ((line = stream.ReadLine()) != null)
                        //{
                        //    Console.WriteLine(line);
                        //}
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error al leer el archivo{Environment.NewLine}{ex.Message}");
                }
            }

            set
            {
                try
                {
                    bool apenda = true;
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "bitacora.txt");
                    using (StreamWriter stream = new StreamWriter(Path.Combine(path), apenda))
                    {
                        stream.WriteLine(value);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error al guardar el archivo{Environment.NewLine}{ex.Message}");
                }

            }
        }

        private LosHilos AgregarHilo(LosHilos hilos)
        {
            this.id++;
            InfoHilo nuevoHilo = new InfoHilo(id, hilos);
            
            this.misHilos.Add(nuevoHilo);
            return hilos;
        }

        public LosHilos()
        {
            //esto lo hace automaticámente C# de inicializar el entero en CERO
            this.id = 0;
            this.misHilos = new List<InfoHilo>();
        }

        public static LosHilos operator +(LosHilos hilos, int cantidad)
        {
            if(hilos is not null)
            {
                if(cantidad < 0)
                {
                    throw new CantidadInvalidadException("Cantidad invalida");
                }
                else
                {
                    //for (int i = 1; i <= cantidad; i++)
                    //{
                        hilos.AgregarHilo(hilos);
                    //}
                }
            }
            return hilos;
        }



        public void RespuestaHilo(int id)
        {
            string mensaje = $"Terminó el hilo {id}.";
            try
            {
                this.Bitacora = mensaje;
                
            }
            catch(Exception ex)
            {
                this.MensajeError?.Invoke(ex);
            }

            this.AvisoFin?.Invoke(mensaje);
        }
    }
}
