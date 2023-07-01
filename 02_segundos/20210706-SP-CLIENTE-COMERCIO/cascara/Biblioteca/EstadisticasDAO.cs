using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadisticasDAO
    {
        private static string connectionString;
        private static Random random;
        static EstadisticasDAO()
        {
            connectionString = @"Server = .; Database = 20210706-SP; Trusted_Connection = True";
            random = new Random();
        }
        public static void Guardar(int cantidadClientesSimulados)
        {
            int noAtendidos = random.Next(0, cantidadClientesSimulados);
            int atendidos= cantidadClientesSimulados - noAtendidos;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO atenciones (atendidos,noAtendidos,Alumno) VALUES (@atendidos,@noAtendidos,@alumno);";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("atendidos", atendidos);
                    command.Parameters.AddWithValue("noAtendidos", noAtendidos);
                    command.Parameters.AddWithValue("alumno", "Agustin C");

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
