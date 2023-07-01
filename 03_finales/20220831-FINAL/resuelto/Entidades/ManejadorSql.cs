using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;

namespace Entidades
{

    internal static class ManejadorSql
    {
        private const string connectionString = @"Server = .\; Database = final_20220831; Trusted_Connection = True";
        private const string tabla = "Autos";

        private static SqlConnection connection;   // Puente.
        private static SqlCommand command;         // Quien lleva la consulta.
        private static SqlDataReader reader;       // Quien trae los datos.

        static ManejadorSql()
        {
            connection = new SqlConnection(connectionString);

            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        internal static List<Auto> ObtenerAutos()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tabla}";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                List<Auto> lista = new List<Auto>();
                while (reader.Read())
                {
                    //int id = reader.GetInt32(0);

                    int presion = reader.GetInt32(1);
                    string patente = reader.GetString(2);
                    
                    
                    Auto empleado = new Auto(presion,patente);
                    lista.Add(empleado);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Leer en la base de datos", ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        internal static bool InsertarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                Auto auto = vehiculo as Auto;

                if(auto == null) {
                    throw new Exception("El vehiculo no se puede convertir en auto");
                }
                
                connection.Open();
                string query = $"INSERT INTO {tabla} " +
                    $" (Presion, Patente) " +
                    $" values(@Presion, @Patente); ";
                command.CommandText = query;
                command.Parameters.AddWithValue("@Presion", auto.PresionInflado);
                command.Parameters.AddWithValue("@Patente", auto.Patente);

                bool retorno = command.ExecuteNonQuery() == 0 ? false : true;
                command.Parameters.Clear();//importate borrar los parámetros
                return retorno;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar en la base de datos", ex);
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
