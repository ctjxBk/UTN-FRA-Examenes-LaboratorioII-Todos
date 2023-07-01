using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Logger
    {
        public static void Log(string mensaje)
        {
            try
            {
                //podria usar esto si se que se instancio ALMENOS un payaso
                //string path = Payaso.rutaArchivo;
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(escritorio, "payaso.json");
                bool apenda = true;
                using (StreamWriter streamWriter = new StreamWriter(path, apenda))
                {
                    streamWriter.WriteLine($"Fecha {DateTime.Now} - {mensaje}");

                }
            }
            catch (Exception ex)
            {
                throw new DatosException($"Error al usar Looger.Log() {Environment.NewLine} {ex.Message}");
            }
        }
    }
}
