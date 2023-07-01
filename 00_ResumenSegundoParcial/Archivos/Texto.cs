using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Archivos
{
    public class Texto
    {
        public void Guardar(string contenido)
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.txt");

                bool apenda = true;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    stream.WriteLine($"{contenido}{Environment.NewLine}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar Texto",ex);
            }
        }

        public void Guardar(Empleado empleado)
        {
            this.Guardar(empleado.ToString());
        }

        public string Leer()
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.txt");

                using (StreamReader stream = new StreamReader(path))
                {
                    return stream.ReadToEnd();
                    //string line;
                    //while ((line = stream.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(line);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Leer Texto",ex);
            }
        }
    }
}
