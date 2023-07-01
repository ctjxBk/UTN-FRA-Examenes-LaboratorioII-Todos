using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{

    //DESARROLLAR

    public class Empresa
    {
        List<Puesto> posicionesAbiertas;
        int cantPuestosACubrir;
        public event Action<bool> onFinalizar;

        public List<Puesto> Posiciones { get => posicionesAbiertas; }

        public Empresa(int puestosACubrir)
        {
            this.cantPuestosACubrir = puestosACubrir;
            posicionesAbiertas = new List<Puesto>();
        }

        public List<Puesto> AbrirBusqueda()
        {
            while(this.posicionesAbiertas.Count < this.cantPuestosACubrir)
            {
                this.posicionesAbiertas.Add(GeneradorDeDatos.GetUnPuesto);
            }
            this.onFinalizar?.Invoke(true);

            return this.posicionesAbiertas;
        }

    }
}
