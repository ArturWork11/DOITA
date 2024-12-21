
/*Fare inserire ad un utente una serie di parole
 * salvare ogni parola in una cella di un array
 * stampare:
 * - la parola più lunga parola.Length
 * - la parola più corta
 * - le parole che iniziano con la c -> parola.StartWith(lettera) , parola p[0], a[1]..... -> 'A' -> parole[i][0]
 * - le parole palindrome
 * - scorrere tutto l'array e saltare una parola a scelta
 */



// SINTASSI FOR:
/* 
 
for(INIZIALIZZAZIONE; CONDIZIONE; AGGIORNAMENTO)
{
    CODICE
}
*/

// LA CONDIZIONE DEL FOR ESATTAMENTE COME NEL WHILE E NEL DO-WHILE INDICA QUANDO BISOGNA RIPETERE IL CODICE, SE LA CONDIZIONE
// RISULTA VERA (TRUE) ALLORA IL CICLO RIPARTE ALTRIMENTI SI INTERROMPE



int n;
Console.WriteLine("Quante parole vuoi inserire?");
n= int.Parse(Console.ReadLine());
string[] nomi = new string[n];



for (int i = 0;i < nomi.Length; i++)
{
    Console.WriteLine($"Inserisci la parola {i}");
    nomi[i] = Console.ReadLine();
}

for (int i = 0; i < nomi.Length; i++)
{
    bool isPalindroma = true;
    string frase = nomi[i].Replace(" ","");
    for (int j = 0, k = frase.Length-1; j < frase.Length/2 && k >= frase.Length/2;j++ , k--)
    {
        if (frase[j] != frase[k])
        {
            isPalindroma = false;
            break;
        }
        if (isPalindroma)
        {
            Console.WriteLine($"La parola {nomi[i]} è palindroma");
        }
    }
}