using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //20:35 -> 21:15 
    public enum SistemaOperativo { ANDROID, IOS}
    public abstract class Aplicacion
    {
        protected string nombre;
        protected SistemaOperativo sistemaOperativo;
        protected int tamanioMb;

        public SistemaOperativo SistemaOperativo { get => sistemaOperativo; }
        public abstract int Tamanio { get ; }

        public Aplicacion(string nombre, SistemaOperativo sistemaOperativo, int tamanioMb)
        {
            this.nombre = nombre;
            this.sistemaOperativo = sistemaOperativo;
            this.tamanioMb = tamanioMb;
        }

        public static implicit operator Aplicacion(List<Aplicacion> listaApp)
        {
            int maximo = 0;
            int posicion = 0;
            if(listaApp is not null)
            {
                int largo = listaApp.Count;
                if(largo > 0)
                {
                    for (int i = 0; i < largo; i++)
                    {
                        if (i == 0)
                        {
                            posicion = i;
                            maximo = listaApp[i].Tamanio;
                        }
                        else
                        {
                            if (listaApp[i].Tamanio > maximo)
                            {
                                posicion = i;
                                maximo = listaApp[i].Tamanio;
                            }
                        }
                    }
                    return listaApp[posicion];
                }                
            }
            return null;
        }


        public virtual string ObtenerInformacionApp()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Sistema Operativo: {this.sistemaOperativo}");
            sb.AppendLine($"Tamaño ocupado: {this.Tamanio}{Environment.NewLine}");
            return sb.ToString();
        }

        public static bool operator ==(List<Aplicacion> listaApp, Aplicacion app)
        {
            if(listaApp is not null && app is not null)
            {
                foreach(Aplicacion aplicacion in listaApp)
                {
                    if(aplicacion.nombre == app.nombre)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(List<Aplicacion> listaApp, Aplicacion app)
        {
            return !(listaApp == app);
        }

        public static bool operator +(List<Aplicacion> listaApp, Aplicacion app)
        {
            if (listaApp != app)
            {
                listaApp.Add(app);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.nombre}";
        }


    }
}
