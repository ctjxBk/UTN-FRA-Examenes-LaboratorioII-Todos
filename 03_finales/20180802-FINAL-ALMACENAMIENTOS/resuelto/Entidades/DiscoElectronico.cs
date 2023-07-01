using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    //a.Deberá heredar de Almacenador e implementar IAlmacenable.
    //b.El método Guardar deberá insertar un archivo en la base de datos.
    //c.El método Leer recibirá el nombre de la tabla a consultar. Deberá leer y retornar todos los archivos de la base de datos.
    //d.Tanto en Leer como en Guardar capturar y relanzar las excepciones.
    //e.El método MostrarArchivos por el momento sólo deberá recorrer la lista de archivos y por cada uno simular un retardo de 5 segundos.
    //f.Agregar un constructor en el cual se deberá cargar la lista a partir de los datos guardados en la base.
    //g.Sobrecargar el operador + para agregar un archivo a la lista siempre y cuando no supere la capacidad, caso contrario lanzará una excepción con el mensaje "El disco está lleno!".
    public class DiscoElectronico : Almacenador , IAlmacenable<List<Archivo>, Archivo>
    {
        public List<Archivo> archivosGuardados;

        private string connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private CancellationTokenSource cancelarHilo;

        public CancellationTokenSource CancelarHilo { get => cancelarHilo; set => cancelarHilo = value; }

        //TODO: el constructor privado nunca se utiliza, algo estoy haciendo mal....
        private DiscoElectronico() : base(5)
        {
            this.archivosGuardados = new List<Archivo>();
        }

        public DiscoElectronico(int capacidad) : base(capacidad)
        {
            List<Archivo> archivos = this.Leer("Archivo");
            this.archivosGuardados = new List<Archivo>();
            if (archivos is not null && archivos.Count != 0)
            {
                foreach(Archivo archivo in archivos)
                {
                    // cuando no puedo agregar mas, corto el flujo del foreach
                    if(!(this + archivo))
                    {
                        break;
                    }
                }
                //if(archivos.Count > capacidad)
                //{
                //    for(int i = 0; i < capacidad; i++)
                //    {
                //        this.archivosGuardados.Add(archivos[i]);
                //    }
                //}
                //else
                //{
                //    this.archivosGuardados = archivos;
                //}
            }

        }

        public static bool operator +(DiscoElectronico disco, Archivo archivo)
        {
            if(disco is not null && archivo is not null)
            {
                if (true)
                {
                    if (disco.capacidad > disco.archivosGuardados.Count)
                    {
                        disco.archivosGuardados.Add(archivo);
                        return true;
                    }
                    else
                    {
                        throw new Exception("El disco está lleno");
                    }
                }
            }
            return false;
        }


        public bool Guardar(Archivo elemento)
        {
            if (elemento is not null)
            {
                try
                {
                    this.connectionString = @"Server = .; Database = final-20180802; Trusted_Connection = True";
                    using (this.connection = new SqlConnection(connectionString))
                    {

                        //this.command = new SqlCommand();
                        //command.CommandType = System.Data.CommandType.Text;
                        //command.Connection = connection;

                        //datanotation es el @
                        string query = "INSERT INTO Archivo (nombre,contenido) VALUES (@nombre,@contenido)";
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        //command.CommandText = query;
                        //command.Parameters.Clear();
                        command.Parameters.AddWithValue("nombre", elemento.nombre);
                        command.Parameters.AddWithValue("contenido", elemento.contenido);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al usar .Guardar() en DiscoElectronico.cs", ex);
                }
            }
            return false;
        }

        public List<Archivo> Leer(string path)
        {
            List<Archivo> lista = new List<Archivo>();
            if (path is not null)
            {
                try
                {
                    this.connectionString = @"Server = .; Database = final-20180802; Trusted_Connection = True";
                    using (this.connection = new SqlConnection(connectionString))
                    {

                        //this.command = new SqlCommand();
                        //command.CommandType = System.Data.CommandType.Text;
                        //command.Connection = connection;

                        //datanotation es el @
                        string query = $"SELECT * FROM {path}";
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        //command.CommandText = query;
                        //command.Parameters.Clear();
                        SqlDataReader dataReader = command.ExecuteReader();
                        

                        while (dataReader.Read())
                        {
                            string nombre = dataReader.GetString(2);
                            //string contendio = dataReader.GetString(3);
                            //string contendio = dataReader.GetStream(3).ToString();
                            string contendio = dataReader["contenido"] as string;
                            Archivo archivo = new Archivo(nombre, contendio);
                            lista.Add(archivo);
                        }

                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al usar .Leer() en DiscoElectronico.cs", ex);
                }
            }
            return lista;
        }

        public override void MostrarArchivos()
        {
            if(this.archivosGuardados is not null)
            {
                foreach (Archivo archivo in this.archivosGuardados)
                {
                    if (this.cancelarHilo is not null && this.cancelarHilo.IsCancellationRequested)
                    {
                        break;
                    }
                    this.DispararEvento(archivo);
                    Thread.Sleep(5001);
                }
            }
        }
    }
}
