﻿using Entidades.DataBase;
using Entidades.Extension;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exceptions;
namespace Entidades.Models
{
    //13.	Vehículo, implementará el mensaje ObtenerNuevaPalabra,
    //para ello deberá leer desde la tabla “Vehiculos” en base a un ID aleatorio(hasta 37).
    //Reutilizar código.
    public class Vehiculo : ILector
    {
        public string ObtenerNuevaPalabra()
        {
            return DataBaseManager.GetNuevaPalabra("vehiculos", new Random().GetRandomId(37));
        }
    }
}
