using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{
    public class Empresa 
    {
        List<Puesto> posicionesAbiertas;
        int cantPuestosACubrir;
        public event Action<bool> BusquedasRealizadas;

        public Empresa(int puestosACubrir)
        {
            this.cantPuestosACubrir = puestosACubrir;
            posicionesAbiertas = new List<Puesto>();
        }

        public List<Puesto> Posiciones { get => posicionesAbiertas;}

        public List<Puesto> AbrirBusqueda()
        {
            while(this.cantPuestosACubrir != this.posicionesAbiertas.Count)
            {
                this.posicionesAbiertas.Add(GeneradorDeDatos.GetUnPuesto);
            }
            this.BusquedasRealizadas?.Invoke(true);
            return this.posicionesAbiertas;

            //return null;
        }

    }
}
