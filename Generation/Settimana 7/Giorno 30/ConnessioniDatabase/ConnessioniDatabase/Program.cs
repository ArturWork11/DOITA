
using ConnessioniDatabase;

string digit = "";
string autore = "";
Libreria l = new Libreria();



do
{
    Console.WriteLine("Benvenuto nella libreria di GENEREATION \nDIGITA: \n1. Per visualizzare tutti i nostri libri \n2. Per visualizzare tutti i libri pubblicati dal 2000 in poi \n3. Per visualizzare tutti i libri di un'autore a tua scelta \n0. Per uscire dal programma");
    digit = Console.ReadLine();
    switch (digit)
    {
        case "1":
        Console.WriteLine(l.Lista());
        break;
        case "2":
        Console.WriteLine(l.LibriDal2000());
        break;
        case "3":
        Console.WriteLine("Di quale autore vuoi vedere i libri?");
        autore = Console.ReadLine();
        Console.WriteLine(l.LibriAutoreUser(autore));
        break;
        case "0":
        Console.WriteLine("Grazie e arrivederci");
        break;
        default:
        break;
    }

} while (digit != "0");




