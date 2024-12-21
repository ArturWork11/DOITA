// quando devo ASSEGNARE o AGGIORNARE il valore di una variabile di una VARIABILE
// a seconda del verificarsi o meno di una condizione possiamo usare un selettore
// che ha la stessa funzione del if-else ma permette di scrivere il codice in un modo più contratto
// OPERATORE TERNARIO
// variabile = (condizione) ? valore da assegnare se la condizione è TRUE : valore da assegnare se la condizone è FALSE
int NumUtente;
string output;

Console.WriteLine("inserisci un numero");
NumUtente= int.Parse(Console.ReadLine());
output = ((NumUtente %2) ==0) ? "numero pari" : "numero dispari";
Console.WriteLine(output);

