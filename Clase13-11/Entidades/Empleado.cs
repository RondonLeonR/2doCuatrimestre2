using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        public event limiteSueldoDelegado limiteSueldo;
        public event LimiteSueldoMejorado limiteSueldoMejorado;
        private string nombre;
        private string apellido;
        private int legajo;
        private double sueldo;

        private TipoManejador tipoManejador;

        #region Propiedades

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }

        public double Sueldo
        {
            get
            {
                return this.sueldo;
            }
            set
            {
                try
                {
                    if(value > 30000)
                    {
                        EmpleadoEventArgs e2 = new EmpleadoEventArgs();
                        e2.SueldoAsignar = value;
                        this.limiteSueldoMejorado(this, e2);
                    }
                    else if (value > 18000)
                    {
                        this.limiteSueldo(value, this);
                    }
                    else
                    {
                        this.sueldo = value;
                    }
                }
                catch (Exception)
                {

                }
                   
            }
        }

        #endregion

        public Empleado(string nombre, string apellido, int legajo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.legajo = legajo;
        }

        public override string ToString()
        {
            return this.nombre + " - " + this.apellido + " - " + this.legajo.ToString() + " - " +this.sueldo.ToString();
        }

        

    }
}
