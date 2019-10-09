using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        public ECilindrada cilindrada;

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada) : base(marca,pais,modelo,precio)
        {
            this.cilindrada = cilindrada;
        }

        public static implicit operator Single(Moto m)
        {
            return m.precio;
        }

        public static bool operator ==(Moto a, Moto b)
        {
            bool retorno = false;
            if(a == b)
            {
                if(a.cilindrada == b.cilindrada)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if(obj is Moto)
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
            return string.Format("\n{0} \nCilindrada: {1}", (string)this, this.cilindrada);
        }
    }
}
