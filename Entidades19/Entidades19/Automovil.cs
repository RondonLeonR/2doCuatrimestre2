using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades19
{
    public class Automovil : Vehiculo
    {
        private ConsoleColor color;
        private int valorHora;

        public Automovil(string patente, ConsoleColor color) : this(patente,color,50)
        {   
        }

        private Automovil() : this("      ",ConsoleColor.Black)
        {
        }

        public Automovil(string patente,ConsoleColor color,int valorHora) : base(patente)
        {
            this.Patente = patente;
            this.color = color;
            this.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            string retorno = "";
            retorno += base.ImprimirTicket();
            retorno += "\nColor: " + this.color.ToString() + "\n";
            return retorno;
        }

        public override bool Equals(object obj)
        {
            if(obj is Automovil)
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

            retorno += base.ImprimirTicket() + "\nCosto de Estadia: " + costoEstadia.ToString() + "\n";
            return retorno;
        }
    }
}
