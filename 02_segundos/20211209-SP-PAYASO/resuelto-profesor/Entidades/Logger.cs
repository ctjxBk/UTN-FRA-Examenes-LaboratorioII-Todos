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
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Logs.txt", true, Encoding.UTF8))
                {
                    sw.Write($"{DateTime.Now} {mensaje}");
                }

            }
            catch (Exception ex)
            {
                throw new DatosException("Error en txt");
            }
        }
    }
}
