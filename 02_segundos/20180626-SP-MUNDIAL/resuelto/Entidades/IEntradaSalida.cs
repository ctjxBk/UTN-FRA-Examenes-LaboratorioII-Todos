using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Grupo))]
    [XmlInclude(typeof(Torneo))]
    public interface IEntradaSalida<Z>
    {
        Z Leer();

        Z Guardar();
    }
}
