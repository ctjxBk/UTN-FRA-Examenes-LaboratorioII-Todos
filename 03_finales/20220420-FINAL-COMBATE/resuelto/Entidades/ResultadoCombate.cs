﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //14:40
    public class ResultadoCombate
    {
        private DateTime fechaCombate;
        private string nombreGanador;
        private string nombrePerdedor;

        public DateTime Fecha { get => fechaCombate; set => fechaCombate = value; }
        public string Ganador { get => nombreGanador; set => nombreGanador = value; }
        public string Perdedor { get => nombrePerdedor; set => nombrePerdedor = value; }

        public ResultadoCombate()
        {
            //para el XML
        }
        public ResultadoCombate(string nombreGanador, string nombrePerdedor, DateTime fecha)
        {
            this.Ganador=nombreGanador;
            this.Perdedor=nombrePerdedor;
            this.Fecha=fecha;
        }
    }
}
