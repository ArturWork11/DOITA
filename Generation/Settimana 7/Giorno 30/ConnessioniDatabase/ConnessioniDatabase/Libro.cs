using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnessioniDatabase
{
    // Questa classe dev'essere il più possibile fedele alla tabella SQL di riferimento (LIBRI).
    // Per questo motivo bisogna cercare di tenere sia i nomi che i tipi il più vicino possibile a quelli del DBMS di riferimento
    internal class Libro : Entity
    {
        //Campi                 //Tabella SQL
        private string titolo;                        // titolo VARCHAR
        private string autore;                        // autore VARCHAR
        private string genere;                        // genere VARCHAR
        private int anno_pubblicazione;               // anno_pubblicazione   INT

        //Properties
        public string Titolo { get => titolo; set => titolo = value; }
        public string Autore { get => autore; set => autore = value; }
        public string Genere { get => genere; set => genere = value; }
        public int Anno_pubblicazione { get => anno_pubblicazione; set => anno_pubblicazione = value; }

        //Costruttore
        public Libro(int id, string titolo, string autore, string genere, int anno_pubblicazione) : base(id)
        {
            Titolo = titolo;
            Autore = autore;
            Genere = genere;
            Anno_pubblicazione = anno_pubblicazione;
        }

        //Metodi
        public override string ToString()
        {
            return base.ToString() +
            $"Titolo: {Titolo} \nAutore: {Autore} \nGenere: {Genere} \nAnno pubblicazione: {Anno_pubblicazione}\nPrezzo: {Prezzo()} euro\n-----------------------------\n";
        }

        public double Prezzo()
        {
            double ris = 1.5;

            switch (Genere.ToLower()) 
            {
                case "horror":
                    ris += 3;
                    break;
                case "romanzo":
                case "thriller":
                    ris += 4.5; 
                    break;
                case "fantasy":
                    ris += 3.9;
                    break;
                default:
                    ris += 10.5;
                    break;
            }

            if (Anno_pubblicazione < 1980)            
                ris += 2;           
            else if (Anno_pubblicazione < 2005)           
                ris += 1.5;            
            else if (Anno_pubblicazione <= DateTime.Now.Year)
                ris += 0.5;
            
            else
            
                ris = 0;
            
            return ris;
        }
    }
}