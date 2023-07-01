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
            //tabla = Empleados
            conexion = new SqlConnection(@"Server = .; Database = ExamenPrimerFecha2022; Trusted_Connection = True");

            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;

        }

        public int Insertar(Empleado dato)
        {
            dato.Dni = this.ValidarDni(dato.Dni);
            dato.NombreCompleto = this.ValidarNombre(dato.NombreCompleto);
            

            try
            {
                conexion.Open();

                //datanotation es el @
                string query = "INSERT INTO Empleados (Dni, Nombre, Posicion, Honorario) VALUES (@Dni, @Nombre, @Posicion, @Honorario)";

                //SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("Dni", (int)dato.Dni);
                comando.Parameters.AddWithValue("Nombre", dato.NombreCompleto);
                comando.Parameters.AddWithValue("Posicion", dato.Posicion);
                comando.Parameters.AddWithValue("Honorario", (int)dato.CalcularHonorarios);

                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al momento de usar la base de datos", ex);
            }
            finally
            {
                if (conexion is not null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        private decimal ValidarDni(decimal dni)
        {
            if (dni > 10000000 && dni < 45000000)
            {
                return dni;
            }

            throw new DatoErroneoException("Error, uno de los parametros no es valido");
        }

        private string ValidarNombre(string nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                return nombre;
            }
            throw new DatoErroneoException("Error, uno de los parametros no es valido");
        }

        
    }
}
