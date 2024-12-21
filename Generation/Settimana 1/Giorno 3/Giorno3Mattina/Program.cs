// Ripasso esercizio c.i. Giorno2
// creare tre c.i. di tre utenti inserendo nome,cognome,età ,paese di residenza e altezza
// calcolare la media delle tre età

// utilizzo un'approccio diverso per affrontare l'esercizio
// dichiaro tutte le variabili di ciascun tipo su una sola riga 
string NomeUtente1, CognomeUtente1, RispostaEta1, Paese1, RispostaAltezza1, NomeUtente2, CognomeUtente2, RispostaEta2, Paese2, RispostaAltezza2, NomeUtente3, CognomeUtente3, RispostaEta3, Paese3, RispostaAltezza3;
double EtaUtente1, AltezzaUtente1, EtaUtente2, AltezzaUtente2, EtaUtente3, AltezzaUtente3;


//  Richiedo il nome ad utente1, lo saluto e acquisisco tutti i suoi dati
Console.WriteLine("Buongiorno come ti chiami?");
NomeUtente1 = Console.ReadLine();

Console.WriteLine("Benvenuto " + NomeUtente1 + ", procediamo con la creazione della tua c.i.");

Console.WriteLine("Inserisci il tuo cognome");
CognomeUtente1 = Console.ReadLine();

Console.WriteLine("Inserisci la tua età");
RispostaEta1 = Console.ReadLine();
EtaUtente1 = double.Parse(RispostaEta1);

Console.WriteLine("Inserisci il tuo Paese di residenza");
Paese1 = Console.ReadLine();

Console.WriteLine("Inserisci la tua altezza in metri");
RispostaAltezza1 = Console.ReadLine();
AltezzaUtente1 = double.Parse(RispostaAltezza1);

// Scrivo in console tutti i dati della c.i. del primo utente 

Console.WriteLine("\n Ecco i Dati della carta d'identità di " + NomeUtente1 + " " + CognomeUtente1 + "\n Nome: " + NomeUtente1 + "\n Cognome: " + CognomeUtente1 + "\n Età: " + EtaUtente1 + "\n Paese di residenza : " + Paese1 + "\n Altezza " + AltezzaUtente1 + "m");

// Faccio gli stessi passagi da Riga 11 usando le variabili create per il secondo utente(Utente2) per creare la c.i. del secondo utente

Console.WriteLine("\n Buongiorno come ti chiami?");
NomeUtente2 = Console.ReadLine();

Console.WriteLine("Benvenuto " + NomeUtente2 + ", procediamo con la creazione della tua c.i.");

Console.WriteLine("Inserisci il tuo cognome");
CognomeUtente2 = Console.ReadLine();

Console.WriteLine("Inserisci la tua età");
RispostaEta2 = Console.ReadLine();
EtaUtente2 = double.Parse(RispostaEta2);

Console.WriteLine("Inserisci il tuo Paese di residenza");
Paese2 = Console.ReadLine();

Console.WriteLine("Inserisci la tua altezza in metri");
RispostaAltezza2 = Console.ReadLine();
AltezzaUtente2 = double.Parse(RispostaAltezza2);

// Scrivo in console tutti i dati della c.i. del secondo utente 

Console.WriteLine("\n Ecco i Dati della carta d'identità di " + NomeUtente2 + " " + CognomeUtente2 + "\n Nome: " + NomeUtente2 + "\n Cognome: " + CognomeUtente2 + "\n Età: " + EtaUtente2 + "\n Paese di residenza : " + Paese2 + "\n Altezza " + AltezzaUtente2 + "m");

Console.WriteLine("\n Buongiorno come ti chiami?");
NomeUtente3 = Console.ReadLine();

Console.WriteLine("Benvenuto " + NomeUtente3 + ", procediamo con la creazione della tua c.i.");

Console.WriteLine("Inserisci il tuo cognome");
CognomeUtente3 = Console.ReadLine();

Console.WriteLine("Inserisci la tua età");
RispostaEta3 = Console.ReadLine();
EtaUtente3 = double.Parse(RispostaEta3);

Console.WriteLine("Inserisci il tuo Paese di residenza");
Paese3 = Console.ReadLine();

Console.WriteLine("Inserisci la tua altezza in metri");
RispostaAltezza3 = Console.ReadLine();
AltezzaUtente3 = double.Parse(RispostaAltezza3);

// Scrivo in console tutti i dati della c.i. del primo utente 

Console.WriteLine("\n Ecco i Dati della carta d'identità di " + NomeUtente3 + " " + CognomeUtente3 + "\n Nome: " + NomeUtente3 + "\n Cognome: " + CognomeUtente3 + "\n Età: " + EtaUtente3 + "\n Paese di residenza : " + Paese3 + "\n Altezza " + AltezzaUtente3 + "m");

// acquisisco il valore della media dell'eta e dell'altezza degli utenti
double MediaEta = (EtaUtente1 + EtaUtente2 + EtaUtente3) / 3;
double MediaAltezza = (AltezzaUtente1 + AltezzaUtente2 + AltezzaUtente3) / 3;

// Scrivo in console la media dell'età e dell'altezza dei 3 utenti
Console.WriteLine("La media dell'età dei 3 utenti è: " + MediaEta + "\n La media dell'altezza dei 3 utenti è: " + MediaAltezza);
Console.WriteLine("Buona Giornata");
