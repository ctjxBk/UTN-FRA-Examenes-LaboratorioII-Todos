using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PersonajeDAO
    {
        public static Personaje ObtenerPersonajePorId(decimal id)
        {
            string connectionString = @"Server = .; Database = COMBATE_DB; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PERSONAJES WHERE id = @id;";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                
                SqlDataReader dataReader = command.ExecuteReader();
                //int ID;
                string nombre = ".";
                int nivel = -1;
                int clase = -1;
                string titulo = ".";

                while (dataReader.Read())
                {
                    nombre = dataReader.GetString(1);
                    nivel = dataReader.GetInt16(2);
                    clase = dataReader.GetInt16(3);
                    titulo = dataReader["titulo"] as string;
                }


                if(clase == 1)
                {
                    Guerrero g = new Guerrero(id, nombre, (short)nivel);
                    g.Titulo = titulo;
                    return g;
                }
                else// if(clase == 2)
                {
                    Hechizero h = new Hechizero(id, nombre, (short)nivel);
                    h.Titulo = titulo;
                    return h;
                }
                
                
            }
        }
        
    }
}
