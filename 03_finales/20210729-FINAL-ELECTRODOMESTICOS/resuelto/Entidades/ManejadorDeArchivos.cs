using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class ManejadorDeArchivos<T> : ISerializar<T>
    {
        private static string ruta;

        static ManejadorDeArchivos()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ManejadorDeArchivos<T>.ruta = Path.Combine(path, "FinalLabo2021");
        }

        

        public void GenerarLog(string dato)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            string nombre = $"Log_{fecha}";
            string path = Path.Combine(ruta, nombre);
            bool apenda = true;
            try
            {
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    stream.WriteLine(dato);
                }
            }
            catch(Exception ex)
            {
                throw new ExcepcionPersonalizada($"Error con metodo .GenerarLog() - {ex.Message}");
            }
        }

        public List<T> Leer()
        {
            string path = Path.Combine(ruta, "Celulares.xml");

            if (File.Exists(path))
            {
                try
                {
                    //Error 2 de 2 , porque lo que retorno no es lo mismo donde lo almacelo fuera del método.
                    /*
                    Celular c1 = new Celular("S21", 100000, "Samsung", 20, false);
                    Celular c2 = new Celular("S21", 100000, "Samsung", 20, false);
                    Celular c3 = new Celular("S21", 100000, "Samsung", 20, false);
                    Celular c4 = new Celular("S21", 100000, "Samsung", 20, false);
                    Celular c5 = new Celular("S21", 100000, "Samsung", 20, false);
                    Celular c6 = new Celular("MotoE", 38000, "Samsung", 8, false);
                    Celular c7 = new Celular("E6I", 1800, "Motorola", 8, true);
                    Celular c8 = new Celular("G30", 34000, "Motorola", 16, false);
                    Celular c9 = new Celular("A51", 48000, "Samsung", 20, true);
                    Celular c10 = new Celular("G9", 43000, "Motorola", 12, false);
                    Celular c11 = new Celular("A21s", 38999, "Samsung", 12, true);
                    Celular c12 = new Celular("K51s", 27999, "LG", 8, true);
                    Celular c13 = new Celular("K51s", 72999, "Samsung", 26, false);
                    
                    List<Producto> products = new List<Producto>();
                    products.Add(c1);
                    products.Add(c2);
                    products.Add(c3);
                    products.Add(c4);
                    products.Add(c5);      
                    products.Add(c6);
                    products.Add(c7);
                    products.Add(c8);
                    products.Add(c9);
                    products.Add(c10);
                    products.Add(c11);
                    products.Add(c12);
                    products.Add(c13);
                    
                    bool apenda = false;
                    using (StreamWriter stream = new StreamWriter(path, apenda))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
                        serializer.Serialize(stream, products);
                    }
                    */

                    //23:40
                    using (StreamReader stream = new StreamReader(path))
                    {


                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

                        object objecto = xmlSerializer.Deserialize(stream);
                        return (List<T>)objecto;
                    }
                }
                catch (Exception ex)
                {
                    throw new ExcepcionPersonalizada($"Error con metodo .Leer() - {ex.Message} - {ex.GetBaseException()}");
                }
            }
            else
            {
                string mensajeError = "No existe el archivo Celulares.xml";
                this.GenerarLog(mensajeError);
                throw new NoExisteFileException(mensajeError);
            }
        }

    }
}
