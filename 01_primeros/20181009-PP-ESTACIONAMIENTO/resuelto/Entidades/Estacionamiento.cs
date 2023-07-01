using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //11:05 - 12:15 la lógica
    //12:20 el formulario
    public class Estacionamiento
    {
        private int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;

        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        public Estacionamiento(string nombre, int espacioDiponible)
            : this()
        {
            this.nombre = nombre;
            this.espacioDisponible = espacioDiponible;
        }

        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb = new StringBuilder();

            if(e is not null)
            {
                sb.AppendLine($"Nombre: {e.nombre}");
                if(e.vehiculos.Count > 0)
                {
                    sb.AppendLine($"Listado de Vehiculos:");
                    foreach(Vehiculo vehiculo in e.vehiculos)
                    {
                        if(vehiculo is Moto)
                        {
                            sb.AppendLine(((Moto)vehiculo).ConsultarDatos());
                        }
                        else if (vehiculo is PickUp)
                        {
                            sb.AppendLine(((PickUp)vehiculo).ConsultarDatos());
                        }
                        else// if (vehiculo is Automovil)
                        {
                            sb.AppendLine(((Automovil)vehiculo).ConsultarDatos());
                        }
                    }
                }
                else
                {
                    sb.AppendLine($"No hay Vehiculos.");
                }
            }

            return sb.ToString();
        }

        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {
            if(e is not null && v is not null)
            {
                foreach(Vehiculo vehiculo in e.vehiculos)
                {
                    if(v == vehiculo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }

        public static string operator -(Estacionamiento estamiento, Vehiculo vehiculo)
        {
            if(estamiento is not null && vehiculo is not null)
            {
                if(estamiento == vehiculo)
                {
                    //esto esta mal, remove mira el espacio de memoria
                    //estamiento.vehiculos.Remove(vehiculo);
                    for(int i = 0; i < estamiento.vehiculos.Count; i++)
                    {
                        if(estamiento.vehiculos[i] == vehiculo)
                        {
                            estamiento.vehiculos.RemoveAt(i);
                            return vehiculo.ImprimirTicket();
                        }
                    }
                }
            }
            return "El vehículo no es parte del estacionamiento";
        }

        public static Estacionamiento operator +(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            if(estacionamiento is not null && vehiculo is not null)
            {
                if(estacionamiento != vehiculo)
                {
                    if(vehiculo.Patente is not null)
                    {
                        if (estacionamiento.vehiculos.Count < estacionamiento.espacioDisponible)
                        {
                            estacionamiento.vehiculos.Add(vehiculo);
                        }
                    }
                }
            }
            return estacionamiento;
        }

    }

}
