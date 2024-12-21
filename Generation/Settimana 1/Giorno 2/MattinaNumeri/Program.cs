// Gli apici "" permettono al programma di identificare il contenuto in essi come testo 
Console.WriteLine("2+2");
// Se eseguo il comando di riga 2 in console mi aspetto 2+2 perchè il contenuto è testo

// Nel comando di riga 6 ho inserito un valore numerico tra le () senza apici, il programma quindi lo riconosce come numero e non come testo
Console.WriteLine(2);

// Il programma riconosce il 2 come numero, il + come un'operatore matematico e l'altro 2 sempre come un numero
// Visto che è possibile eseguire una somma tra due numeri, svolge l'istruzione richiesta
Console.WriteLine(2+2); // il risultato sarà 4

// Il programma riconosce 2 e 6 come numeri e * come operatore matematico
Console.WriteLine(2*6); // il risultato sarà 12
Console.WriteLine(6/2); // il risultato sarà 3
// il programma riconosce tutti i numeri dal 0 al 9 come numeri affinchè vengano scritti senza apici ""  
// il programma riconosce tutti gli operatori matematici quando scritti anche loro senza apici ""
// gli operatori matematici sono + come addizione , - sottrazione , * moltiplicazione, / divisione

// Possiamo sommare pure un testo "2" con un numero
// Ma non è possibile sommare matematicamente un testo con un numero, quindi al testo che è 2 viene concatenato il numero
Console.WriteLine("2" + 2);   // il risultato sarà 22
Console.WriteLine("a" + 2);   // il risultato sarà a2
Console.WriteLine("a" + "a"); // il risultato sarà aa
Console.WriteLine("2" + (2+2)); // il risultato sarà 24 

int numero = 22; // variabile di tipo intero
string nome = "Mario"; // variabile di tipo stringa

Console.WriteLine(nome + " ha " + numero + " anni" ); // il risultato sarà Mario ha 22 anni




