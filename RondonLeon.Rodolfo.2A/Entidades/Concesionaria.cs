using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        public double PrecioDeAutos
        {
            get
            {
                double ret = 0;
                foreach(Vehiculo item in this.vehiculos)
                {
                    if(item is Auto)
                    {
                        ret += (Single)((Auto)item);
                    }
                }
                return ret;
            }
        }

        public double PrecioDeMotos
        {
            get
            {
                double ret = 0;
                foreach (Vehiculo item in this.vehiculos)
                {
                    if (item is Moto)
                    {
                        ret += (Single)((Moto)item);
                    }
                }
                return ret;
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.PrecioDeAutos + this.PrecioDeMotos;
            }
        }

        private Concesionaria()
        {
            
        }

        private Concesionaria(int capacidad) : this()
        {
            this.vehiculos = new List<Vehiculo>(capacidad);
            this.capacidad = capacidad;
        }

        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }

        public static string Mostrar(Concesionaria c)
        {
            string retorno = "*****************\nListado de Vehiculos\n*****************\n";
            retorno += "Capacidad: " + c.capacidad.ToString();
            retorno += "\nTotal por Autos: " + c.PrecioDeAutos.ToString();
            retorno += "\nTotal por Motos: " + c.PrecioDeMotos.ToString();
            retorno += "\nTotal: " + c.PrecioTotal.ToString();
            foreach(Vehiculo item in c.vehiculos)
            {
                retorno += "\n" + item;
            }
            return retorno;
        }

        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            double retorno;

            if(tipoVehiculo == EVehiculo.PrecioDeAutos)
            {
                retorno = this.PrecioDeAutos;
            }
            else if(tipoVehiculo == EVehiculo.PrecioDeMotos)
            {
                retorno = this.PrecioDeMotos;
            }
            else
            {
                retorno = this.PrecioTotal;
            }
            return retorno;
        }

        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            bool retorno = false;
            foreach(Vehiculo item in c.vehiculos)
            {
                if(item == v)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }


        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }

        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if(c.capacidad >= c.vehiculos.Count)
            {
                if(c != v)
                {
                    c.vehiculos.Add(v);
                }
                else if(c == v)
                {
                    Console.WriteLine("El vehiculo ya esta en la concecionaria!!!");
                }
                    
            }
            else 
            {
                Console.WriteLine("No hay mas lugar en la concecionaria!!!");
            }
            return c;    
        }
    }
}
