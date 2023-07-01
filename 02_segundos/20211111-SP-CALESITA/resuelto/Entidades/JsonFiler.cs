using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public class JsonFiler<T> : IMetodosArchivos<T>
    {
        public string archivo;//nombre solo, SIN PATH
        public T objeto;


        public string GenerarRutacompleta
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                return path + @"\\";
            }
        }

        public bool ExisteArchivo(string nombreArchivo)
        {
            //string aux = this.GenerarRutacompleta;
            //string path = Path.Combine(this.GenerarRutacompleta,nombreArchivo);
            return File.Exists(this.GenerarRutacompleta + nombreArchivo);
        }

        public void Guardar(string archivo, T objeto)
        {
            try
            {
                string path = this.GenerarRutacompleta + archivo;
                if (!this.ExisteArchivo(archivo))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(objeto, opciones);
                    stream.WriteLine(json);
                }

            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException($"Error al Guardar (Serializar) \n. {ex.Message}", ex);
            }

        }

        public void Leer(string archivo, out T objeto)
        {
            try
            {
                string path = this.GenerarRutacompleta + archivo;
                if (!this.ExisteArchivo(archivo))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                
                using (StreamReader stream = new StreamReader(path))
                {
                    string json = stream.ReadToEnd();
                    objeto = JsonSerializer.Deserialize<T>(json);
                }

            }
            catch(Exception ex)
            {
                throw new ErrorArchivosException($"Error al Leer (Deserializar) \n. {ex.Message}", ex);
            }
        }
    }
}
