using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{
    public class Universidad
    {
        List<Carrera> listaCarreras;//no modificar
        int capacidad;//no modificar

        public List<Carrera> ListaCarreras { get => listaCarreras; }//no modificar

        public Universidad(int cupo) //no modificar metodo
        {
            this.capacidad = cupo;
            listaCarreras = new List<Carrera>();
        }
      

        // completar metodo
        public List<Carrera> AgregarNuevaCarrera()
        {
        
            listaCarreras.Add(GeneradorDeDatos.GetUnaCarrera);

            return ListaCarreras;
        }

    }
}
