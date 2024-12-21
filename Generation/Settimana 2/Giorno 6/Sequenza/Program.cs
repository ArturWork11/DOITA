// PRINCIPI PROGRAMMAZIONE GENERICA:
// -1: SEQUENZA , IL CODICE VIENE ESEGUITO DALL'ALTO VERSO IL BASSO
// -2: SELEZIONE che usa i SELETTORI: permette di cambiare strategia/azione a seconda del verificarsi di una condizione (if, if-else,if-else-if,ternario,switch)
// -3: ITERAZIONE che usa gli ITERATORI: permette di ripetere lo stesso blocco di codice per un numero determinato o incognito di volte

//WHILE: ripete un blocco di codice SE e FINCHè  la condizione di partenza risulta VERA

/*while(condizione){
    blocco di codice con l'istruzione/i da eseguire N volte
}
 */

// chiedere ad un utente di inserire il suo user, far ripetere l'inserimento finchè lo user non è corretto

string UserCorretto = "Artuz11", UserUtente = "", output = "";
bool ripeti=false;

//  nel while la condizione viene controllata prima di eseguire il blocco di codice -->
// quindi se la condizione è vera legge ed esegui le istruzione e poi ricontrolla la condizione se è vera si ripete il blocco, se è falsa si blocca
// se la condizione è in partenza falsa, le istruzioni del blocco di codice non vengono mai lette ed eseguite
// per questo si dice che il while itera da 0 a N volte(volendo infinite)

while (ripeti == false) 
{   
    // chiedo all'utente di inserire l'username
    Console.WriteLine("\n inserisci il tuo user");
    UserUtente = Console.ReadLine();
    if (UserUtente == UserCorretto)
    {
        output = "Benvenuto " + UserUtente + "\n";
        ripeti = true;
    }
    else
    {
        output = "User errato riprova";
    }
    Console.WriteLine(output);
}

// chiediamo all'utente di inserire dei numeri , l'inserimento andrà avanti finchè l'utente non digita 0, quando digita 0 significa che l'iterazione si ferma
// stampare in console la somma dei numeri inseriti

int NumeroUtente = -1;
int somma = 0;
bool inserimento = false;

while(NumeroUtente != 0)
{
    Console.WriteLine("inserisci un numero intero, digita 0 per fermarti");
    NumeroUtente = int.Parse(Console.ReadLine());
    if (NumeroUtente != 0)
    {
        inserimento = true;
        somma += NumeroUtente;
    }
}

output = (inserimento) ? "la somma dei valori inseriti è " + somma : "Non hai inserito alcun numero";
Console.WriteLine(output);