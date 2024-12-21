using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Il namespace eè un'area di codice che ci permette di tenere le varie definizioni di classi, categorizzandole sotto un nome specifico
namespace ClassiProgrammazioneAdOggetti
{
    // Nel nome di una classe per convenzione si usa il PascalCase (Quindi prima lettera Maiuscola e poi anche le altre parole con la Maiuscola)

    //internal sta semplicemente a dire che questa è utilizzabile solo all'interno di questo progetto
    internal class Persona

    {
        // Questi campi se non specificato sono di base 'Private' e quindi non visibili
        // Per renderli visibili devo cambiare la loro visibilità scrivendo 'public'
        public string nome;
        public string cognome;
        public int eta;

        //Una classe può avere dei metodi, i metodi sono set di istruzioni o blocchi di codice che io posso richiamare quando ne ho bisogno
        //I metodi possono restituire un valore (ad esempio l'output di un calcolo) oppure no
        //I nomi dei metodi sono scritti in PascalCase (come la classe)
        public string Scheda()
        {
            string risultato = "";

            risultato = $"Nominativo: {nome} {cognome}\nAnni: {eta}";

            return risultato;
        }
    }
}
