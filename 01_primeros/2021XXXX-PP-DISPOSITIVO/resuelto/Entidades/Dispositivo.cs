using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Dispositivo
    {
        private static List<Aplicacion> appsInstaladas;
        private static SistemaOperativo sistemaOperativo;

        static Dispositivo()
        {
            Dispositivo.appsInstaladas = new List<Aplicacion>();
            Dispositivo.sistemaOperativo = SistemaOperativo.ANDROID;
        }

        public static bool InstalarApp(Aplicacion app)
        {
            if(app is not null)
            {
                if(app.SistemaOperativo == Dispositivo.sistemaOperativo)
                {
                    //utilizo la sobre carga en Aplicacion.cs
                    return Dispositivo.appsInstaladas + app;
                }
            }
            return false;
        }

        public static string ObtenerInformacionDispositivo()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Aplicacion app in appsInstaladas)
            {
                sb.AppendLine(app.ObtenerInformacionApp());
            }

            return sb.ToString();
        }



    }
}
