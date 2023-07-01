﻿using Entidades.DataBase;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Extension;
using Entidades.Exceptions;

namespace Entidades.Models
{
    //14.	País, implementará el mensaje ObtenerNuevaPalabra, para ello deberá
    //leer desde la tabla “Paises” en base a un ID aleatorio(hasta 35).
    //Reutilizar código.
    public class Pais : ILector
    {
        public string ObtenerNuevaPalabra()
        {
            return DataBaseManager.GetNuevaPalabra("paises",new Random().GetRandomId(35));
        }
    }
}
