using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Archivos
{
    //21:10
    public class Sql : IArchivo<Queue<Patente>>
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static Sql()
        {
            //tabla Patentes
            conexion = new SqlConnection(@"Data Source = .;
                                Database = patentes-sp-2018;
                                Trusted_Connection = True;");

            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }
        
        public void Guardar(string tabla, Queue<Patente> datos)
        {
            try
            {
                while(datos.Count > 0)
                {
                    conexion.Open();
                    comando.CommandText = "INSERT INTO Patentes (patente, tipo) VALUES (@patente, @tipo)";
                    Patente patente = datos.Dequeue();
                    comando.Parameters.AddWithValue("patente", patente.CodigoPatente);
                    comando.Parameters.AddWithValue("tipo", patente.TipoCodigo.ToString());
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error de conexión a la base de datos", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void Leer(string tabla, out Queue<Patente> datos)
        {
            try
            {
                comando.CommandText = $"SELECT * FROM {tabla}";
                conexion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();

                Queue<Patente> auxiliar = new Queue<Patente>();

                while (dataReader.Read())
                {
                    string codigoPatente = dataReader.GetString(0);
                    //string tipo = dataReader.GetString(1);
                    Patente patente = codigoPatente.ValidarPatente();
                    auxiliar.Enqueue(patente);
                }
                datos = auxiliar;
            }
            catch (Exception ex)
            {
                throw new PatenteInvalidaException("Error de conexión a la base de datos", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
