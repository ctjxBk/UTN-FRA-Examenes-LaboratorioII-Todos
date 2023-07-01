using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaDeClases
{
    public class SqlManejador
    {
        private static SqlCommand command;
        private static SqlConnection connection;

        static SqlManejador()
        {
            //tabla  = Alumnos
            connection = new SqlConnection(@"Server = .; Database = SP_2D_2022_C1; Trusted_Connection = True");

            command = new SqlCommand();
            //using System.Data;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }
        
        public int Insertar(Alumno alumno)
        {

            alumno.Dni = this.ValidarDni(alumno.Dni);
            alumno.NombreCompleto = this.ValidarNombre(alumno.NombreCompleto);
            alumno.NotaPrimerParcial = this.ValidarNota(alumno.NotaPrimerParcial);
            alumno.NotaSegundoParcial = this.ValidarNota(alumno.NotaSegundoParcial);

            try
            {
                connection.Open();

                //datanotation es el @
                string query = "INSERT INTO Alumnos (Dni, NombreCompleto, NotaUno, NotaDos, CalificacionFinal) VALUES (@Dni, @NombreCompleto, @NotaUno, @NotaDos, @CalificacionFinal)";

                //SqlCommand command = new SqlCommand(query, connection);
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Dni", alumno.Dni);
                command.Parameters.AddWithValue("NombreCompleto", alumno.NombreCompleto);
                command.Parameters.AddWithValue("NotaUno", alumno.NotaPrimerParcial);
                command.Parameters.AddWithValue("NotaDos", alumno.NotaSegundoParcial);
                command.Parameters.AddWithValue("CalificacionFinal", alumno.CalificacionFinal);
                
                return command.ExecuteNonQuery();               
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al momento de usar la base de datos",ex);
            }
            finally
            {
                if (connection is not null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
           
        }


        private decimal ValidarDni(decimal dni)
        {
            if (dni > 10000000 && dni < 45000000)
            {
                return dni;
            }
      
            throw new DatosNoValidosException("Error, uno de los parametros no es valido");
        }

        private string ValidarNombre(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                return nombre;
            }
            throw new DatosNoValidosException("Error, uno de los parametros no es valido");
        }

        private decimal ValidarNota(decimal nota)
        {
            if (nota > 0 && nota < 11)
            {
                if ((int)nota == nota)
                {
                    return nota;
                }
            }
            throw new DatosNoValidosException("Error, uno de los parametros no es valido");
        }
    }
}
