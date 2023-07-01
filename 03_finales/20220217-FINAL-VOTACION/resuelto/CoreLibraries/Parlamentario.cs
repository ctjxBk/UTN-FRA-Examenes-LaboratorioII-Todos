using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibraries
{
    public abstract class Parlamentario
    {
        protected string nombreCompleto;

        protected Parlamentario(string nombreCompleto)
        {
            this.nombreCompleto = nombreCompleto;
        }

        public abstract void EmitirVoto();

        public virtual bool AperturaSesion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
