using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Archivos
{
    public class Texto : IArchivo<Queue<Patente>>
    {
        public void Guardar(string archivo, Queue<Patente> datos)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, archivo);
                bool apenda = true;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    foreach(Patente patente in datos)
                    {
                        stream.WriteLine(patente.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error al guardar texto plano", ex);
            }
        }

        public void Leer(string archivo, out Queue<Patente> datos)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = Path.Combine(ruta, archivo);
                using (StreamReader stream = new StreamReader(path))
                {
                    string line;
                    Queue<Patente> patentes = new Queue<Patente>();    
                    while ((line = stream.ReadLine()) != null)
                    {
                        Patente patente = line.ValidarPatente();
                        patentes.Enqueue(patente);
                    }
                    datos = patentes;
                }
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error al guardar texto plano", ex);
            }
        }
    }
}
