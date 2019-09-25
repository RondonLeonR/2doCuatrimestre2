using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;

        public float GananciaPorLocal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Local);
            }
        }

        public float GananciaPorProvincial
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Provincial);
            }
        }

        public float GananciaTotal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return this._listaDeLlamadas;
            }
        }

        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa) : this()
        {
            this._razonSocial = nombreEmpresa;
        }

        private void AgregarLLamada(Llamada nuevaLLamada)
        {
            this._listaDeLlamadas.Add(nuevaLLamada);
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float retorno = 0;
            if(tipo == TipoLlamada.Local)
            {
                foreach (Local item in this._listaDeLlamadas)
                {
                    if(item is Local)
                        retorno += item.CostoLLamada;
                }
            }
            else if(tipo == TipoLlamada.Provincial)
            {
                foreach(Provincial item in this._listaDeLlamadas)
                {
                    if(item is Provincial)
                        retorno += item.CostoLLamada;
                }
            }
            else if(tipo == TipoLlamada.Todas)
            {
                foreach(Llamada item in this._listaDeLlamadas)
                {
                    retorno += item.CostoLLamada;
                }
            }

            return retorno;
        }

        public static bool operator ==(Centralita central, Llamada nuevaLlamada)
        {

        }

        public static bool operator !=(Centralita central, Llamada nuevaLlamada)
        {

        }

        public static bool operator +(Centralita central, Llamada nuevaLlamada)
        {

        }

        public void OrdenarLLamadas()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    //costo * duracion
}
