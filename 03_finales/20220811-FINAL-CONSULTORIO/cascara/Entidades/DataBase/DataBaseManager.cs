﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Exceptions;
using System.Text.Json;
using Entidades.Interfaces;

namespace Entidades.DataBase
{
    //    8.	DataBaseManager será estática:
    //a.En el constructor de clase inicializar el string connection.
    //b.ObtenerPaciente, recibirá el id del paciente a obtener.Retornara un string que contendrá el nombre y apellido concatenado con un guion medio, Ej: $"{reader.GetString(2)}-{reader.GetString(1)}".
    //c.Si el id no existe se lanzará una excepción DataBaseManagerException, indicando Id inexistente.
    //d.Por cualquier otro error se capturara y se re lanzara en una excepción DataBaseManagerException indicando error al leer de la base de datos.

    public class DataBaseManager
    {

    }
}
