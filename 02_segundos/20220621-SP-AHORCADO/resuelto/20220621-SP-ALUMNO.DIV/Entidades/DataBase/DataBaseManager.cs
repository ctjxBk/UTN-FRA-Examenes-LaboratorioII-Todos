using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Exceptions;

namespace Entidades.DataBase
{
    //8.DataBaseManager será estática:
    //  a.En el constructor de clase inicializar el string connection.
    //  b.GetNuevaPalabra, recibirá el nombre de la tabla sobre la cual realizar el select y
    //  el id de la palabra a obtener. Retornada la palabra leída desde la BD.

    public static class DataBaseManager
    {
        private static string connectionString;
        //private static SqlCommand command;
        private static SqlConnection connection;

        static DataBaseManager()
        {
            DataBaseManager.connectionString = @"Server = .; Database = 20220621SP; Trusted_Connection = True";
            DataBaseManager.connection = new SqlConnection(DataBaseManager.connectionString);
        }
        
        public static string GetNuevaPalabra(string tabla, int id)
        {
            try
            {
                if(tabla != "paises" && tabla != "vehiculos")
                {
                    throw new DataBaseManagerException("Error al leer la base de datos, la tabla no existe");
                }

                string query = $"SELECT * FROM {tabla} WHERE id = @id";
                //string query = "SELECT * FROM @tabla WHERE id = @id";
                connection.Open();
                    
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("tabla", tabla);

                command.Parameters.AddWithValue("id", id);

                SqlDataReader dataReader = command.ExecuteReader();

                string palabra = string.Empty;
                while (dataReader.Read())
                {
                    palabra = dataReader.GetString(1);
                }

                return palabra;
            }
            catch (Exception ex)
            {
                throw new DataBaseManagerException("Error al leer la base de datos", ex);
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
