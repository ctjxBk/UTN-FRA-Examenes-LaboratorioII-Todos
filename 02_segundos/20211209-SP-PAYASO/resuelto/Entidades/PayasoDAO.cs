using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{

    public static class PayasoDAO
    {
        private static SqlCommand command;
        private static SqlConnection connection;

        static PayasoDAO()
        {
            //tabla  = Visitas
            connection = new SqlConnection(@"Server = .; Database = 20211209-FINAL; Trusted_Connection = True");

            command = new SqlCommand();
            //using System.Data;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }


        public static void GuardarRegistro(Payaso item)
        {
            try
            {
                connection.Open();

                //datanotation es el @
                string query = "INSERT INTO Visitas (Nombre, Fecha, VisitasAlcantarilla, Alumno) VALUES (@Nombre, @Fecha , @VisitasAlcantarilla, @Alumno)";

                //SqlCommand command = new SqlCommand(query, connection);
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Nombre", item.Nombre);
                command.Parameters.AddWithValue("Fecha", item.Fecha.ToString("dd/mm/yyyy"));
                command.Parameters.AddWithValue("VisitasAlcantarilla", item.ViajesAlcantarilla);
                command.Parameters.AddWithValue("Alumno", "Agustin C");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DatosException($"Error al momento de usar la base de datos - {ex.Message}");
            }
            finally
            {
                if (connection is not null &&  connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
