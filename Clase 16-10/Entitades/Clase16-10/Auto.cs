using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        private string _color;
        private string _marca;

        public string Color
        {
            get
            {
                return this._color;
            }
        }

        public string Marca
        {
            get
            {
                return this._marca;
            }
        }

        public Auto(string color, string marca)
        {
            this._color = color;
            this._marca = marca;
        }

        public static bool operator ==(Auto a, Auto b)
        {
            //bool retorno = false;

            //if(string.Equals(a.Color,b.Color) && string.Equals(a.Marca,b.Marca))
            //{
            //    retorno = true;
            //}
            return a.Equals(b);
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Auto && string.Equals(this.Color,((Auto)obj).Color) && string.Equals(this.Marca,((Auto)obj).Marca))
            {
                retorno = true;
            }
            return retorno;
        }

        

        public override string ToString()
        {
            return  "Marca: "+ this.Marca + " - Color: " + this.Color ;
        }

    }
}
