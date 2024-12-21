/* Fare inserire ad un utente una serie di parole
 * salvare ogni parola in una cella di un array
 * stampare
 * la parola più lunga  parola.lenght
 * la parola più corta
 * le parole che iniziano con la c --> parola.StartWith(lettera), parola p
 * le parole palindrome
 * scorrere tutto l'array e saltare una parola a scelta
 */

using System.ComponentModel.DataAnnotations;

string C = "", palindrome = "", parolaCorta, parolaLunga;
int index = 0;
int n=0;
string paroleCorte = "", paroleLunghe="";

Console.WriteLine("Quante parole vuoi inserire?");
n = int.Parse(Console.ReadLine());
string[] parole = new string[n];

Console.WriteLine("Inserisci delle parole e ti dirò la più lunga, la più corta, quelle palindrome e quelle che iniziano per c");
while (index != n)
{
    Console.WriteLine("inserisci la parola " +  (index + 1));
    parole[index] = Console.ReadLine();
    index++;
}

index = 0;
parolaLunga = parole[0];
while (index < n) 
{
    if (parole[index].Length > parolaLunga.Length)
    {
        parolaLunga = parole[index];
        paroleLunghe = parolaLunga;
    }
    else if (parole[index].Length == parolaLunga.Length && !paroleLunghe.Contains(parole[index]))
    {
        paroleLunghe += parole[index] + "\n";
    }
    index++;
}

Console.WriteLine("la parola più lunga è " + paroleLunghe);
index = 0;
parolaCorta = parole[0];
while (index < n)
{
    if (parole[index].Length < parolaCorta.Length)
    {
        parolaCorta = parole[index];
        paroleCorte = parolaCorta;
    }
    else if (parole[index].Length ==  parolaCorta.Length && !paroleCorte.Contains(parole[index]))
    {
        paroleCorte += parole[index] + "\n";
    }
    index++;
}
Console.WriteLine("la parola più corta è " + paroleCorte);

index = 0;
while (index < n)
{
    if (parole[index].ToLower().StartsWith("c"))
    {
        C +="\n" + parole[index] ;
    }
    index++;
}
Console.WriteLine("Le parole che iniziano per C sono: " +  C);



index = 0;
Console.WriteLine("Le parole che iniziano per C sono: " +  C);

// Altro modo di poter stampare le parole con prima lettera C 
// parole [i][0] --> [0] indica il primo carattere della parola "[i]"
// ToString si usa per indicizzarlo in stringa  
/*
index = 0;
string[]paroleContrario = new string[parole.Length];

while (index < n)
{
    if (parole[index][0].ToString.ToLower() =="c"
    {
         C +="\n" + parole[index] ;
    }
    
}
Console.WriteLine("Le parole che iniziano per C sono: " +  C); */

index=0;
string[] paroleContrario = new string[parole.Length];

while (index < n)
{
    int k = parole[index].Length - 1;
    paroleContrario[index][k] = parole[index][]
}