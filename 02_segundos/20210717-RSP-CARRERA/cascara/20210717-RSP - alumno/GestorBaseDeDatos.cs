using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210717_RSP___alumno
{
    public class GestorBaseDeDatos: IGuardar<AutoF1>
    {
        private static string cadenaDeConexion;

        static GestorBaseDeDatos()
        {
            GestorBaseDeDatos.cadenaDeConexion = "Server=.;Database=20210717-RSP;Trusted_Connection=True;";
        }

        public void Guardar(AutoF1 autoF1)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GestorBaseDeDatos.cadenaDeConexion))
            {
                try
                {
                    string consulta = "INSERT INTO RESULTADOS (escuderia, posicion, horaLlegada) VALUES (@escuderia, @posicion, @horaLlegada)";
                    SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("escuderia", autoF1.Escuderia);
                    sqlCommand.Parameters.AddWithValue("posicion", autoF1.Posicion);
                    sqlCommand.Parameters.AddWithValue("horaLlegada", DateTime.Now.ToString("H:m:s"));
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
