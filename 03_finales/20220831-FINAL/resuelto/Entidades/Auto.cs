using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo, IInflable
    {
        public Auto() : base()
        {

        }
        public Auto(int presionInflado, string patente) : base(presionInflado, 300, patente)
        {

        }

        private void ArreglarMecanica()
        {
            Task tarea = Task.Run(() =>
            {
                Thread.Sleep(7000);
                this.estaReparado = true;
            });

            Task tarea2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                this.Inflar(this.presionMaxima);
            });

            Task.WaitAll(tarea,tarea2);
        }

        public void Reparar()
        {
            this.ArreglarMecanica();
        }

        public override void CircularVehiculo()
        {
            this.presionInflado -= 10;
        }
    }
}
