using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Archivos
{
    public class Binario
    {
        public void Guardar(Empleado empleado)
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.bin");

                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream myStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(myStream, empleado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar Binario", ex);
            }
        }

        public Empleado Leer()
        {
            try
            {
                Empleado empleado = null;
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, "empleado.bin");

                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream myStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    empleado = formatter.Deserialize(myStream) as Empleado;
                }
                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer Binario", ex);
            }
        }

    }
}
