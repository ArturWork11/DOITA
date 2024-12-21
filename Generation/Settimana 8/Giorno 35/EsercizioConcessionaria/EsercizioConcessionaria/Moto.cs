using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioConcessionaria
{
    internal class Moto : Prodotto
    {
        public Prodotto Prodotto { get; set; }
        public bool Passeggeri {  get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nPasseggeri: {(Passeggeri ? "si" : "no")} \nMoto da viaggi in compagnia: {(InCompagnia() ? "si" : "no")}\n-----------------\n";
        }

        public bool InCompagnia()
        {
            if (Passeggeri && KMPercorribili() > 100)
                return true;
            else 
                return false;
        }
    }
}
