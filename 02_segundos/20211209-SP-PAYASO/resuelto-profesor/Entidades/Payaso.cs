using System;
using System.IO;
using System.Threading;

namespace Entidades
{
    public delegate void DesplegarGlobos(int index);
    public class Payaso
    {
        public event DesplegarGlobos AparecerGlobo;
        private string nombre;
        private DateTime fecha;
        private int viajesAlcantarilla;
        public static string rutaArchivo;

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int ViajesAlcantarilla { get => viajesAlcantarilla; set => viajesAlcantarilla = value; }

        public Payaso(string nombre, DateTime fecha, string nombreArchivo)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            viajesAlcantarilla = this.fecha.CalcularDiferenciaEnDias();
            rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);
        }

        public void Flotar()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < 5)
                {
                    Thread.Sleep(new Random().Next(2000));
                    AparecerGlobo(i);
                }
            }

            PayasoDAO.GuardarRegistro(this);
        }

    }
}
