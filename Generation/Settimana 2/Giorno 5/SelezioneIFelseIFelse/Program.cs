using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

Console.WriteLine("Inserisci la tua età");
double eta= double.Parse(Console.ReadLine());

if (eta == 18)
{
    
    Console.WriteLine("sei appena maggiorenne");
}
else if (eta >= 18)
{
    Console.WriteLine("sei maggiorenne");
}
else if (eta <= 0)
{
    Console.WriteLine("errore");
}
else
{
    Console.WriteLine("Sei minorenne");
}


if(eta >= 0 && eta <= 18)
{
    Console.WriteLine("sei molto giovane");
} 
else if(eta >18 && eta <=40)
{
    Console.WriteLine("Sei adulto");
}
else if(eta <0 || eta>70)
{
    Console.WriteLine("impossibile");
}
else if(eta < 0)
{
    Console.WriteLine("Ancora errore");
}
else
{
    Console.WriteLine("Sei anziano");
}

// switch-case
// Lo switch permette di valutare in base al valore della variabile presa in esame, dei casi specifici e ben definiti
// gli intervalli possono essere valutati utilizzando sintassi come 'case >18 or <70' ma è consigliabile non utilizzare lo switch
// per intervalli, in quel caso meglio if else if anche per leggibilità del codice
// si può 

string destinazione;
Console.WriteLine("dove partirete? Africa? Europa oppure Asia?");
destinazione = Console.ReadLine();
switch (destinazione)
{
    case "Europa":
        Console.WriteLine("Quale capitale Europea vuoi visitare tra Roma, Parigi o Berlino?");
        string Capitale = Console.ReadLine();
        switch (Capitale)
        {
            case "Roma":
                Console.WriteLine("Buon viaggio, Mamma mia!");
                break;
            case "Parigi":
                Console.WriteLine("Oui Oui, Bon voyage!");
                break;
            case "Berlino":
                Console.WriteLine("Ja! Gute Reise!");
                break;
        }
        break;
    case "Africa":
        Console.WriteLine("Quale capitale Africana vuoi visitare tra Cairo, Dakar o Cape Town?");
        Capitale = Console.ReadLine();
        switch (Capitale)
        {
            case "Cairo":
                Console.WriteLine("Saluti al Faraone!");
                break;
            case "Dakar":
                Console.WriteLine("Sei senegalese :O");
                break;
            case "Cape Town":
                Console.WriteLine("Wakandaaaa!!");
                break;
        }
        break;
    case "Asia":
        Console.WriteLine("Quale capitale Asiatica vuoi visitare tra Tokyo, Bangkok o Nuova Delhi?");
        Capitale = Console.ReadLine();
        switch (Capitale)
        {
            case "Tokyo":
                Console.WriteLine("Tokyo drifttt");
                break;
            case "Bangkok":
                Console.WriteLine("Lady boy tour eh mascalzone");
                break;
            case "Nuova Delhi":
                Console.WriteLine("Fatti dare le basi della programmazione da bimbi call centeristi di 14 anni");
                break;
        }
        break;
    default:
        Console.WriteLine("seleziona una destinazione tra quelle disponibili");
        break;
}