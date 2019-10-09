using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades19
{
    public class PickUp : Vehiculo
    {
        private string modelo;
        private int valorHora;

        private PickUp() : this("      ","xxxxx")
        {
        }

        public PickUp(string patente, string modelo) : this(patente, modelo, 70)
        {
        }

        public PickUp(string patente, string modelo, int valorHora) : base(patente)
        {
            this.modelo = modelo;
            this.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            string retorno = "";
            retorno += base.ImprimirTicket();
            retorno += "\nModelo: " + this.modelo + "\n";
            return retorno;
        }

        public override bool Equals(object obj)
        {
            if(obj is PickUp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ImprimirTicket()
        {
            float costoEstadia;
            TimeSpan horasEstadia;
            string retorno = "";

            horasEstadia = DateTime.Now.Subtract(base.ingreso);
            costoEstadia = horasEstadia.Hours * this.valorHora;

            retorno += base.ImprimirTicket() + "\nCosto de Estadia: " + costoEstadia.ToString();
            return retorno;
        }

    }
}
