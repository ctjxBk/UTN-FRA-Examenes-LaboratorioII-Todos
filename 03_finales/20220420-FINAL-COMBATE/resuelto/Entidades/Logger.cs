using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Logger
    {
        private string ruta;

        public Logger(string ruta)
        {
            this.ruta = ruta;
        }

        public void Guardar(string texto)
        {
            bool apenda = true;
            using (StreamWriter streamWriter = new StreamWriter(this.ruta, apenda))
            {
                streamWriter.WriteLine(texto);
            }
        }
    }
}
