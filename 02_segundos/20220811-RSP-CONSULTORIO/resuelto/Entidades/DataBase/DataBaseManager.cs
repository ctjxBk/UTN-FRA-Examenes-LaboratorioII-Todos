using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Exceptions;
using System.Text.Json;
using Entidades.Interfaces;
using System.Data;

namespace Entidades.DataBase
{
    //    8.	DataBaseManager será estática:
    //a.En el constructor de clase inicializar el string connection.
    //b.ObtenerPaciente, recibirá el id del paciente a obtener.Retornara un string que contendrá el nombre y apellido concatenado.
    //c.Si el id no existe se lanzará una excepción DataBaseManagerException, indicando Id inexistente.
    //d.Por cualquier otro error se capturara y se re lanzara en una excepción DataBaseManagerException indicando error al leer de la base de datos.

    public static class DataBaseManager
    {
        private static string connectionString;     //
        private static SqlConnection connection;    // Puente.

        static DataBaseManager()
        {
            
            connectionString = @"Server = .\; Database = 20220804EX; Trusted_Connection = True";
            connection = new SqlConnection(connectionString);

        }

        public static string ObtenerPaciente(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text; //System.Data;
                command.Connection = connection;
                string query = $"SELECT nombre, apellido FROM Pacientes where id = @id";
                command.CommandText = query;
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    string nombre = dataReader["nombre"].ToString();
                    string apellido = dataReader["apellido"].ToString();
                    return $"{nombre}, {apellido}";
                }
                throw new DataBaseManagerException("No existe el ID");
            }
            catch (Exception ex)
            {
                throw new DataBaseManagerException($"Error al Leer en la BBDD", ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
