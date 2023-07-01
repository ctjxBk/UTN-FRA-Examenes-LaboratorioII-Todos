using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class ComiqueriaException : Exception , IArchivoTexto
    {
        private Exception ex;
        private string msg;
        public ComiqueriaException(string mensaje, Exception innerException) : base(mensaje, innerException)  
        {
            this.msg = mensaje;
            this.ex = innerException;
            ArchivoTexto.Escribir(this, true);
        }

        public string Ruta
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),"log.txt");
            }
        }

        public string Texto
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
                sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

                int contador = 1;
                sb.AppendLine($"Error nº{contador}: {msg}");

                Exception inner = ex;
                while(inner != null)
                {
                    contador++;
                    sb.AppendLine($"Error nº{contador}: {inner.Message}");
                    inner = inner.InnerException;
                }
                sb.AppendLine($"{Environment.NewLine}------------------------------------{Environment.NewLine}");

                return sb.ToString();   
            }
        }
    }
}
