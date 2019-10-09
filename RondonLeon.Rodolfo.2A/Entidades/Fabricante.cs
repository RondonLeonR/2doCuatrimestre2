using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string marca;
        private EPais pais;

        public Fabricante(string marca, EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }

        public static implicit operator string(Fabricante f)
        {
            return string.Format("{0} - {1}",f.marca,f.pais);
        }

        public static bool operator ==(Fabricante a, Fabricante b)
        {
            bool retorno = false;
            if(a.marca == b.marca && a.pais == b.pais)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }

    }
}
