﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biografia : Publicacion
    {

        protected override bool EsColor => false;

        public override bool HayStock => this.stock > 0;

        public Biografia(string nombre) : base(nombre)
        {
        }

        public Biografia(string nombre, int stock)
            : base(nombre, stock)
        {

        }

        public Biografia(string nombre, int stock, float valor)
            :base(nombre, stock, valor)
        {

        }

        public static explicit operator Biografia(string nombre)
        {
            return new Biografia(nombre);
        }


    }
}
