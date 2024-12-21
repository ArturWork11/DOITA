/* Creare un programma che calcoli l'area di una figura scelta da un utente tra le seguenti (quadrato/rettangolo/triangolo)

DICO -> dichiarazione, inizializzazione, calcolo e output
.preparare le variabili necessarie e dichiararle
.inizializzazione, per farlo devo chiedere ad un utente quale figura ha scelto
.successivamente fargli inserire i valori necessari per il calcolo dell'area 
.calcolare l'area
.restituire output
*/

string RispostaFigura, RispostaBase, RispostaAlt;
double Base, Altezza;
double Area = 0;
Console.WriteLine("Scegli una figura tra quadrato,rettangolo o triangolo");
RispostaFigura = Console.ReadLine();

if (RispostaFigura.ToLower() == "quadrato" )
{
    Console.WriteLine("inserisci la misura del lato del quadrato");
    RispostaBase = Console.ReadLine();
    Base = double.Parse(RispostaBase);
    Area= Base * Base;
}
if (RispostaFigura == "rettangolo")
{
    Console.WriteLine("inserisci la misura della base del rettagolo");
    RispostaBase = Console.ReadLine();
    Base = double.Parse(RispostaBase);
    Console.WriteLine("inserisci la misura dell'altezza del rettangolo");
    RispostaAlt = Console.ReadLine();
    Altezza = double.Parse(RispostaAlt);
    Area= Base * Altezza;
}
if (RispostaFigura == "triangolo")
{
    Console.WriteLine("inserisci la misura della base del triangolo");
    RispostaBase = Console.ReadLine();
    Base = double.Parse(RispostaBase);
    Console.WriteLine("inserisci la misura dell'altezza del triangolo");
    RispostaAlt = Console.ReadLine();
    Altezza = double.Parse(RispostaAlt);
    Area= (Base * Altezza) / 2;
}

Console.WriteLine("L'Area del " + RispostaFigura + " è " + Area);
