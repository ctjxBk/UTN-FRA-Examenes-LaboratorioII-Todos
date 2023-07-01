using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal static class BaseDeDatos
    {
        private static string connectionString;
        static BaseDeDatos()
        {
            connectionString = @"Server = .; Database = 202206-medico-paciente; Trusted_Connection = True";
        }

        public static string ConnectionString { get => connectionString; }
    }
}
