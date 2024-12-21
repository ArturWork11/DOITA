using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneClassiMacchine
{
    internal class Macchina
    {
        public string marca;
        public string modello;
        public string colore;
        public int anno;
        public bool ariaCondizionata = false;
        public bool cerchiInLega = false;



        public string Scheda()
        {
            string ris = "";
            ris = $"marca: {marca}\nmodello: {modello}\ncolore: {colore}\nanno: {anno}\naria condizionata: {(ariaCondizionata ? "presente" : "assente")}\nCherchi in Lega: {(cerchiInLega ? "presenti" : "assenti")}";
            return ris;
        }
    }
}
