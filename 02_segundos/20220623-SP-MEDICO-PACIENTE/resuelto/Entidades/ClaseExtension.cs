using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClaseExtension 
    {
        public static void BorrarMedico(this Serializador<PersonalMedico, PersonalMedico> medico, string path)
        {
            File.Delete(path);
        }
    }
}
