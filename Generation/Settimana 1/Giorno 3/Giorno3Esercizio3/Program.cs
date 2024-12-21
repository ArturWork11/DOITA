

/* creare un programma che chieda all'utente di inserire il proprio
         * user, se è corretto(comparo il valore che mi passa l'utente con un 
         * valore di confronto, ricorda il case) 
         * allora potrete chiedere di inserire anche la password 
         * A questo punto controllare anche il valore della password
         * fornite all'utente dei feedback in ogni step così che possa
         * capire se andare avanti o ritentare  
         * 
         */

string User, password;
Console.WriteLine("inserisci il nome utente");
User = Console.ReadLine();

if (User == "Utente")
{
    Console.WriteLine("Inserisci la password");
    password = Console.ReadLine();
    if (password == "password")
    {
        Console.WriteLine("Benvenuto nel tuo portale");
    }
    else
    {
        Console.WriteLine("Password Sbagliata ritenta");
    }
}
else
{
    Console.WriteLine("User Sbagliato ritenta");
}