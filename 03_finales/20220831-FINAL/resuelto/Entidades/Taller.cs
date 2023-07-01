using System.Collections.Generic;

namespace Entidades
{
    public class Taller<T> where T : IInflable
    {
        public static List<Auto> ObtenerAutos()
        {
            return ManejadorSql.ObtenerAutos();
        }

        public static void RegistrarVehiculo(Vehiculo auto)
        {
            ManejadorSql.InsertarVehiculo(auto);
        }

        /* 
   Generar un metodo estatico,generico y parametrizado en Taller llamado UtilizarInflador
   que reciba un elemento del tipo T (restringir que sea de tipo IInflable)
   Crear dos objetos de tipo IInflable e inflarlos.
   Verificar que ambos estan inflados.
*/
        public static bool UtilizarInflador<T>(T dato) where T : IInflable
        {
            dato.Inflar(dato.PresionMaxima);
            return dato.EstaInflado;
        }

        public static void Reparar(Auto vehiculo)
        {
            vehiculo.Reparar();
        }


    }
}
