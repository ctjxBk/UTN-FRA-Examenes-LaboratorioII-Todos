using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public static class EmpleadoDAOStatic
    {
        private const string connectionString = @"Server = .\; Database = Practicando2022; Trusted_Connection = True";
        private const string tabla = "Empleados";

        private static SqlConnection connection;   // Puente.
        private static SqlCommand command;         // Quien lleva la consulta.
        private static SqlDataReader reader;       // Quien trae los datos.

        static EmpleadoDAOStatic()
        {
            connection = new SqlConnection(connectionString);

            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        public static bool Existe(int legajo)
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tabla} where legajo = @legajo";
                command.CommandText = query;
                command.Parameters.AddWithValue("@legajo", legajo);

                bool retorno = command.ExecuteReader().Read();
                command.Parameters.Clear();//importate borrar los parámetros
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ver si existe valor en la base de datos", ex);
            }
            finally
            {
                if(connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static bool Eliminar(int legajo)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tabla} WHERE legajo = @legajo";
                command.CommandText = query;
                command.Parameters.AddWithValue("@legajo", legajo);

                bool retorno = command.ExecuteNonQuery() == 0 ? false : true;
                command.Parameters.Clear();//importate borrar los parámetros
                return retorno;
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar en la base de datos", ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static bool Guardar(Empleado empleado)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tabla} " +
                    $" (legajo, nombre, fechaNacimiento, esFumador, sueldo, altura) " +
                    $" values(@legajo, @nombre, @fechaNacimiento, @esFumador, @sueldo, @altura); ";
                command.CommandText = query;
                command.Parameters.AddWithValue("@legajo", empleado.Legajo);
                command.Parameters.AddWithValue("@nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@fechaNacimiento", empleado.FechaNacimiento);
                command.Parameters.AddWithValue("@esFumador", empleado.EsFumador);
                command.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
                command.Parameters.AddWithValue("@altura", empleado.Altura);

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

        public static List<Empleado> Leer()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tabla}";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                List<Empleado> lista = new List<Empleado>();
                while (reader.Read())
                {
                    int legajo = reader.GetInt32(0);
                    string nombre = reader["nombre"].ToString(); //1
                    DateTime fecha = reader.GetDateTime(2);
                    //bool.TryParse(reader["esFumador"].ToString(), out bool esFumador); //3
                    bool esFumador = reader.GetBoolean(3);
                    double sueldo = reader.GetDouble(4);
                    float altura = (float)reader.GetDouble(5);

                    Empleado empleado = new Empleado(legajo, nombre, fecha, esFumador, sueldo, altura);
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

        public static bool Modificar(Empleado empleado)
        {
            try
            {
                connection.Open();
                string query = $"UPDATE {tabla} SET " +
                    $" nombre = @nombre, fechaNacimiento = @fechaNacimiento, " +
                    $" esFumador = @esFumador, sueldo = @sueldo, altura = @altura " +
                    $" where legajo = @legajo";

                command.CommandText = query;
                command.Parameters.AddWithValue("@legajo", empleado.Legajo);
                command.Parameters.AddWithValue("@nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@fechaNacimiento", empleado.FechaNacimiento);
                command.Parameters.AddWithValue("@esFumador", empleado.EsFumador);
                command.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
                command.Parameters.AddWithValue("@altura", empleado.Altura);

                bool retorno = command.ExecuteNonQuery() == 0 ? false : true;
                command.Parameters.Clear();//importate borrar los parámetros
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar en la base de datos", ex);
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
