using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{
    public class Universidad
    {
        List<Carrera> listaCarreras;
        int capacidad;

        public List<Carrera> ListaCarreras { get => listaCarreras; }

        public event Action<bool> cupoLleno;

        public Universidad(int cupo)
        {
            this.capacidad = cupo;
            listaCarreras = new List<Carrera>();
        }

        public List<Carrera> AgregarNuevaCarrera()
        {

            if (listaCarreras.Count <= capacidad)
            {
                listaCarreras.Add(GeneradorDeDatos.GetUnaCarrera);
            }
            else
            {
                cupoLleno.Invoke(true);
            }

            return ListaCarreras;

        }

    }
}
