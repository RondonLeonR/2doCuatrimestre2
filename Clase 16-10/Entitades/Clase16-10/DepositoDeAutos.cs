using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoDeAutos
    {
        private int _capacidadMaxima;
        private List<Auto> _lista;

        public DepositoDeAutos(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Auto>(this._capacidadMaxima);
        }

        private int GetIndice(Auto a)
        {
            int retorno = -1;
            for(int i = 0; i < this._lista.Count; i++)
            {
                if(this._lista[i] == a)
                {
                    retorno = i;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator +(DepositoDeAutos d, Auto a)
        {
            bool retorno = false;
            if(d._capacidadMaxima > d._lista.Count)
            {
                d._lista.Add(a);
                retorno = true;
            }
            return retorno;
        }

        public static bool operator -(DepositoDeAutos d, Auto a)
        {
            bool retorno = false;
            int indice = d.GetIndice(a);

            if(indice != -1)
            {
                d._lista.RemoveAt(indice);
                retorno = true;
            }
            return retorno;
        }

        public bool Agregar(Auto a)
        {
            return (this + a);
        }

        public bool Remover(Auto a)
        {
            return (this - a);
        }

        public override string ToString()
        {
            string retorno = "Capacidad maxima: " + this._capacidadMaxima;
            retorno += "\nListado de Autos: ";
            foreach(Auto item in this._lista)
            {
                retorno += "\n" + item.ToString();
            }
            retorno += "\n";
            return retorno;
        }
    }
}
