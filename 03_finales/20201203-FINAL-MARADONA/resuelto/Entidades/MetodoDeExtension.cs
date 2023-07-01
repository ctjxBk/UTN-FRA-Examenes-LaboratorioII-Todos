using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public static class MetodoDeExtension
    {
        public static string UltimoCaracter(this PictureBox picture)
        {
            return picture.Name[picture.Name.Length - 1].ToString();
        }
    }
}
