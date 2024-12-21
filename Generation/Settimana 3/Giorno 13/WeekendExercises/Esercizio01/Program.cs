//Esercizio01_IF
//Scrivere un programma che, ricevuti in input tre numeri, stampi il più
//grande dei tre.

int min = 0;
Console.WriteLine("Inserisci 3 numeri e ti restituirò il più grande dei 3");
for (int i = 0; i < 3; i++)
{
    int numero = int.Parse(Console.ReadLine());
    if (numero > min)
    {
        min = numero;
    }
}
Console.WriteLine("Il numero più grande tra quelli inseriti è " +  min);


//senza FOR
int numero1 = 0;
int numero2 = 0;
int numero3 = 0;
int maxNum  = 0;
Console.WriteLine("\nInserisci 3 numeri e ti restituirò il più grande dei 3");
numero1 = int.Parse(Console.ReadLine());
numero2 = int.Parse(Console.ReadLine());
numero3 = int.Parse(Console.ReadLine());

if (numero1 > numero2)
{
    if (numero1 > numero3)
    {
        maxNum = numero1;
    }
    else
    {
        maxNum = numero3;
    }
}
else if (numero2 > numero3)
{
    maxNum = numero2;
}
else 
{ 
    maxNum = numero3;
}

Console.WriteLine("Il numero più grande tra quelli inseriti è " +  maxNum);
