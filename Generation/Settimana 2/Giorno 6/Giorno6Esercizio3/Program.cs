/* `Scrivere un programma che permette all'utente di calcolare l'area e il prezzo di una casa:
il prezzo al metro quadro è di 300 euro/m2

il programma chiede all'utente quante stanze ha la casa, dopodiché PER OGNI stanza il programma chiede la forma,
il programma calcola l'area infine calcola l'area totale della casa, stampando un resoconto che riassume tutto.

BONUS
stampare nella scheda finale anche la media dell'area di ogni stanza.
` */

using System.Linq.Expressions;

int PrezzoMetroQ = 300, stanze,Area=0,Prezzo,Base,Altezza;
string FormaStanze;

Console.WriteLine("Calcolerò l'area di ogni tua stanza e il prezzo di casa tua, valutandola 300 euro al metro quadro");
Console.WriteLine("Quante stanze ha?");
stanze=int.Parse(Console.ReadLine());
while (stanze!=0)
{
    Console.WriteLine("Che forma ha la stanza " + stanze + "?");
    FormaStanze = Console.ReadLine();
    stanze--;
    switch (FormaStanze)
    {
        case "rettangolo":
            Console.WriteLine("Qual'è il lato corto della stanza?");
            Base = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual'è il lato lungo della stanza?");
            Altezza = int.Parse(Console.ReadLine());
            Area += Base * Altezza;
            break;
        case "quadrato":
            Console.WriteLine("Quanto misura un lato della stanza?");
            Base = int.Parse(Console.ReadLine());
            Area += Base * Base;
            break;
    }
}
Prezzo = Area  * PrezzoMetroQ;
double MediaS = Area / stanze;
Console.WriteLine("il prezzo di casa tua è " + Prezzo);
Console.WriteLine("la media dell'area delle stanze è " + MediaS);