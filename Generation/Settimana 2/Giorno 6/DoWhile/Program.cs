/* 
  do{
    blocco di codice
}while(condizione);

il do-while ripete un blocco di codice finchè la condizione posta alla FINE dell'istruzione è vera 
--> significa che la condizione viene controllata DOPO aver letto ed eseguito il blocco di codice.
Quindi il do-while permette di iterare da 1 a N volte
 */

int PinValido = 1234;
int PinUtente;
int NumTentativi = 3;
bool continua = false;

do
{
    Console.WriteLine("Qual'è il tuo pin?");
    PinUtente=int.Parse(Console.ReadLine());
    continua = (PinUtente==PinValido) ? false : true;
    NumTentativi--;
    if (continua)
    {
        Console.WriteLine("Ti rimangono " + NumTentativi +  " tentativi");
    }
    else
    {
        Console.WriteLine("Pin Correto! Benvenuto");
    }
} while (continua && NumTentativi>0);

// facciamo un conto alla rovescia, quando il conto arriva a metà del valore di partenza stoppare il programma


int valoreInizio = -1, stop;

Console.WriteLine("\nDa dove deve partire il countdown?");
valoreInizio= int.Parse(Console.ReadLine());
Console.WriteLine("e dove deve fermarsi?");
stop = int.Parse(Console.ReadLine());

while (valoreInizio!=0)
{
    Console.WriteLine(valoreInizio);
    if (valoreInizio==stop)
    {
        break;
    }
    valoreInizio--;
}

// 

int ValoreUtente;

Console.WriteLine("\nDa dove deve partire il countdown? Salterò tutti i numeri dispari");
ValoreUtente= int.Parse(Console.ReadLine());

while (ValoreUtente!=0)
{

    ValoreUtente--;
    if (ValoreUtente%2==1 || ValoreUtente==0)
    {
        continue;
    }
    Console.WriteLine(ValoreUtente);

}
