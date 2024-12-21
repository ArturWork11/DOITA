using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costruttori
{
    /*classe MODELLO AGGREGATRICE:
     - si occupa di svuotare il program da dati che non gli competono -> divisione delle RESPONSABILITA'
     - si occupa di gestire gli oggetti creati tramite i vari modelli(anche la lettura dei dati)
     - si occupa di fare tutti i calcoli necessari al programma se inerenti a più oggetti 
     */
    internal class Negozio
    {
        //PROPRIETA'
        public string nome;
        public List<Videogioco> videogiochi;
        public string indirizzo;

        //COSTRUTTORE

        public Negozio(string percorso,string nome,string indirizzo)//il percorso 
        {

            //la proprietà è in bianco, il parametro in input è in azzurro
            this.nome = nome;
            this.indirizzo = indirizzo;

            //-leggere il file
            //ReadAllLines resituisce un ARRAY
            string[] datiFile = File.ReadAllLines(percorso);
            videogiochi = new List<Videogioco>();//creo una lista che può contenere solo oggetti di tipo Videogioco

            //-prendere i dati e separarli
            //datiFile[0] = Final Fantasy X;PlayStation 2;12-11-2001;Squaresoft;87;95;RPG
            for (int i = 0; i < datiFile.Length; i++)
            {
                //separo i dati prendendo una riga per volta e divendola per il separatore
                //so che ogni riga è salavata nell'array datiFile
                //per accedere ad una cella di un array -> nomeArray[indiceCella]
                //così prendo la prima cella: datiFile[i]
                //datiFile[i].Split(";"); -> genero tante stringhe tanti ; ci sono nella stringa della cella all'indice i
                //questo passaggio genera un array 
                string[] datiRiga = datiFile[i].Split(";");//Final Fantasy X;PlayStation 2;12-11-2001;Squaresoft;87;95;RPG
                                                           //datiRiga[0] = "Final Fantasy X";

                //creare i videogiochi e salvare in essi i dati letti dal file
                Videogioco v = new Videogioco(datiRiga[0],
                                              datiRiga[1],
                                              datiRiga[2],
                                              datiRiga[3],
                                              int.Parse(datiRiga[4]),
                                              int.Parse(datiRiga[5]),
                                              datiRiga[6]);//usando il costruttore parametrizzato i valori passati in input vengono assegnati direttamente 
                                                           //alle proprietà dell'oggetto v in automatico

                //a questo punto ho preso tutti i dati di una riga e li ho assegnati alle proprietà dell'oggetto v
                //per non perdere l'oggetto e i suoi dati
                //salvare i videogiochi in una lista
                videogiochi.Add(v);

            }



        }

        //ALTRI METODI
        
        //metodo che scorre la lista dei videogiochi e ne stampa la scheda->
        //in concreto stampa il valore della proprietà videogiochi(lista) di un oggetto di tipo Negozio
        public string Catalogo()
        {
            //scorro la lista e di ogni videogioco prendi il valore di Scheda() e lo salvo in una stringa, concatenando man mano le varie schede
            string ris = "";
            for (int i = 0; i < videogiochi.Count; i++)
            {
                ris += videogiochi[i].Scheda() + "\n";//accedo alla lista, indicando l'indice prendo cella, nella cella c'è un oggetto
                //cin il . invoco un suo metodo in questo caso Scheda() e salvo il valore di ritorno, che è una stringa nella variabile ris 
            }
            return ris;
        }

        //metodo che trova il viedeogioco con la media di voti più alta
        //applica dei calcoli su un'insieme di oggetti gestiti dal negozio

        public List<Videogioco> VideogiocoMediaMax()
        {
            //- trovare il videogioco con la media più alta
            double mediaMax = videogiochi[0].votoMedio();
            List<Videogioco> vMax = new List<Videogioco>();
            for (int i = 1; i < videogiochi.Count; i++)
            {
                //prendo il primo videogioco e confronto la sua media con quella del secondo, se è più alta salvo il videogioco nella lista
                if (videogiochi[i].votoMedio() > mediaMax)
                {
                    mediaMax = videogiochi[i].votoMedio();
                    vMax.Clear();
                    vMax.Add(videogiochi[i]);
                }
                else if (videogiochi[i].votoMedio() == mediaMax)
                {
                    vMax.Add(videogiochi[i]);
                }
            }
            return vMax;
        }


        //metodo che ricerca videogiochi per GENERE e STUDIO di sviluppo
        public List<Videogioco> CercaPerGenereEStudio(string genere,string studio)
        {
            List<Videogioco> lista = new List<Videogioco>();
            //prendo videogioco per videogioco e vado a vedere il valore della su proprietà studioSviluppo e genere
            for (int i = 0; i < videogiochi.Count; i++)
            {
                if (videogiochi[i].genere.ToLower() == genere.ToLower() && videogiochi[i].studioSviluppo.ToLower() == studio.ToLower())
                    lista.Add(videogiochi[i]);
            }
            return lista;
        }

        //metodo che data una lista che contiene videogiochi stampi di ogni videogioco la sua scheda.

        for (int i=0)
        
    }
}
