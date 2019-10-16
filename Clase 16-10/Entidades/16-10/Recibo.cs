using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_10
{
    public class Recibo : Documento
    {
        public Recibo(): base(0)
        {
        }

        public Recibo(int numero) : base(numero)
        {
        }
    }
}
