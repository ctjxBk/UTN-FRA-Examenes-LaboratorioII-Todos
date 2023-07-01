using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public static class ArchivoTexto
    {
        public static void Escribir(IArchivoTexto archivo, bool append)
        {

            try
            {
                using (StreamWriter stream = new StreamWriter(archivo.Ruta, append, Encoding.UTF8))
                {
                    stream.Write(archivo.Texto);
                }
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException("Error al usar Escribir de ArchivoTexto.cs", ex);
            }
        }

        public static string Leer(string ruta)
        {
            try
            {
                using (StreamReader stream = new StreamReader(ruta))
                {
                    return stream.ReadToEnd();
                    //string line;
                    //while ((line = stream.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(line);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException("Error al usar Escribir de ArchivoTexto.cs", ex);
            }
        }
    }
}

