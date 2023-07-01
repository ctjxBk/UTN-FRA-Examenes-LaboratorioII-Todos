using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    //9.	Extenderá la clase String la cual adicionará un método denominado
    //    ObtenerNombreYApellido en el cual su función principal será devolver un
    //    array de strings, mediante la separación de la cadena en subcadenas.
    //    El carácter para determinar la separación será el guion medio.
    public static class StringExtension
    {
        public static string[] ObtenerNombreYApellido(this string nombreYApellido)
        {
            return nombreYApellido.Split("-");
        }
    }
}
