using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Deberá heredar de Almacenador e implementar IAlmacenable.
    //Crear un constructor que reciba y asigne el/los atributos de la misma.
    //El método MostrarArchivos lanzará una excepción del tipo NotImplementedException.
    //El método Guardar deberá guardar un objeto de tipo archivo en un archivo de texto en la ubicación definida en el atributo pathArchivos.
    //El método Leer recibirá el nombre de un archivo y deberá retornar su contenido.
    //Tanto en Leer como en Guardar capturar y relanzar las excepciones.
    public class ArchiveroFisico : Almacenador, IAlmacenable<string, Archivo>
    {
        private string pathArchivos;

        public ArchiveroFisico(int capacidad) : base(capacidad)
        {
            
        }

        public bool Guardar(Archivo elemento)
        {
            try
            {
                pathArchivos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), elemento.nombre);
                bool apenda = true;
                using (StreamWriter stream = new StreamWriter(pathArchivos, apenda))
                {
                    //utilizo la sobrecarga del operador explicit en Archivo.cs
                    stream.Write((string)elemento);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al usar .Guardar() en ArchiveroFisico.cs", ex);
            }
        }

        public string Leer(string path)
        {
            try
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), path);
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
                throw new Exception("Error al usar .Leer() en ArchiveroFisico.cs", ex);
            }
        }

        public override void MostrarArchivos()
        {
            throw new NotImplementedException();
        }
    }
}
