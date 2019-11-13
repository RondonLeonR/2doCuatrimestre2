using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Empleado e = new Empleado("Juan", "Perez", 123);
            e.limiteSueldo += new limiteSueldoDelegado(Sueldo);
            e.limiteSueldoMejorado += new LimiteSueldoMejorado(SueldoMejorado);

            //Manejador limite sueldo
            //manejador limite sueldo mejorado
            //manejador limite sueldo mejorado 2 NO STATICOS

            e.Sueldo = 33000;

            Console.WriteLine(e.ToString());
            Console.ReadLine();
        }

        public static void Sueldo(double sueldo, Empleado aux)
        {
            Console.WriteLine("Sueldo mayor a 18000 ---> " + aux.ToString() + " - " + sueldo.ToString());
        }

        public static void SueldoMejorado(Empleado eAux, EventArgs ev)
        {
            Console.WriteLine("Sueldo mayor a 30000 ---> " + eAux.ToString(), ev.ToString());
        }

        public void ManejadorLimiteSueldo(double sueldo, Empleado e)
        {
            Console.WriteLine("Sueldo mayor a 18000 ---> " + e.ToString() + " - " + sueldo.ToString());
        }

        public void ManejadorLimiteSueldoMejorado(Empleado e, EventArgs ev)
        {
            Console.WriteLine("Sueldo mayor a 30000 ---> " + e.ToString(), ev.ToString());
        }

        public void ManejadorLimiteSueldoManejadorDos(double sueldo, Empleado e, EventArgs ev)
        {

        }
    }
}
