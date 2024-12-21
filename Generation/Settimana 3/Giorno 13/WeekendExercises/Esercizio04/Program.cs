//Esercizio04_Iterazione
// Scrivere un programma che permetta all'utente di inserire una serie di numeri positivi.
// Quando viene digitato 0 o un numero negativo interrompere il programma e stampare in console:
// - somma complessiva
// - numero maggiore inserito
// - numero minore inserito
// - somma dei numeri pari
// - media dei numeri multipli di 3

double digit = 1;
double total = 0;
double maxNum = 0;
double minNum = double.MaxValue;
double averageThreeMultiple = 0;
double threeMultiple = 0;

Console.WriteLine("Welcome! Insert as many number as you want - Insert 0 or a negative number to stop the program");

do
{
    digit = double.Parse(Console.ReadLine());

    if (digit > 0)
    {
    total += digit;

    Console.WriteLine("Insert another number or digit 0 to stop the program");
        if(digit > maxNum)
        {
            maxNum = digit;
        }
        
        if(digit < minNum)
        {
            minNum = digit;
        }
        if (digit % 3 == 0)
        {
            threeMultiple++;
            averageThreeMultiple += digit;
        }
        

    }


} while (digit > 0 );

averageThreeMultiple = averageThreeMultiple / threeMultiple;
Console.WriteLine($"The sum of the number is {total} \nThe bigger number is {maxNum} \nThe smallest number is {minNum} \nThe average of the three multiple is {averageThreeMultiple}");