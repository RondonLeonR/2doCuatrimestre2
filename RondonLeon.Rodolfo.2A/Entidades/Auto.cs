using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        public ETipo tipo;

        public Auto(string modelo, float precio, Fabricante fabri, ETipo tipo) : base(precio,modelo,fabri)
        {
            this.tipo = tipo;
        }

        public static explicit operator Single(Auto a)
        {
            return a.precio;
        }

        public static bool operator ==(Auto a, Auto b)
        {
            bool retorno = false;
            if((Vehiculo)a ==  (Vehiculo)b)
            {
                if(a.tipo == b.tipo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if(obj is Auto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("\n{0} \nTipo: {1}", (string)this, this.tipo);
        }
    }
}
