/* -chiedere ad un utente di inserire un numero intero il cui valore massimo è 10
 creare un programma che effettui un conto alla rovescia fino a 0 partendo dal numero dato dall'utente
se il numero inserito è corretto in base al criterio del valore massimo
stampare ad ogni iterazione un feedback sul valore corrente */

double NumUtente, Conto=-1, ValoreMax = 10;

Console.WriteLine("inserisci un numero intero il cui valore massimo è 10");
NumUtente = double.Parse(Console.ReadLine());
while (Conto != 0)
{
   
    if (NumUtente < ValoreMax)
    {
        Conto = NumUtente--;
        Console.WriteLine("la conta è " + Conto);

    }
    else
    {
        Console.WriteLine("il numero inserito non è corretto");
        Conto = 0;
    }
}