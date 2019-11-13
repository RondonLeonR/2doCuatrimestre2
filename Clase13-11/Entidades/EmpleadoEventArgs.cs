using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoEventArgs : EventArgs
    {
        
        private double sueldo;

        public double SueldoAsignar
        {
            get
            {
                return sueldo;
            }
            set
            {
                sueldo = value;
            }
        }

        
    }
}
