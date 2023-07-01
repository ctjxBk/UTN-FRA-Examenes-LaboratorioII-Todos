using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibraries
{
    public interface IParlamento
    {
        bool AperturaSesion { set; }
        bool Presentismo { get; set; }
        Evoto Voto { get; set; }
        void EmitirVoto();
    }
}
