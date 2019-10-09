using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected Random generadorDeVelocidades = new Random();
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima ;

        public int VelocidadMaxima
        {
            get
            {
                if(velocidadMaxima == 0)
                {
                      velocidadMaxima = generadorDeVelocidades.Next(100, 280); 
                }
                return velocidadMaxima;
            }
        }

        private Vehiculo()
        {
            
        }

        public Vehiculo(float precio, string modelo, Fabricante fabri) : this()
        {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
        }

        public Vehiculo(string marca, EPais pais, string modelo, float precio): this(precio,modelo,new Fabricante(marca,pais))
        {

        }

        public static explicit operator string(Vehiculo v)
        {
            return v.Mostrar(v);
        }

        private string Mostrar(Vehiculo v)
        {
            string retorno = "";
            retorno += "Fabricante: " + v.fabricante + "\nModelo: " + this.modelo + "\nPrecio: " + this.precio.ToString() + "\nVelocidad Maxima: " + this.VelocidadMaxima.ToString();
            return retorno;
        }

        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool retorno = false;
            if(a.fabricante == b.fabricante)
            {
                if(string.Equals(a.modelo,b.modelo))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }

    }
}
