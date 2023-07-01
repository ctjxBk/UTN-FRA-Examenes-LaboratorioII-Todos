using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{
    public class Universidad
    {
        List<Carrera> listaCarreras;//no modificar
        int capacidad;//no modificar
        public Action<bool> cupoLleno;

        public List<Carrera> ListaCarreras { get => listaCarreras; }//no modificar

        public Universidad(int cupo) //no modificar metodo
        {
            this.capacidad = cupo;
            listaCarreras = new List<Carrera>();
        }
      

        // completar metodo
        public List<Carrera> AgregarNuevaCarrera()
        {
            if(this.capacidad > this.ListaCarreras.Count)
            {
                this.listaCarreras.Add(GeneradorDeDatos.GetUnaCarrera);
            }
            else
            {
                this.cupoLleno?.Invoke(true);
            }

            return ListaCarreras;
        }

    }
}
