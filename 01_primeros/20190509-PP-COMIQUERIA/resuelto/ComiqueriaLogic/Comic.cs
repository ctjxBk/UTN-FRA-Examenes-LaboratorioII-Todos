using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Comic : Producto
    {
        public enum TipoComic { Occidental, Oriental}
        private string autor;
        private TipoComic tipoComic;

        public Comic(string descripcion, int stock, double precio, string autor, TipoComic tipoComic)
            : base(descripcion, stock, precio)
        {
            this.tipoComic = tipoComic;
            this.autor = autor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("Autor: {0}{1}",this.autor,Environment.NewLine);
            sb.AppendLine(String.Format("Tipo de Comic: {0}",this.tipoComic));
            return sb.ToString();
        }
    }
}
