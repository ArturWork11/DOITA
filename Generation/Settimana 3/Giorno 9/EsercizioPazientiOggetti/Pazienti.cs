using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioOspedaleOggetti
{
    internal class Pazienti
    {
        public string nome;
        public string cognome;
        public string dataNascita;
        public string malattia;
        public string reparto;
        public int giorno;
        public int mese;
        public int anno; 
        public string scheda()
        {
            string dati = "";
            dati = $"Nominativo: {nome} {cognome}\nData di nascita: {dataNascita}\nMalattia: {malattia}\nReparto: {reparto}";
            return dati;
        }
    }
}
