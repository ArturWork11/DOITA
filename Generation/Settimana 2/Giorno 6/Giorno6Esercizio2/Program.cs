/* creare un programma che chieda all'utente di inserire il proprio
         
user, se è corretto(comparo il valore che mi passa l'utente con un 
valore di confronto, ricorda il case) 
allora potrete chiedere di inserire anche la password 
A questo punto controllare anche il valore della password
fornite all'utente dei feedback in ogni step così che possa
capire se andare avanti o ritentare.
Dare la possibilità all'utente di ritentare al massimo tre volte
se nemmeno la terza volta dovesse inserire lo user corretto terminare il programma */

using System.ComponentModel.Design;

string User = "", Password = "";
int Tentativi = 3, TentativiPass = 3;

Console.WriteLine("Benvenuto inserisci il tuo Username");
while (Tentativi !=0)
{
    User = Console.ReadLine();
    if (User == "Artuz")
    {
        Console.WriteLine("Ben tornato " + User + " inserisci la tua password");
        Tentativi=0;
    }
    else
    {
        Tentativi--;
        Console.WriteLine("Username errato, ti rimangono " + Tentativi + " tentativi");
        if (Tentativi != 0)
        {
            Console.WriteLine("\nReinserisci l'username");
        }
        else
        {
            Console.WriteLine("Account bloccato");
        }
    }
}

while (TentativiPass !=0)
{
    Password = Console.ReadLine();
    if (Password == "Bombo")
    {
        Console.WriteLine("Puoi accedere al portale!!");
        TentativiPass = 0;
    }
    else
    {
        TentativiPass--;
        Console.WriteLine("Password errata, ti rimangono " + TentativiPass + " tentativi");
        if (TentativiPass != 0)
        {
            Console.WriteLine("\nReinserisci la password");
        }
        else
        {
            Console.WriteLine("Account bloccato");
        }
    }
}