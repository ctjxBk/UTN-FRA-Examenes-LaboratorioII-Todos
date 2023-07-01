using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace DAO
{
    public class EmpleadoDAO
    {
        private const string connectionString = @"Server = .\; Database = Practicando2022; Trusted_Connection = True";
        private const string tabla = "Empleados";
        
        public bool Existe(int legajo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tabla} where legajo = @legajo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@legajo", legajo);
                    
                    return command.ExecuteReader().Read();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ver si existe valor en la base de datos", ex);
            }
        }

        public bool Eliminar(int legajo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM {tabla} WHERE legajo = @legajo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@legajo", legajo);
                    
                    return command.ExecuteNonQuery() == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar en la base de datos", ex);
            }
        }

        public bool Guardar(Empleado empleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO {tabla} " +
                        $" (legajo, nombre, fechaNacimiento, esFumador, sueldo, altura) " +
                        $" values(@legajo, @nombre, @fechaNacimiento, @esFumador, @sueldo, @altura); ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@legajo", empleado.Legajo);
                    command.Parameters.AddWithValue("@nombre",empleado.Nombre);
                    command.Parameters.AddWithValue("@fechaNacimiento", empleado.FechaNacimiento);
                    command.Parameters.AddWithValue("@esFumador", empleado.EsFumador);
                    command.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
                    command.Parameters.AddWithValue("@altura", empleado.Altura);
                    return command.ExecuteNonQuery() == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar en la base de datos", ex);
            }
        }

        public List<Empleado> Leer()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tabla}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

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

                        Empleado empleado = new Empleado(legajo,nombre,fecha,esFumador,sueldo,altura);
                        lista.Add(empleado);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Leer en la base de datos", ex);
            }
        }

        public bool Modificar(Empleado empleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"UPDATE {tabla} SET " +
                        $" nombre = @nombre, fechaNacimiento = @fechaNacimiento, " +
                        $" esFumador = @esFumador, sueldo = @sueldo, altura = @altura " +
                        $" where legajo = @legajo";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@legajo", empleado.Legajo);
                    command.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@fechaNacimiento", empleado.FechaNacimiento);
                    command.Parameters.AddWithValue("@esFumador", empleado.EsFumador);
                    command.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
                    command.Parameters.AddWithValue("@altura", empleado.Altura);
                    return command.ExecuteNonQuery() == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar en la base de datos", ex);
            }
        }
    }
}
