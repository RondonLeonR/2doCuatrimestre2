using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoDeCocinas
    {
        private int _capacidadMaxima;
        private List<Cocina> _lista;

        public DepositoDeCocinas(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Cocina>(capacidad);
        }

        public static bool operator +(DepositoDeCocinas d, Cocina c)
        {
            bool retorno = false;
            if (d._capacidadMaxima > d._lista.Count)
            {
                d._lista.Add(c);
                retorno = true;
            }
            return retorno;
        }

        public static bool operator -(DepositoDeCocinas d, Cocina c)
        {
            bool retorno = false;
            int indice = d.GetIndice(c);

            if (indice != -1)
            {
                d._lista.RemoveAt(indice);
                retorno = true;
            }
            return retorno;
        }

        private int GetIndice(Cocina c)
        {
            int retorno = -1;
            for (int i = 0; i < this._lista.Count; i++)
            {
                if (this._lista[i] == c)
                {
                    retorno = i;
                    break;
                }
            }
            return retorno;
        }

        public bool Agregar(Cocina c)
        {
            return this + c;
        }

        public bool Remover(Cocina c)
        {
            return this - c;
        }

        public override string ToString()
        {
            string retorno = "Capacidad maxima: " + this._capacidadMaxima;
            retorno += "\nListado de Cocinas ";
            foreach (Cocina item in this._lista)
            {
                retorno += "\n" + item.ToString();
            }
            retorno += "\n";
            return retorno;
        }
    }
}
