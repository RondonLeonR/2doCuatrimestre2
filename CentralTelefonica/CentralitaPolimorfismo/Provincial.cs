using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CentralitaPolimorfismo
{
    public class Provincial : Llamada
    {
        protected Franja _franjaHoraria;

        public override float CostoLLamada
        {
            get
            {
                return CalcularCosto();
            }
        }

        public Provincial(Franja miFranja, Llamada unallamada): this(unallamada.NroOrigen, miFranja, unallamada.Duracion, unallamada.NroDestino)
        {
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino): base(origen,destino,duracion)
        {
            this._franjaHoraria = miFranja;
        }


        private float CalcularCosto()
        {
            float retorno;
            if(this._franjaHoraria == Franja.Franja_1)
            {
                retorno = this._duracion * (float)0.53;
            }
            else if(this._franjaHoraria == Franja.Franja_2)
            {
                retorno = this._duracion * (float)1.25; 
            }
            else
            {
                retorno = this._duracion * (float)0.66;
            }
            return retorno;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Provincial)
            {
                retorno = true;
            }
            return retorno;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar() + "\nFranja Horaria: " + this._franjaHoraria + "\nCosto de Llamada: " + this.CostoLLamada.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
