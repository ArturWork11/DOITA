using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioConcessionaria
{
    internal class Macchina : Prodotto
    {
        public Prodotto Prodotto { get; set; }
        public int Cilindrata {  get; set; }
        public int VelocitaMax {  get; set; }
        public int PostiMacchina { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCilindrata: {Cilindrata} \nVelocita Massima: {VelocitaMax}km/h \nPosti Auto:{PostiMacchina} \nAuto Potente: {(Potente() ? "si" : "no")}\n-----------------\n";
        }
        public bool Potente()
        {
            if (Cilindrata > 2000 && Famoso())
                return true;
            else 
               return false;
        }
    }
}
