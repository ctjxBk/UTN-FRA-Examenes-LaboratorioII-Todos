using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GestorBaseDeDatos : IGuardar<AutoF1>
    {
        private static string cadenaConexion;

        static GestorBaseDeDatos()
        {
            GestorBaseDeDatos.cadenaConexion = @"Server = .\; Database = 20210717-RSP; Trusted_Connection = True";
        }

        public void Guardar(AutoF1 autoF1)
        {
            
            
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    string query = "INSERT INTO resultados (escuderia,posicion,horaLlegada) VALUES (@escuderia,@posicion,@horaLlegada);";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("escuderia", autoF1.Escuderia);
                    command.Parameters.AddWithValue("posicion", autoF1.Posicion);
                    command.Parameters.AddWithValue("horaLlegada", DateTime.Now.ToString());

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
