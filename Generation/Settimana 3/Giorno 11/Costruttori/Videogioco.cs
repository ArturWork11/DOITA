using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costruttori
{
    internal class Videogioco
    {
        //PROPRIETA' apparterranno agli oggetti creati con questo modello, non sono della classe
        //senza un oggetto di questo tipo non posso richiamare le proprietà qui sotto elencate
        public string titolo;
        public string console;
        public string dataPubblicazione;
        public string studioSviluppo;
        public int votoCritica;
        public int votoUtente;
        public string genere;


        //metodi/comportamenti o azioni che un videogioco sa fare, anche in questo caso i metodi
        //NON sono della classe ma degli oggetti che verranno creati tramite essa
        //senza un oggetto concreto non posso accedere ai metodo qui inseriti

        //per conveninzione in una classe modello dopo le proprietà si inserisce il costruttore se non vuole usare quello implicito
        //il COSTRUTTORE è un METODO particolare, diverso da tutti gli altri perché ha il scopo di creare oggetti
        //a differenza degli altri metodo NON HA un TIPO di RITORNO e il NOME è uguale a quello della CLASSE

        //ESPLICITO il costruttore implicito, quello di default - VUOTO
        public Videogioco()
        {
            //questo costruttore è sempre presente anche se non lo esplicito MA si DISATTIVA quando dichiaro un altro costruttore
            //per manterlo attivo devo per forza esplicitarlo
        }

        //avendo videogioco 7 proprietà, se alla creazione di un oggetto voglio valorizzarle tutte devo passare
        //al costruttore 7 valori in input ovviamente che corrispondano al tipo della proprietà
        //non voglio più fare questo videogioco.titolo = "Mario Party"; dopo la creazione ma lo faccio nel mentre
        public Videogioco(string input1, string input2)//prendo il primo parametro/valore in input e lo assegno alla proprietà titolo
        {
            titolo=input1;
            console=input2;

        }

        public Videogioco(string valore1,int valore2)
        {
            titolo =valore1;
            votoCritica =valore2;
        }

        public Videogioco(string titolo,string console, string dataPubblicazione, string studioSviluppo,int votoCritica,int votoUtente,string genere)
        {
            //titolo = titolo; assegno il valore del parametro titolo alla proprietà titolo -> genere AMBIGUITA'
            //per evitare questo problema bisogna specificare al programma qual è la PROPRIETA'
            this.titolo = titolo; //THIS indica un'ISTANZA di questa classe -> videogioco.titolo = "Mario Party";
            this.console = console;
            this.studioSviluppo=studioSviluppo;
            this.votoCritica=votoCritica;
            this.votoUtente=votoUtente;
            this.genere = genere;
            this.dataPubblicazione = dataPubblicazione;
        }


        //metodo Scheda() -> rappresenta in stringa le caratteristiche specifiche di un oggetto
        //lo descrive, serve quando abbiamo bisogno di una panoramica dell'oggetto
        //string Scheda() -> FIRMA DI un METODO
        public string Scheda()
        {
            string ris = "";

            ris = $"Titolo: {titolo}\n" +
                  $"Console: {console}\n" +
                  $"Data di pubblicazione: {dataPubblicazione}\n" +
                  $"Studio di sviluppo: {studioSviluppo}\n" +
                  $"Voto della critica: {votoCritica}\n" +
                  $"Voto dell' utente: {votoUtente}\n" +
                  $"Genere: {genere}\n" +
                  $"Voto medio: {votoMedio()}\n" +
                  $"Da quanto è pubblicato: {etaVideogioco()}\n";
            return ris;//return stoppa il metodo e restituice il valore indicato dopo di esso
        }

        //METODO che restituisce il valore medio dei voti
        // .votoMedio() -> dato dalla media tra votodell'utente e voto della critica
        public double votoMedio()
        {
            double somma = votoCritica + votoUtente;
            return (somma > 0) ? somma / 2 : 0;
        }


        //metodo che restituisce da quanti anni il video gioco è stato pubblicato
        //.etaVideogioco() -> da quanti anni è stato pubblicato
        public int etaVideogioco()
        {
            if (dataPubblicazione != null)
            {
                //dataPubblicazione -> 2-11-2001
                //dataPubblicazione.Split("-"); ottengo 3 stringhe, la prima contiene il giorno, òa seconda il mese, la terza l'anno
                int annoPubbl = int.Parse(dataPubblicazione.Split("-")[2]);
                //DateTime dataNascita = DateTime.ParseExact(dataPubblicazione, "dd-MM-yyyy", null);
                int annoCorrente = DateTime.Now.Year;
                return annoCorrente - annoPubbl;//se esiste una data di pubblicazione restituisco l'età del gioco

            }
            return -1;
        }
    }
}
