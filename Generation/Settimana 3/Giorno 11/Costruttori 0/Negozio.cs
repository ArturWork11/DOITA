using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costruttori
{
    /*classe AGGREGATRICE 
     si occupa di svuotare il program da dati che non gli competono -> divisione delle responsabilità
     si occupa di gestire gli oggetti creati tramite i vari modelli (anche la lettura dei file)
    si occupa di fare tutti i calcoli necessari al programma se inerenti a più oggetti
     */
    internal class Negozio
    {
        //PROPRIETA'    
        public string nome;
        List<Videogame> videogiochi;
        public string indirizzo;

        //COSTRUTTORE
        public Negozio()
        {
            //-leggere il file
            //ReadAllLines restituisce un ARRAY
            string[] datiFile = File.ReadAllLines("../../../Dati.txt");
            List<Videogame> videogames = new List<Videogame>(); //creo una lista che può contenere solo oggetti di tipo videogioco

            //-prendere i dati e separarli
            // DatiFile[0]













        
        }

        //ALTRI METODI

        //metodo che scorre la lista dei videogiochi e ne stampa la scheda ->
        //in concreto stampa il valore della proprietà videogiochi(lista) di un oggetto di tipo Negozio
        public string Catalogo()
        {
            //scorro la lista e di ogni videogioco prendi il valore di Scheda() e lo salvo in una stringa, concatenando man mano le varie schede
            string ris = "";
            for (int i = 0;i < videogiochi.Count;i++) 
            {
                ris += videogiochi[i].Scheda + "\n"; //accedo alla lista, indicando l'indice 
            }
    }
}
