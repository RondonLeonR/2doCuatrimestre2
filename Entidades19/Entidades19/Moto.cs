using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades19
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private short ruedas;
        private int valorHora;

        private Moto() : this("      ",0)
        {

        }

        public Moto(string patente, int cilindrada) : this(patente, cilindrada,2)
        {

        }

        public Moto(string patente, int cilindrada, short ruedas): this(patente, cilindrada,ruedas, 30)
        {

        }

        public Moto(string patente, int cilindrada, short ruedas, int valorHora) : base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = ruedas;
            this.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            string retorno = "";
            retorno += base.ImprimirTicket();
            retorno += "\nCilindrada: " + this.cilindrada.ToString() + "\nRuedas: " + this.ruedas.ToString() + "\n";
            return retorno;
        }

        public override bool Equals(object obj)
        {
            if(obj is Moto)
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
