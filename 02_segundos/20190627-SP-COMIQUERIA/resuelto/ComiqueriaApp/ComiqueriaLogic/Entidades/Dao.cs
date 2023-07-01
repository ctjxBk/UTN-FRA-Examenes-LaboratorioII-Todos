using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public static class Dao
    {
        private static SqlCommand command;
        private static SqlConnection connection;
        public delegate void Acciones (AccionesDB acciones);
        public static event Acciones EventoMetodo;
        static Dao()
        {
            //tabla  = Visitas
            connection = new SqlConnection(@"Server = .; Database = Comiqueria; Trusted_Connection = True");

            command = new SqlCommand();
            //using System.Data;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }


        public static void GuardarRegistro(Producto item)
        {
            try
            {
                connection.Open();

                //datanotation es el @
                string query = "INSERT INTO Productos (Descripcion, Precio, Stock) VALUES ( @Descripcion, @Precio, @Stock)";

                //SqlCommand command = new SqlCommand(query, connection);
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Descripcion", item.Descripcion);
                command.Parameters.AddWithValue("Precio", item.Precio);
                command.Parameters.AddWithValue("Stock", item.Stock);
                command.ExecuteNonQuery();

                EventoMetodo?.Invoke(AccionesDB.Insert);
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException($"ERROR al guardar en la BBDD",ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static void Modificar(Producto item)
        {
            try
            {
                string query = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock WHERE Codigo = @Codigo";
                connection.Open();
                command.CommandText = query;
                //esto es para borrar si tengo mas parametros
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Descripcion", item.Descripcion);
                command.Parameters.AddWithValue("Precio", item.Precio);
                command.Parameters.AddWithValue("Stock", item.Stock);
                command.Parameters.AddWithValue("Codigo", item.Codigo);
                command.ExecuteNonQuery();

                EventoMetodo?.Invoke(AccionesDB.Update);
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException($"ERROR al modificar en la BBDD", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();

                }
            }
        }

        public static void Eliminar(int codigo)
        {
            try
            {
                string query = "DELETE FROM Productos WHERE codigo = @codigo";

                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("codigo", codigo);
                command.ExecuteNonQuery();

                EventoMetodo?.Invoke(AccionesDB.Delete);
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException($"ERROR al eliminar en la BBDD", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();

                }
            }
        }

        public static List<Producto> Leer()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                string query = "SELECT * FROM Productos";
                connection.Open();
                command.CommandText = query;
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int codigo = dataReader.GetInt32(0);
                    string descripcion = dataReader.GetString(1);
                    float precio = (float)dataReader.GetDouble(2);
                    int stock = dataReader.GetInt32(3);

                    Producto cliente = new Producto(codigo,descripcion,stock,precio);
                    lista.Add(cliente);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new ComiqueriaException($"ERROR al leer en la BBDD", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
