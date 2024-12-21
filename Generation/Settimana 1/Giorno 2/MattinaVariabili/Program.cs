// Creo un contenitore, detto variabile, a cui appongo un'etichetta cioè un nome
// usiamo int per i numeri interi sia positivi che negativi
// CamelCase si dice quando uso le maiuscole per separare due parole senza usare lo spazio
int NumeroIntero = 22;
// string lo usiamo per le stringhe di testo
string TestoLungo = "Questo testo si ripete a lungo e va riutilizzato, per non riscriverlo ogni volta usiamo una variabile";

// restituirà la stringa di testo inserita in string testolungo
Console.WriteLine(TestoLungo);

// variabile che puo contenere numeri decimali sia positivi che negativi
// Compreso tra +-5.0 x 10-324 to +-1.7 x 10308
double NumeroDecimale = 1.22;

// darà come risultato 20,78
Console.WriteLine(NumeroIntero - NumeroDecimale);

// usiamo Float per indicare un range compreso tra +-1.5 x10-45 e +-3.4 x 1038
float numDecimale = 12.8F; 

// usiamo Long per numeri a 64bit , può contenere numeri più estesi rispetto int
long NumeroL = 2L;

// si usa per indicare un singolo carattere
// attenzione non vanno bene le virgolette "" ma vanno usati gli apici ''
char carattere = 'A';

// variabile che preparo per salvare la risposta dell'utente, ad ora non so quale sia
string Risposta = "";
int eta = 0;

// chiedere ad un utente tramite messaggio in console di inserire l'età
Console.WriteLine("inserisci la tua età");

// questo comando mi permette di leggere il valore che qualcuno scrive in console
// salvo cio che l'utente scrive nella variabile risposta
Risposta = Console.ReadLine();

//trasforma il contenuto della variabile risposta in un numero intero, è possibile fare quest'operazione solo se la risposta contiene effettivamente numeri 
eta = int.Parse(Risposta);

// stamperà "La tua età è" seguito dalla data inserita dal nostro utente
Console.WriteLine("La tua età è " + eta);

// altro esempio di come possa venir utilizzato il comando ReadLine e di come utilizzare il + per concatenare
string nome = "";
Console.WriteLine("inserisci il tuo nome");
nome = Console.ReadLine();
Console.WriteLine("il tuo nome è " +  nome + " e hai " + eta + " anni");