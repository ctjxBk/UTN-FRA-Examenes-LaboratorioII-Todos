using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonalMedicoDao : IMantenerDatos<PersonalMedico,List<PersonalMedico>>
    {
        private static string connectionString;
        static PersonalMedicoDao()
        {
            connectionString = BaseDeDatos.ConnectionString;
        }

        public void Guardar(PersonalMedico item, string path)
        {
            throw new NotImplementedException();
        }

        public List<PersonalMedico> Leer(string path)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM PersonalMedico;";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<PersonalMedico> medicos = new List<PersonalMedico>();

                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["Id"]);
                        string nombre = dataReader["Nombre"].ToString();
                        string apellido = dataReader["apellido"].ToString();
                        //string fecha = dataReader["nacimiento"].ToString();
                        DateTime.TryParse(dataReader["nacimiento"].ToString(), out DateTime fechaNacimiento);
                        //int anio = Convert.ToInt32(fecha.Split('/')[2].Split(' ')[0]);
                        //int mes = Convert.ToInt32(fecha.Split('/')[1]);
                        //int dia = Convert.ToInt32(fecha.Split('/')[0]);
                        //DateTime fechaNacimiento = new DateTime(anio, mes, dia);
                        bool esRecidente = dataReader.GetBoolean(4);

                        PersonalMedico personalMedico = new PersonalMedico(nombre, apellido, fechaNacimiento, esRecidente);
                        medicos.Add(personalMedico);
                    }

                    return medicos;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al leer la base de datos en la tabla PERSONALMEDICO", ex);
            }
            
        }
    }
}
