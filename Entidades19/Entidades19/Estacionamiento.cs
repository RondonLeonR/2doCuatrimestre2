using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades19
{
    public class Estacionamiento
    {
        private int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;

        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>(espacioDisponible);
        }

        public Estacionamiento(string nombre,int espacioDisponible) : this()
        {
            this.nombre = nombre;
            this.espacioDisponible = espacioDisponible;

        }

        public static explicit operator string (Estacionamiento e )
        {
            string retorno = "";
            retorno += e.nombre + "\n" + e.espacioDisponible.ToString();
            foreach(Vehiculo item in e.vehiculos)
            {
                retorno += "\n" + item.ConsultarDatos();
            }
            return retorno;

        }

        public static bool operator ==(Estacionamiento e , Vehiculo v)
        {
            bool retorno = false;
            foreach(Vehiculo item in e.vehiculos)
            {
                if(item == v)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }

        public static string operator -(Estacionamiento e, Vehiculo v)
        {
            string retorno = "";
            if(e == v)
            {
                retorno = v.ImprimirTicket();
                e.vehiculos.Remove(v);
            }
            else
            {
                retorno = "El vehiculo no es parte del estacionamiento";
            }
            return retorno;
        }

        public static Estacionamiento operator +(Estacionamiento e, Vehiculo v)
        {
            if(e != v)
            {
                if(v.Patente.Length == 6 )
                {
                    if(e.espacioDisponible > e.vehiculos.Count)
                    {
                        e.vehiculos.Add(v);
                    }
                }
            }
            return e;
        }

    }
}
