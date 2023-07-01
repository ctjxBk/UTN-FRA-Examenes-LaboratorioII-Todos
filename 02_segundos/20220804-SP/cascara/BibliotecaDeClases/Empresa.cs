using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{
    public class Empresa
    {
        List<Puesto> posicionesAbiertas;
        int cantPuestosACubrir;


        public Empresa(int puestosACubrir)
        {
            this.cantPuestosACubrir = puestosACubrir;
            posicionesAbiertas = new List<Puesto>();
        }



        public List<Puesto> AbrirBusqueda()
        {

            return null;
        }

    }
}
