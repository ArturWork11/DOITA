using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace ImperoCRUD
{
    internal class Battaglia : Entity
    {
        public string Nemico { get; set; }
        public DateTime Data_battaglia {  get; set; }
        public bool Vincitore { get; set; }
        public string Luogo {  get; set; }
        public Imperatore Imperatore { get; set; } // Fare in modo che la properties NON SI CHIAMI come la colonna

        public override void FromDictionary(Dictionary<string, string> riga)
        {
            if (riga["idimperatore"] != "" && riga["idimperatore"].ToLower() != "null")
                Imperatore = (Imperatore)DAOImperatori.GetInstance().Find(int.Parse(riga["idimperatore"]));


            base.FromDictionary(riga);
        }

        public override string ToString()
        {
            return base.ToString() + $"Nemico {Nemico} \nCombattuta il: {Data_battaglia.ToString("dd-MM-yyyy")} a {Luogo} \nVincitore: {(Vincitore ? "Romani" : Nemico)} \nImperatore: {(Imperatore != null ? Imperatore.Nome : "Sconosciuto")} \n--------------------------------\n";
        }
    }
}
