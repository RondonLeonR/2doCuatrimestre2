using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Avion : Vehiculo , IAFIP , IARBA
    {
        protected double _velocidadMaxima;

        public Avion(double precio, double velMax) : base(precio)
        {
            this._velocidadMaxima = velMax;
        }

        double IARBA.CalcularImpuesto()
        {
            return this._precio * .27;
        }

        public override void MostrarPrecio()
        {
            Console.WriteLine(base._precio);
        }

        double IAFIP.CalcularImpuesto()
        {
            return base._precio * .33;
        }
    }
}
