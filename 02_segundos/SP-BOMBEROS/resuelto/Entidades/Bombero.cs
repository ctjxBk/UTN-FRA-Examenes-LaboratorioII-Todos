using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace Entidades
{
    public class Bombero : IArchivo<string> , IArchivo<Bombero>
    {
        private string nombre;
        private List<Salida> salidas;
        public event FinDeSalida MarcarFin;
        private static string path;
        private static string connectionString;

        

        static Bombero()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            path = Path.Combine(path, "Bombero.xml");
            connectionString = @"Server = .; Database = bomberos-db; Trusted_Connection = True";
        }

        public Bombero()
        {
            this.salidas = new List<Salida>();
        }

        public Bombero(string nombre)
            :this()
        {
            this.Nombre = nombre;
            
        }

        public List<Salida> Salidas
        {
            get
            {
                return salidas;
            }
            set
            {
                salidas = value;
            }
        }

        public string Nombre { get => nombre; set => nombre = value; }

        public void AtenderSalida(int bomberoIndex)
        {
            Salida salida = new Salida();//entrada
            this.salidas.Add(salida);
            Thread.Sleep(new Random().Next(2000, 4001));
            salida.FinalizarSalida();//salida
            double tiempoTotal = salida.TiempoTotal; //tiempo
            string mensaje = $"Entrada: {salida.FechaInicio.ToString()} - Salida {salida.FechaFin.ToString()} - Tiempo total: {tiempoTotal}";
            ((IArchivo<string>)this).Guardar(mensaje);
            //evento
            this.MarcarFin?.Invoke(bomberoIndex);
        }

        //explicita
        void IArchivo<string>.Guardar(string info)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO log (entrada,alumno) VALUES (@entrada,@alumno);";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("entrada", info);      
                command.Parameters.AddWithValue("alumno", "Agustin c");

                command.ExecuteNonQuery();
            }
        }

        string IArchivo<string>.Leer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM log;";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (dataReader.Read())
                {
                    sb.AppendLine(dataReader.GetString(0));
                }

                return sb.ToString();
            }
        }

        //implicita
        public void Guardar(Bombero info)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bombero));
                xmlSerializer.Serialize(streamWriter, info);
            }
        }

        public Bombero Leer()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bombero));
                return (Bombero)xmlSerializer.Deserialize(streamReader);
            }
        }


    }
}
