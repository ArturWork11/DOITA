
//Creare una carta d'identità di due persone
//inserire nome, cognome, età , paese di residenza , altezza
// opzionale, aggiungere una terza persona e fare la media delle loro età

// prima C.I.
string nome1 = "";
string cognome1 = "";
string RispostaEta1 = "";
string Paese1 = "";
string RispostaAltezza1 = "";
int eta1 = 0;
double altezza1 = 0;
Console.WriteLine("inserisci il nome del primo utente");
nome1 = Console.ReadLine();
Console.WriteLine("inserisci il cognome del primo utente");
cognome1 = Console.ReadLine();
Console.WriteLine("inserisci l'età del primo utente");
RispostaEta1 = Console.ReadLine();
eta1 = int.Parse(RispostaEta1);
Console.WriteLine("inserisci il paese di residenza del primo utente");
Paese1 = Console.ReadLine();
Console.WriteLine("inserisci l'altezza del primo utente \n");
RispostaAltezza1 =  Console.ReadLine();
altezza1 = double.Parse(RispostaAltezza1);
Console.WriteLine("i dati della carta d'identa del primo utente sono: \n Nome: " + nome1 + "\n Cognome: " + cognome1 + "\n età: " + eta1 + "\n Paese di redidenza: " + Paese1 + "\n Altezza: " + altezza1 + "m \n");

// seconda C.I.
string nome2 = "";
string cognome2 = "";
string RispostaEta2 = "";
string Paese2 = "";
string RispostaAltezza2 = "";
int eta2 = 0;
double altezza2 = 0;
Console.WriteLine("inserisci il nome del secondo utente");
nome2= Console.ReadLine();
Console.WriteLine("inserisci il cognome del secondo utente");
cognome2 = Console.ReadLine();
Console.WriteLine("inserisci l'età del secondo utente");
RispostaEta2 = Console.ReadLine();
eta2 = int.Parse(RispostaEta2);
Console.WriteLine("inserisci il paese di residenza del secondo utente");
Paese2 = Console.ReadLine();
Console.WriteLine("inserisci l'altezza del secondo utente");
RispostaAltezza2 =  Console.ReadLine();
altezza2 = double.Parse(RispostaAltezza2);
Console.WriteLine("i dati della carta d'identa del secondo utente \n" + "Nome: " + nome2 + "\n Cognome: " + cognome2 + "\n età: " + eta2 + "\n Paese di redidenza: " + Paese2 + "\n Altezza: " + altezza2 + "m \n");

// terza C.I.

string nome3 = "";
string cognome3 = "";
string RispostaEta3 = "";
string Paese3 = "";
string RispostaAltezza3 = "";
int eta3 = 0;
double altezza3 = 0;
Console.WriteLine("inserisci il nome del terzo utente");
nome3 = Console.ReadLine();
Console.WriteLine("inserisci il cognome del terzo utente");
cognome3 = Console.ReadLine();
Console.WriteLine("inserisci l'età del terzo utente");
RispostaEta3 = Console.ReadLine();
eta3 = int.Parse(RispostaEta3);
Console.WriteLine("inserisci il paese di residenza del terzo utente");
Paese3 = Console.ReadLine();
Console.WriteLine("inserisci l'altezza del terzo utente");
RispostaAltezza3 =  Console.ReadLine();
altezza3 = double.Parse(RispostaAltezza3);
Console.WriteLine("i dati della carta d'identa del terzo utente \n" +  "Nome: " + nome3 + "\n Cognome: " + cognome3 + "\n età: " + eta3 + "\n Paese di redidenza: " + Paese3 + "\n Altezza: " + altezza3 + "m \n");

// media dell'età degli utenti

double media = (eta1 + eta2 + eta3) / 3;
Console.WriteLine("la media dell'eta degli utenti è: " + media);
