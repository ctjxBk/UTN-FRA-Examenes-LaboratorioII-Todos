using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaDeClases
{
    public class SqlManejador
    {

        SqlConnection conexion;
        SqlCommand comando;

        public SqlManejador()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-UO8JNLI\SQLEXPRESS;Database=Final2022;Trusted_Connection=True;");

            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;

        }

    }
}
