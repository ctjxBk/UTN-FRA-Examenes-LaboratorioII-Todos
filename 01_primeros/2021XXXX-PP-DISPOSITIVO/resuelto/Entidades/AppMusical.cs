using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AppMusical : Aplicacion
    {

        private List<string> listaCanciones;
        
        public override int Tamanio => tamanioMb + listaCanciones.Count * 2;

        public AppMusical(string nombre, SistemaOperativo sistemaOperativo, int tamanioMb) 
            : base(nombre, sistemaOperativo, tamanioMb)
        {
            this.listaCanciones = new List<string>();
        }

        public AppMusical(string nombre, SistemaOperativo sistemaOperativo, int tamanioMb, List<string> listaCanciones)
            : this(nombre, sistemaOperativo, tamanioMb)
        {
            this.listaCanciones = listaCanciones;
        }


        public override string ObtenerInformacionApp()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ObtenerInformacionApp());
            if (listaCanciones.Count == 0)
            {
                sb.AppendLine("No tiene canciones");
            }
            else
            {
                sb.AppendLine("Lista de canciones: ");
                foreach (string cancion in listaCanciones)
                {
                    sb.AppendLine(cancion);
                }
            }
            return sb.ToString();
        }

    }
}
