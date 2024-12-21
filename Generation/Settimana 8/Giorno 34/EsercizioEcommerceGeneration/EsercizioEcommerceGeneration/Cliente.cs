using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class Cliente : Entity
    {

        public string Username { get; set; }
        public DateTime DataIscrizione { get; set; }
        public bool Maggiorenne { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Username: {Username} \nData iscrizione: {DataIscrizione} \nMaggiorenne: {(Maggiorenne ? "si" : "no")} \n-------------------------------\n";
        }
    }
}
