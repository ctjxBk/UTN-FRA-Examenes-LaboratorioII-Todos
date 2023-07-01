using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //13:40 - 15:45 funciona correctamente

   //Crear un constructor que reciba y asigne el/los atributos de la misma.
   //La clase debe ser abstracta.
   //Crear un método abstracto llamado MostrarArchivos que retorne void.
    public abstract class Almacenador
    {
        protected int capacidad;
        public event Action<string> MostrarInfo;

        public Almacenador(int capacidad)
        {
            this.capacidad = capacidad;
        }

        public abstract void MostrarArchivos();

        public void DispararEvento(Archivo archivo)
        {
            this.MostrarInfo?.Invoke((string)archivo);
        }
    }
}
