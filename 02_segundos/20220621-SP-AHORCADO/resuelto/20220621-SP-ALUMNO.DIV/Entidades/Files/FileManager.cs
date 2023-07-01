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
//4.FileManager será estática.
//  a.En el constructor de clase realizar: 
//      i.En el atributo path se almacenará la referencia al escritorio de la pc.
//      Y se le concatenara un el nombre de la carpeta del parcial: ej {path escritorio}
//          +\\20220621SP\\
//      ii.Llamar al método ValidaExistenciaDeDirectorio.
//  b.ValidaExistenciaDeDirectorio:
//      i.Si no existe el directorio almacenado en path, se creará.
//      ii.En caso de producirse una excepción al momento de la creación, esta deberá ser capturada
//      y relanzada en una nueva excepción denominada FileManagerException,
//      la cual contendrá el mensaje: “Error al crear el directorio”.
//  c.Guardar:
//      i.Será genérico y solo permitirá que los elementos a almacenar sean tipos por referencia.
//      ii.Validar la extensión del nombre del archivo. En caso de que sea:
//          1.JSON, se serializará el elemento recibido.
//          2.TXT, se almacena en texto plano.
//          3.Cualquier otra extensión se lanzará una excepción denominada FileManagerException,
//          la cual contendrá el mensaje “Extensión no permitida”.

    //20:20
    //10:20 / 10:45
    public static class FileManager
    {
        private static string path;

        static FileManager()
        {
            FileManager.ValidaExistenciaDeDirectorio();

        }

        private static void ValidaExistenciaDeDirectorio()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "20220621SP");
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileManager.path = path;
            }
            catch (Exception ex)
            {
                throw new FileManagerException("Error al crear un directorio",ex);
            }           
        }

        public static void Guardar<T>(T elemento, string nombreArchivo)
            where T : class
        {
            string extension = Path.GetExtension(nombreArchivo);
            string path = Path.Combine(FileManager.path,nombreArchivo);
            if (extension == ".json")
            {
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(elemento, opciones);
                    stream.WriteLine(json);
                }

            }
            else if(extension == ".txt")
            {
                //File.WriteAllText(path, elemento.ToString());
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    stream.Write(elemento.ToString());
                }
            }
            else
            {
                throw new FileManagerException("Extensión no permitida");
            }
        }

    }
}
