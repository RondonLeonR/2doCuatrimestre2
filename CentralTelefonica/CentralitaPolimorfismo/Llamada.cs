using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public abstract class Llamada
    {
        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public abstract float CostoLLamada { get; }
        public float Duracion
        {
            get
            {
                return this._duracion;
            }
        }

        public string NroDestino
        {
            get
            {
                return this._nroDestino;
            }
        }

        public string NroOrigen
        {
            get
            {
                return this._nroOrigen;
            }
        }

        public Llamada(string origen, string destino, float duracion)
        {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Origen: " + this.NroOrigen + "\nDestino: " + this.NroDestino + "\nDuracion: " + this.Duracion.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Llamada uno, Llamada dos)
        {
            bool retorno = false;
            if(Equals(uno,null) && Equals(dos,null))
            {
                if(string.Equals(uno.NroDestino, dos.NroDestino) && string.Equals(uno.NroOrigen, dos.NroOrigen))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Llamada uno, Llamada dos)
        {
            return !(uno == dos);
        }

        //public int OrdenarPorDuracion(Llamada uno, Llamada dos)
        //{

        //}

    }
}
