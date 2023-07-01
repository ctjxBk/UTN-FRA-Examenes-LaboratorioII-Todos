using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades.Files
{
    //    4.	FileManager será estática.
    //a.En el constructor de clase realizar: 
    //i.En el atributo path se almacenará la referencia al escritorio de la pc.Y se le concatenara un el nombre de la carpeta del parcial: ej {path escritorio}
    //+\\20220811_Alumno\\
    //ii.Llamar al método ValidaExistenciaDeDirectorio.
    //b.	ValidaExistenciaDeDirectorio:
    //i.Si no existe el directorio almacenado en path, se creará.
    //ii.	En caso de producirse una excepción al momento de la creación, esta deberá ser capturada y relanzada en una nueva excepción denominada FileManagerException, la cual contendrá el mensaje: “Error al crear el directorio”.
    //c.	Guardar:
    //i.Será genérico y solo permitirá que los elementos a almacenar sean tipos por referencia.
    //ii.	Validar la extensión del nombre del archivo. En caso de que sea:
    //1.JSON, se serializará el elemento recibido.
    //2.	TXT, se almacena en texto plano.
    //3.	Cualquier otra extensión se lanzará una excepción denominada FileManagerException, la cual contendrá el mensaje “Extensión no permitida”.

    public static class FileManager
    {
        private static string path;
        static FileManager()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "20220811_Alumno");
            ValidaExitenciaDeDirectorio();
        }

        public static void Guardar<T>(T elemento, string nombreArhivo) where T : class
        {
            if(elemento is not null && nombreArhivo is not null)
            {
                string extension = Path.GetExtension(nombreArhivo);
                if (extension == ".json")
                {
                    try
                    {
                        string ruta = Path.Combine(path, nombreArhivo);

                        bool apenda = false;
                        using (StreamWriter stream = new StreamWriter(ruta, apenda))
                        {
                            JsonSerializerOptions opciones = new JsonSerializerOptions();
                            opciones.WriteIndented = true;

                            string json = JsonSerializer.Serialize(elemento, opciones);
                            stream.WriteLine(json);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new FileManagerException("Error al guardar JSON", ex);
                    }
                }
                else if(extension == ".txt")
                {
                    try
                    {
                        string ruta = Path.Combine(path, nombreArhivo);

                        bool apenda = true;
                        using (StreamWriter stream = new StreamWriter(ruta, apenda))
                        {
                            stream.WriteLine($"{elemento}{Environment.NewLine}");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new FileManagerException("Error al guardar Texto", ex);
                    }
                }
                else
                {
                    throw new FileManagerException("Extension no permitida");
                }
            }
        }

        public static void ValidaExitenciaDeDirectorio()
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch(Exception ex)
            {
                throw new FileManagerException("Error al crear el directorio",ex);
            }
        }

    }
}
