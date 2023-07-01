using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaDeClases
{
    public class SqlManejador
    {

        SqlConnection conexion;
        SqlCommand comando;

        public SqlManejador()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-UO8JNLI\SQLEXPRESS;Database=SP_2D_2022_C1;Trusted_Connection=True;");

            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;

        }

        public int Insertar(Alumno alumno)
        {
            try
            {
                List<string> auxLista = new List<string>();

                if (alumno.Dni < 10000000 || string.IsNullOrEmpty(alumno.NombreCompleto) || alumno.NotaPrimerParcial < 1 || alumno.NotaSegundoParcial < 1)
                {
                    throw new DatosNoValidosException("Error,los datos ingresados no son validos. Reingrese");
                }

                comando.CommandText = "Insert into Alumnos values (@Dni, @Nomb,@Not1,@Not2,@CalificacionFinal) ";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Dni", alumno.Dni);
                comando.Parameters.AddWithValue("@Nomb", alumno.NombreCompleto);
                comando.Parameters.AddWithValue("@Not1", alumno.NotaPrimerParcial);
                comando.Parameters.AddWithValue("@Not2", alumno.NotaSegundoParcial);
                comando.Parameters.AddWithValue("@CalificacionFinal", alumno.CalificacionFinal);

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                return comando.ExecuteNonQuery();

            }
            catch (DatosNoValidosException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexion.Close();
            }

        }

    }
}
