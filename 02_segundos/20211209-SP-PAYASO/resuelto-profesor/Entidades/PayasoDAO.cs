using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PayasoDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PayasoDAO()
        {
            conexion = new SqlConnection(@"Data Source = .\SQLEXPRESS; Database = 20211202-SP; Trusted_Connection = True;");
            comando = conexion.CreateCommand();
        }
        public static void GuardarRegistro(Payaso item)
        {
            try
            {
                conexion.Open();
                comando.Parameters.Clear();
                comando.CommandText = $"INSERT INTO Visitas VALUES (@nombre,@fecha,@visitas,@alumno)";
                comando.Parameters.AddWithValue("@alumno", "Lautaro Galarza");
                comando.Parameters.AddWithValue("@nombre", item.Nombre);
                comando.Parameters.AddWithValue("@fecha", item.Fecha.ToShortDateString());
                comando.Parameters.AddWithValue("@visitas", item.ViajesAlcantarilla);

                comando.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
