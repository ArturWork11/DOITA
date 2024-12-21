/* 4. Esercizio: Vacanze ===========================================
    Creare un programma che calcoli il prezzo dei biglietti dell'aereo 
        in base all'input dell'utente

    Chiedere:
        1) Quante persone andranno in vacanza.
        2) Quante persone minori di 14 anni
            (Segnalare errore in caso risulti essere maggiore del totale delle persone)
        3) La destinazione
        4) Il mese di partenza

    Il prezzo base cambia a seconda della destinazione:
        europa: 300 €
        africa: 500 €
        asia: 600 €
        america: 700 €
        altro: 800 €

    a seconda del mese di partenza c'è un moltiplicatore diverso al prezzo base:
    dicembre-gennaio-febbraio:
    
1.2
  marzo-aprile-maggio:
1.5
altro:
1.8

I "bambini" pagano la metà:

Stampare il costo del prezzo di una singola persona.

Stampare il prezzo che pagherà l'intero gruppo */

double PrezzoEuropa = 300, PrezzoAfrica = 500, PrezzoAsia = 600, PrezzoAmerica = 700, PrezzoAltro = 800, Gruppo, Minori, PrezzoMinore, Prezzo, PrezzoGruppo, Adulti;
string RispostaGruppo, RispostaMinori, Destinazione, Mese;

Console.WriteLine("Quante persone andranno in vacanza?");
RispostaGruppo = Console.ReadLine();
Gruppo = double.Parse(RispostaGruppo);
Console.WriteLine("Quante minori fanno parte del gruppo vacanza?");
RispostaMinori = Console.ReadLine();
Minori = double.Parse(RispostaMinori);
if (Minori < Gruppo)
{
    Console.WriteLine("Qual'è la destinazione del vostro viaggio?");
    Destinazione = Console.ReadLine();
    Console.WriteLine("In che mese desiderate partire?");
    Mese = Console.ReadLine();
    if (Destinazione.ToLower() == "europa")
    {
        Prezzo = PrezzoEuropa;
    }
    else
    {
        if (Destinazione.ToLower() == "africa")
        {
            Prezzo = PrezzoAfrica;
        }
        else
        {

            if (Destinazione.ToLower() == "asia")
            {
                Prezzo = PrezzoAsia;
            }
            else
            {
                if (Destinazione.ToLower() == "america")
                {
                    Prezzo = PrezzoAmerica;
                }
                else
                {
                    Prezzo = PrezzoAltro;
                }
            }
        }
    }
    if (Mese.ToLower() == "dicembre" || Mese.ToLower() == "febbraio" ||  Mese.ToLower() == "gennaio")
    {
        Prezzo = Prezzo * 1.2;
    }
    else
    {
        if (Mese.ToLower() == "marzo" || Mese.ToLower() == "aprile" ||  Mese.ToLower() == "maggio")
        {
            Prezzo = Prezzo * 1.5;
        }
        else
        {
            Prezzo = Prezzo * 1.8;
        }
  
    }
    Console.WriteLine("Il prezzo singolo di un'adulto è " + Prezzo);
    PrezzoMinore = Prezzo / 2;
    Console.WriteLine("Il prezzo singolo di un minore è " + PrezzoMinore);
    Adulti = Gruppo - Minori;
    PrezzoGruppo = (Adulti * Prezzo) + (Minori * PrezzoMinore);
    Console.WriteLine("Il prezzo singolo totale del gruppo è " + PrezzoGruppo);

}
else
{
    Console.WriteLine("i minori non possono essere più del gruppo");
}
