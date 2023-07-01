using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ManejadorBaseDeDatos 
    {
        private static SqlConnection conexionALaBase;

        static ManejadorBaseDeDatos()
        {
            ManejadorBaseDeDatos.conexionALaBase = new SqlConnection(@"Data Source=.; Initial Catalog=Final_1erafecha_2021; Integrated Security=True;");
        }

        public static List<Producto> ObtenerProductos()
        {
            try
            {
                //using (SqlConnection connection = new SqlConnection(ManejadorBaseDeDatos.conexionALaBase))
                //{
                    string query = "SELECT * FROM Televisor";
                    conexionALaBase.Open();
                    SqlCommand command = new SqlCommand(query, conexionALaBase);

                    SqlDataReader dataReader = command.ExecuteReader();

                    List<Producto> lista = new List<Producto>();

                    while (dataReader.Read())
                    {
                        string marca = dataReader.GetString(0);
                        string modelo = dataReader.GetString(1);
                        int pulgadas = dataReader.GetInt32(2);
                        double precio = dataReader.GetDouble(3);

                        Televisor tele = new Televisor(marca, modelo, pulgadas, (float)precio);
                        lista.Add(tele);
                    }
                    return lista;
                //}
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada($"Error al leer la base de datos - {ex.Message}");
            }
            finally
            {
                if(conexionALaBase is not null && conexionALaBase.State == System.Data.ConnectionState.Open)
                {
                    conexionALaBase.Close();
                }
            }
        }

        
    }
}
