using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Local : Llamada
    {
        protected float _costo;

        public override float CostoLLamada
        {
            get
            {
                return CalcularCosto();
            }
        }

        public Local(Llamada unaLLamada, float costo) : this(unaLLamada.NroOrigen,unaLLamada.Duracion,unaLLamada.NroDestino,costo)
        {

        }

        public Local(string origen, float duracion, string destino, float costo) : base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        private float CalcularCosto()
        {
            return this._costo * this.Duracion;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Local)
            {
                retorno = true;
            }
            return retorno;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar() + "\nCosto de Llamada: " + this.CostoLLamada.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

    }
}
