/* 
 
Siete i direttori di un negozio che vende libri, cd e film.
Il vostro database si basa su un file che viene letto di volta in volta dal programma che
gestisce il negozio.
Create una classe per ogni tipologia di prodotto:
Entity: id
Prodotto: capite voi dai figli quali campi avrà
Libri: tipo,autore,titolo,genere,prezzo,nPagine,annoPubblicazione
Film: tipo,regista,titolo,genere,prezzo,durata,annoPubblicazione
Cd: tipo,artista,titolo,genere,prezzo,nTracce,annoPubblicazione
Scrivete per ogni classe dei metodi statici che controllino la validità
(Suggerimento: potete anche creare una classe apposta che abbia solo metodi statici di controllo)
Creare una classe aggregatore Negozio che conterrà un List con ogni prodotto
Creare la sua interfaccia
Nel Program creare un menu che dia all'utente le seguenti opzioni.
Se l'utente dovesse scegliere un'opzione non valida, fate in modo che possa scegliere
nuovamente fino a 3 volte.
Dopo la terza volta, stampate una frase di chiusura.
1 - Elenco completo
2 - Elenco dei libri
3 - Elenco dei film
4 - Elenco dei cd
5 - Elenco dei prodotti pubblicati dopo un determinato anno scelto dall'utente
6 - Media dei prezzi dei film di un determinato genere scelto dall'utente
7 - Somma dei prezzi dei cd di un determinato artista scelto dall'utente
8 - Somma dei prezzi dei Libri pubblicati dopo un anno scelto dall'utente
9 - Nome dell'artista che ha pubblicato il maggior numero di cd
10 - Nome del regista che ha prodotto il film più costoso tra tutti quelli venduti
11 - Nome dell'autore che ha scritto il libro più corto di un determinato genere scelto dall'utente
12 - Chiedere all'utente se vuole visualizzare altro.
Se risponde no, mandare un feedback per salutarlo, altrimenti ripetere tutto il processo. 
Per chi volesse proprio farsi del male aggiungere un metodo in negozio richiamato nel menù dell'utente che permetta di vedere l'elenco dei film ordinati per prezzo */

using EsercizioNegozio;
using Microsoft.VisualBasic;
using System.Runtime.Intrinsics.X86;

string digit = "";
string userChoice = "";
    string path = "../../../ProductData.txt";
IShop shop = new Shop(path);


Console.WriteLine("\nWelcome to my shop, select what you want see");
do
{

    Console.WriteLine("\nMenu: \n1. A list of all the products \n2. A list of all the books \n3. A list of all the Cds \n4. A list of all the film \n5. A list of all the film published after a year of your choice \n6. The average price of film of a genre choice of your choice \n7. The sum of price of cds of an artist of your choice \n8. The sum of the price of all the books published after a year of your choice \n9. The name of the artist that published the major number of cds \n10. The name of the director that film sell the most \n11. The author that wrote the shortest book of a genre of your choice \n  ");
    digit = Console.ReadLine();
    switch (digit)
    {
        case "1":
            foreach (var product in shop.FullList())
            {
                Console.WriteLine(product);
            }
            break;
        case "2":
            Console.WriteLine(shop.PrintList(shop.FullList()));
            break;
        case "3":
            Console.WriteLine(shop.CdList());
            break;
        case "4":
            Console.WriteLine(shop.FilmList());
            break;
        case "5":
            Console.WriteLine("Please digit a year");
            userChoice = Console.ReadLine();
            Console.WriteLine(shop.ProductAfterUserYears(userChoice.ToLower()));
            break;
        case "6":
            Console.WriteLine("Please digit a genre");
            userChoice = Console.ReadLine();
            Console.WriteLine(shop.AverageFilmPriceGenre(userChoice.ToLower()));
            break;
        case "7":
            Console.WriteLine("Please digit an Artist");
            userChoice = Console.ReadLine();
            Console.WriteLine(shop.SumPriceCdArtist(userChoice.ToLower()));
            break;
        case "8":
            Console.WriteLine("Please digit a year");
            userChoice = Console.ReadLine();
            Console.WriteLine(shop.SumPriceBookAfterUserYears(userChoice.ToLower()));
            break;
        case "9":
            Console.WriteLine(shop.ArtistWithMostCD());
            break;
        case "10":
            Console.WriteLine(shop.DirectorFilmMostExpensive());
            break;
        case "11":
            Console.WriteLine("Please digit a genre");
            userChoice = Console.ReadLine();
            Console.WriteLine(shop.AuthorShortestBookGenre(userChoice));
            break;
        default:
            Console.WriteLine("Invalid Digit");
            break;

    }
    do
    {
        Console.WriteLine("\nDo you want to see other things ? Digit no to stop the program, digit yes to continue and return to the menu ");
        digit = Console.ReadLine();
        if (digit.ToLower() != "yes" && digit.ToLower() != "no")
        {
            Console.WriteLine("Invalid Digit, try again");
        }
        else if (digit.ToLower() == "no")
        {
            Console.WriteLine("Thank you and Goodbye!");
        }
    } while (digit.ToLower() != "yes" && digit.ToLower() != "no");

} while (digit != "no");