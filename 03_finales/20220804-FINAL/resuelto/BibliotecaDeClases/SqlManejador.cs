using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaDeClases
{

    // DESARROLLAR
    public class SqlManejador
    {
        private SqlCommand comando;
        private SqlConnection conexion;

        public SqlManejador()
        {
            string connectionString = @"Server = .\; Database = ExamenPrimerFecha2022; Trusted_Connection = True";
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text; //System.Data;
            comando.Connection = conexion;
        }

        public int Insertar(EmpleadoFreelance dato)
        {
            if(!this.ValidarNumero(dato.Dni,10000000,45000000) || !this.ValidarString(dato.NombreCompleto))
            {
                throw new DatoErroneoException("Los datos no son correctos");
            }
            try
            {
                //[Dni][int] NOT NULL,
                //[Nombre] [nvarchar] (50) NOT NULL,
                //[Posicion] [nvarchar] (50) NOT NULL,
                //[Honorario] [int] NOT NULL

                string query = $"INSERT INTO Empleados (Dni, Nombre, Posicion, Honorario)" +
                    " VALUES (@Dni, @Nombre, @Posicion, @Honorario)";
                conexion.Open();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("Dni", dato.Dni);
                comando.Parameters.AddWithValue("Nombre", dato.NombreCompleto);
                comando.Parameters.AddWithValue("Posicion", dato.Posicion);
                comando.Parameters.AddWithValue("Honorario", dato.CalcularHonorarios);


                int retorno = comando.ExecuteNonQuery();
                comando.Parameters.Clear(); //importante que sea lo último para borrar los ".AddWithValue()"
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al Guardar en la BBDD", ex);
            }
            finally
            {
                if (conexion is not null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private bool ValidarNumero(decimal numero, int minimo, int maximo)
        {
            return numero > minimo && numero < maximo;
        }

        private bool ValidarString(string cadena)
        {
            return !String.IsNullOrEmpty(cadena);
        }


    }
}
