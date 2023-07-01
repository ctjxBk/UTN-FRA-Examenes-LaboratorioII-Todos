using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caballo : Animal
    {
        private bool corredor;

        public override bool ComeBalanceado
        {
            get
            {
                return false;
            }
        }

        public override bool ComePasto
        {
            get
            {
                return true;
            }
        }


        public Caballo(string nombre, int kilosAlimento, bool corredor) : base(nombre, kilosAlimento)
        {
            this.corredor = corredor;
        }

        public override string Datos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Datos());
            sb.AppendLine(String.Format("Es de carreras: {0}",this.corredor ? "SI" : "NO"));
            return sb.ToString();
        }

    }
}
