using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades19
{
    public abstract class Vehiculo
    {
        protected DateTime ingreso;
        private string patente;

        public string Patente
        {
            get
            {
                return this.patente;
            }
            set
            {
                if(value.Length == 6)
                {
                    this.patente = value;
                }
                else
                {
                    this.patente = "Error";
                }
            }
        }

        public abstract string ConsultarDatos();

        public virtual string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\nIngreso: {1}", this.ToString(), this.ingreso.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool retorno = false;
            if(string.Equals(v1.Patente,v2.Patente) && Automovil.Equals(v1,v2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        public override string ToString()
        {
            return string.Format("Patente: {0}", this.Patente);
        }

        public Vehiculo(string patente)
        {
            this.ingreso = DateTime.Now.AddHours(-3);
            this.Patente = patente;
        }
    }
}
