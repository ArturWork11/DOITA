using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCrud
{
    internal class Libro : Entity
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public int Anno_pubblicazione { get; set; }
        public Libro() { }

        public Libro(string titolo, string autore, string genere, int anno_pubblicazione)
        {
            Titolo=titolo;
            Autore=autore;
            Genere=genere;
            Anno_pubblicazione=anno_pubblicazione;
        }

        public override string ToString()
        {
            return base.ToString() + $"Titolo: {Titolo} \nAutore: {Autore} \nGenere: {Genere} \nPubblicazione: {Anno_pubblicazione}\n-------------------------\n";
        }
    }
}
