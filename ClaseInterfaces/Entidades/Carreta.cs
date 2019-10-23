using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carreta : Vehiculo , IARBA
    {
        public Carreta(double precio) : base (precio)
        { }

        double IARBA.CalcularImpuesto()
        {
            return this._precio * .18;
        }

        public override void MostrarPrecio()
        {
            Console.WriteLine(base._precio);
        }
    }
}
