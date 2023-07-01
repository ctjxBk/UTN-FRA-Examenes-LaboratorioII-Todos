using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //19:30 - 21:20 con testing, solo falta el punto extra
    //21:36 con el punto extra
    public class PacienteDao : IMantenerDatos<Paciente,List<Paciente>>
    {
        private static string connectionString;
        static PacienteDao()
        {
            connectionString = BaseDeDatos.ConnectionString;
        }
        public List<Paciente> Leer(string path)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Pacientes;";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Paciente> listaDePacientes = new List<Paciente>();

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
                        string barrioResidencia = dataReader["barrioResidencia"].ToString();

                        Paciente paciente = new Paciente(nombre, apellido, fechaNacimiento, barrioResidencia);
                        listaDePacientes.Add(paciente);
                    }

                    return listaDePacientes;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Error al leer la base de datos en la tabla PACIENTES", ex);
            }
        }

        public void Guardar(Paciente item, string path)
        {
            throw new NotImplementedException();
        }


    }
}
