using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GestionarBaseDeDatos : PersistirDatos
    {
        private static SqlCommand command;
        private static SqlConnection connection;

        static GestionarBaseDeDatos()
        {
            //tabla  = [log]
            connection = new SqlConnection(@"Server = .; Database = 20201203-sp; Trusted_Connection = True");

            command = new SqlCommand();
            //using System.Data;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        public void Guardar(string mensaje)
        {
            try
            {
                connection.Open();

                //datanotation es el @
                string query = "INSERT INTO log (entrada, alumno) VALUES (@entrada,@alumno)";

                //SqlCommand command = new SqlCommand(query, connection);
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("entrada", mensaje);
                command.Parameters.AddWithValue("alumno", "Agustin C");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada($"Error al momento de GUARDAR en la base de datos",ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<string> Leer()
        {
            try
            {
                string query = "SELECT * FROM log";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();
                List<string> lista = new List<string>();

                while (dataReader.Read())
                {
                    lista.Add(dataReader.GetString(1));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada($"Error al momento de LEER en la base de datos",ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
