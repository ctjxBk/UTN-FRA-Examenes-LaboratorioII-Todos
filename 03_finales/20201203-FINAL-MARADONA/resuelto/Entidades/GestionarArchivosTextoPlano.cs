using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GestionarArchivosTextoPlano : PersistirDatos
    {
        private static string path;

        static GestionarArchivosTextoPlano()
        {
            GestionarArchivosTextoPlano.path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            GestionarArchivosTextoPlano.path = Path.Combine(path, "log.txt");
        }

        public static string Ruta { get => path; set => path = value; }

        public void Guardar(string mensaje)
        {
            try
            {
                bool apenda = true;
                using (StreamWriter stream = new StreamWriter(GestionarArchivosTextoPlano.path, apenda))
                {
                    stream.WriteLine(mensaje);
                }
            }
            catch (Exception ex)
            {

                throw new ExcepcionPersonalizada("Error al GUARDAR un texto plano", ex);
            }

        }

        public List<string> Leer()
        {
            try
            {
                List<string> lista = new List<string>();
                using (StreamReader stream = new StreamReader(path))
                {
                    //Console.WriteLine(stream.ReadToEnd());
                    string linea;
                    while ((linea = stream.ReadLine()) != null)
                    {
                        lista.Add(linea);
                    }
                    return lista;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ExcepcionPersonalizada("Error al LEER un texto plano, NO EXISTE EL ARCHIVO (puede que sea la primera ejecución)", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new ExcepcionPersonalizada("Error al LEER un texto plano, NO EXISTE EL DIRECTORIO", ex);
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al LEER un texto plano", ex);
            }
        }
    }
}
