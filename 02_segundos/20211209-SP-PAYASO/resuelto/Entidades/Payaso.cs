using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    //20:20
    public class Payaso
    {
        private DateTime fecha;
        private string nombre;
        public static string rutaArchivo;
        private int viajesAlcantarilla;
        public event DesplegarGlobos AparecerGlobo;
        private CancellationTokenSource cancelTask;

        public Payaso(string nombre, DateTime fecha, string nombreArchivo)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            string rutaDelEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            rutaArchivo = Path.Combine(rutaDelEscritorio, nombreArchivo);
            this.viajesAlcantarilla = fecha.CalcularDiferenciaEnDias();
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int ViajesAlcantarilla { get => viajesAlcantarilla; set => viajesAlcantarilla = value; }
        public CancellationTokenSource CancelTask { set => cancelTask = value; }

        public void Flotar()
        {
            for(int i = 0; i < 5; i++)
            {
                if (this.cancelTask.IsCancellationRequested)
                {
                    break;
                }
                this.AparecerGlobo?.Invoke(i);
                Thread.Sleep(2000);
            }

            try
            {
                PayasoDAO.GuardarRegistro(this);
            }
            catch(DatosException ex)
            {
                //solo para molestar, simplemente podría atraparla en la vista 
                //en lugar de atraparlo y levantarlo nuevamente
                throw ex;
            }
        }
        

    }
}
