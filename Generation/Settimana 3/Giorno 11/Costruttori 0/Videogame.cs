using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costruttori

{
    //CLASSE MODELLO: è una classe che ha lo scopo di definire le caratteristiche 
    //e i metodi che gli oggetti creati con questo modello avranno
    //è un elemento astratto quindi le proprietà inserite non avranno valori specifici
    //
    internal class Videogame
    {
        //PROPRIETA' appartengono agli oggetti creati con questo modello, ma non sono della class
        //senza un'oggetto di questo tipo non posso richiamare le proprietà qui sotto elencate
        public string titolo;
        public string console;
        public string data;
        public string sviluppatori;
        public int votoCritica;
        public int votoUtente;
        public string genere;

        //metodi/comportamenti o azioni che un videogioco sa fare, anche in questo caso i metodi
        //NON sono della classe ma degli oggetti che verranno creati tramite essa
        //senza un oggetto concreto non posso accedere ai metodi qui descritti

        //PER CONVENIONE in una classe modello dopo le proprietà si inserisce il costruttore se non si vuole usare quello implicito
        //il COSTRUTTORE è un METODO PARTICOLARE, diverso da tutti gli altri perché ha lo scopo di creare oggetti 
        //a differenza degli altri metodi, NON ha un tipo di RITORNO e il NOME è uguale a quello della CLASSE

        //ESPLICITO il costruttore implicito, quello di default vuoto()
        public Videogame(string valore1, string valore2)
        {
            titolo = valore1;   // Mario Party
            console =valore2;   // Switch
                                //Stampera' anche il resto della scheda ma i valori delle proprieta' sara' quello
                                //di default             
        }

        public Videogame(string titolo, string console)
        {

        }

        //metodo Scheda() -> rappresenta in stringa le caratteristische specifiche di un'oggetto
        //lo descrive, serve quando abbiamo bisogno di una panoramica dell'oggetto
        //string Scheda() --> FIRMA DI UN METODO
        public string Scheda()
        {
            string risultato = "";
            risultato = $"Titolo {titolo} \nConsole: {console} \nData Rilascio: {data} \nCasa Porduttrice: {sviluppatori} \nVoto critica: {votoCritica} \nVoto Utente: {votoUtente} \nGenere: {genere}";
            return risultato; //return stoppa il metodo e restituisce il valore dopo di esso
        }

        public double Media()
        {
            double somma = votoCritica + votoUtente;
            return (somma > 0) ? somma / 2 : 0;
        }

        public int etaVideogioco()
        {
            if (data != null)
            {
                //data pubblicazione -> 2-11-2001
                //data.Split('-')
                int annoPubbl = int.Parse(data.Split('-')[2]);
                int annoCorrente = DateTime.Now.Year;
                return annoCorrente - annoPubbl;

            }
            return -1;
        }
    }
}
