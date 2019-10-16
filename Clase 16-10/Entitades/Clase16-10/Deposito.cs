using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito<T>
    {
        private int _capacidadMaxima;
        private List<T> _lista;

        public Deposito(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<T>(this._capacidadMaxima);
        }

        public static bool operator +(Deposito<T> d, T a)
        {
            bool retorno = false;
            if (d._capacidadMaxima > d._lista.Count)
            {
                d._lista.Add(a);
                retorno = true;
            }
            return retorno;
        }

        public static bool operator -(Deposito<T> d, T a)
        {
            bool retorno = false;
            int indice = d.GetIndice(a);

            if (indice != -1)
            {
                d._lista.RemoveAt(indice);
                retorno = true;
            }
            return retorno;
        }

        private int GetIndice(T a)
        {
            int retorno = -1;
            for (int i = 0; i < this._lista.Count; i++)
            {
                if (a.Equals(this._lista[i]))
                {
                    retorno = i;
                    break;
                }
            }
            return retorno;
        }

        public bool Agregar(T a)
        {
            return (this + a);
        }

        public bool Remover(T a)
        {
            return (this - a);
        }

        public override string ToString()
        {
            string retorno = "Capacidad maxima: " + this._capacidadMaxima.ToString();
            retorno += "\nListado de " + typeof(T).Name + ":";
            foreach (T item in this._lista)
            {
                retorno += "\n" + item.ToString();
            }
            retorno += "\n";
            return retorno;
        }
    }
}
