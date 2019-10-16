using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16_10;


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Recibo r1 = new Recibo();
            Recibo r2 = new Recibo(3);
            Factura f1 = new Factura(2);
            Documento d1 = new Documento(4);

            Contabilidad<Factura, Recibo> c1 = new Contabilidad<Factura, Recibo>();
            c1 = c1 + f1;
            Console.WriteLine("Se agrego");
            c1 = c1 + r1;
            c1 = c1 + r2;

            Console.ReadLine();
        }
    }
}
