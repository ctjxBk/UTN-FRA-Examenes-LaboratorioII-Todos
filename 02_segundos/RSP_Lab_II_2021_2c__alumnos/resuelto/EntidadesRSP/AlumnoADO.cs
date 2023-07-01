using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRSP
{
    public class AlumnoADO : Alumno
    {
        private static string conexion;
        private static SqlConnection connection;
        private static SqlCommand command;

        public AlumnoADO(int dni, string nombre, string apellido, double nota) : base(dni, nombre, apellido, nota)
        {
        }

        public AlumnoADO(Alumno alumno) : this(alumno.Dni,alumno.Nombre,alumno.Apellido,alumno.Nota)
        {

        }

        static AlumnoADO()
        {
            //tabla Alumnos
            conexion = @"Server = .\; Database = utn_fra_alumnos; Trusted_Connection = True";
            connection = new SqlConnection(conexion);
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        public static List<Alumno> ObtenerTodos()
        {
            try
            {
                command.CommandText = "SELECT * FROM Alumnos";
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                List<Alumno> lista = new List<Alumno>();

                while (dataReader.Read())
                {
                    // Lógica
                    int dni = dataReader.GetInt32(0);
                    string nombre = dataReader.GetString(1);
                    string apellido = dataReader.GetString(2);
                    double nota = dataReader.GetDouble(3);
                    Alumno alumno = new Alumno(dni,nombre,apellido,nota);
                    lista.Add(alumno);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error de conexión a la base de datos",ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public bool Agregar()
        {
            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO Alumnos (dni, nombre, apellido, nota) VALUES (@dni, @nombre, @apellido, @nota)";
                command.Parameters.AddWithValue("dni", this.Dni);
                command.Parameters.AddWithValue("nombre", this.Nombre);
                command.Parameters.AddWithValue("apellido", this.Apellido);
                command.Parameters.AddWithValue("nota", this.Nota);
                bool retorno = command.ExecuteNonQuery() > 0 ? true: false ;
                command.Parameters.Clear();
                return retorno;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error de conexión a la base de datos", ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public bool Modificar()
        {
            try
            {
                connection.Open();
                command.CommandText = "UPDATE Alumnos SET nombre = @nombre, apellido = @apellido, nota = @nota WHERE dni = @dni";
                command.Parameters.AddWithValue("dni", this.Dni);
                command.Parameters.AddWithValue("nombre", this.Nombre);
                command.Parameters.AddWithValue("apellido", this.Apellido);
                command.Parameters.AddWithValue("nota", this.Nota);
                bool retorno = command.ExecuteNonQuery() > 0 ? true : false;
                command.Parameters.Clear();
                return retorno;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error de conexión a la base de datos", ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public bool Eliminar()
        {
            try
            {
                connection.Open();
                command.CommandText = "DELETE FROM Alumnos WHERE dni = @dni";
                command.Parameters.AddWithValue("dni", this.Dni);
                bool retorno = command.ExecuteNonQuery() > 0 ? true : false;
                command.Parameters.Clear();
                return retorno;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error de conexión a la base de datos", ex);
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
