using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dao<T> : IArchivos<T>
    {

        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;

        static Dao()
        {
            connectionString = @"Server = .; Database = votacion-sp-2018; Trusted_Connection = True";
        }
        public bool Guardar(string rutaArchivo, T objecto)
        {
            Votacion votacion = objecto as Votacion;
            if(votacion is not null)
            {
                try
                {
                    using (this.connection = new SqlConnection(connectionString))
                    {
                        
                        //this.command = new SqlCommand();
                        //command.CommandType = System.Data.CommandType.Text;
                        //command.Connection = connection;

                        //datanotation es el @
                        string query = "INSERT INTO votaciones (nombreLey,afirmativos,negativos,abstenciones,nombreAlumno) VALUES (@nombreLey,@afirmativos,@negativos,@abstenciones,@nombreAlumno)";
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        //command.CommandText = query;
                        //command.Parameters.Clear();
                        command.Parameters.AddWithValue("nombreLey", votacion.NombreLey);
                        command.Parameters.AddWithValue("afirmativos", votacion.ContadorAfirmativo);
                        command.Parameters.AddWithValue("negativos", votacion.ContadorNegativo);
                        command.Parameters.AddWithValue("abstenciones", votacion.ContadorAbstencion);
                        command.Parameters.AddWithValue("nombreAlumno", "Agustin C");

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al momento de guardar en la base de datos - {ex.Message}",ex);
                }
            }
            else
            {
                throw new Exception("No se esta guardando una votacion");
            }
        }

        public T Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
