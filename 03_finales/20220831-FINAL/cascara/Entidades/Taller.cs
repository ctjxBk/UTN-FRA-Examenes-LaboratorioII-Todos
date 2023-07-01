using System.Collections.Generic;

namespace Entidades
{
    public class Taller<T> where T : IInflable
    {
        public static List<Auto> ObtenerAutos()
        {
            return null;
        }

        public static void RegistrarVehiculo(Vehiculo auto)
        {
          
        }

        public static bool UtilizarInflador(T dato)
        {
            return false;
  
        }

        public static void Reparar(Auto vehiculo)
        {
            vehiculo.Reparar();
        }


    }
}
