using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Deportivo dep = new Deportivo(100000, "AAA123", 220);
            Privado avionPrivado = new Privado(1000000, 400, 4);
            Comercial avionComercial = new Comercial(500000, 350, 150);
            Carreta carr = new Carreta(1000);

            Console.WriteLine(Gestion.MostrarImpuestoNacional(dep));
            Console.WriteLine(Gestion.MostrarImpuestoNacional(avionPrivado));
            Console.WriteLine(Gestion.MostrarImpuestoNacional(avionComercial));

            Console.WriteLine("\n"+Gestion.MostrarImpuestoProvincial(carr));
            Console.WriteLine(Gestion.MostrarImpuestoProvincial(dep));
            Console.WriteLine(Gestion.MostrarImpuestoProvincial(avionPrivado));
            Console.WriteLine(Gestion.MostrarImpuestoProvincial(avionComercial));

            Console.ReadLine();
        }
    }
}
