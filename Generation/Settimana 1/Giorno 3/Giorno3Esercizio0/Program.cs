/* 0.creare un programma che chieda ad un utente di inserire un numero e che fornisca come output 
   - "il numero è pari" se effettivamente il numero è pari
   - "il numero è dispari" se effettivamente il numero è dispari */

string RispostaNumero;
double numero1;

Console.WriteLine("scrivimi un numero e ti dirò se è pari o dipari");
RispostaNumero = Console.ReadLine();
numero1 = double.Parse(RispostaNumero);

if (numero1%2 == 1)
{
    Console.WriteLine("il numero " + numero1 + " è dispari");
}
else
{
    Console.WriteLine("Il numero " + numero1 + " è pari");
}
