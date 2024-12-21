/* Selezione 
bool = true or false
una variabile booleana permette solo due valori , vero (true) o falso (false)


// per convenzione si setta come falsa finchè non succede qualcosa che la faccia diventare vera 
// se fuori è freddo il programma stamperà in console "prendi la giacca" 
// altrimenti stamperà "non ti preoccupare!"
*/
bool freddo = false;
string RispostaGradi, RispostaEta, RispostaNumero;
double gradi = 0;
int eta;
double numero1;
double numero2 = 2;

Console.WriteLine("\n Quanti gradi ci sono fuori?");
RispostaGradi = Console.ReadLine();
gradi = double.Parse(RispostaGradi);

if (gradi >= 16)
{
    Console.WriteLine("non ti preoccupare!");
}
else
{
    Console.WriteLine("prendi la giacca");
}

string RispostaVoF;
Console.WriteLine("\n Se fuori fa freddo inserisci V (o T)  altrimenti inserisci F");
RispostaVoF = Console.ReadLine();

if (RispostaVoF.ToLower() == "v" || RispostaVoF.ToLower() == "t") //ToLower() modifica il contenuto di una stringa e lo rende tutto minuscolo
{
    freddo = true;
}
else
{
    freddo = false;
}

if (freddo == false)
{
    Console.WriteLine("non ti preoccupare!");
}
else
{
    Console.WriteLine("prendi la giacca");
}

Console.WriteLine("\n Quanti anni hai?");
RispostaEta = Console.ReadLine();
eta = int.Parse(RispostaEta);

if  (eta <= 18)
{
    Console.WriteLine("Sei Minorenne, non puoi bere");
}
else
{
    Console.WriteLine("Sei Maggiorenne complimenti, ubriacati pure");
}


Console.WriteLine("scrivimi un numero e ti dirò se è pari o dipari");
RispostaNumero = Console.ReadLine();
numero1 = double.Parse(RispostaNumero);

if (numero1%2 == 1)
{
    Console.WriteLine("il numero è dispari");
}
else
{
    Console.WriteLine("Il numero è pari");
}

// && -> AND è usato con due o più condizioni, ritorna true se ENTRAMBE sono vere (ad esempio quando devo verificare che un valore sia all'interno di un range)  