//Esercizio02_Selezione
/*
Chiedere all'utente:
   - il titolo di un libro
   - il suo autore
   - il numero di pagine
   - il genere del libro
Calcolare il prezzo del libro secondo le seguenti regole:
   > prezzo base: 5
   > se il genere è horror aggiungere 3,
       se è fantasy aggiungere 2.5,
       se è storico aggiungere 10,
       in tutti gli altri casi aggiungere 1.9
   > se l'autore è Rowling aggiungere 2.1,
       se è Tolkien aggiungere 3.1,
       se è King aggiungere 4
       se è Manfredi aggiungere 3.5
       in tutti gli altri casi aggiungere 1.5
   > se il numero delle pagine è minore di 100 togliere il 5%
       se il numero di pagine è compreso tra 100 e 200 aggiungere il 3%
       se il numero di pagine supera i 200 aggiungere il 6%
Stampare in console la scheda ordinata del libro con il suo prezzo
*/

using System.Timers;

string bookTitle = "";
string author = "";
int pages = 0;
string genre = "";
double price = 5;

Console.WriteLine("Insert the title of the book");
bookTitle = Console.ReadLine();
Console.WriteLine("Inser the author of the book");
author = Console.ReadLine();
Console.WriteLine("Inser the number of pages of the book");
pages = int.Parse(Console.ReadLine());
Console.WriteLine("Inser the genre of the book");
genre = Console.ReadLine();

if (pages > 0 && genre != null && author != null)
{
    switch (genre.ToLower())
    {
        case "horror":
            price += 3;
            break;
        case "fantasy":
            price += 2.5;
            break;
        case "storico":
            price += 10;
            break;
        default:
            price += 1.9;
            break;
    }

    switch (author.ToLower())
    {
        case "rowling":
            price += 2.1;
            break;
        case "tolkien":
            price += 3.1;
            break;
        case "king":
            price += 4;
            break;
        case "manfredi":
            price += 3.5;
            break;
        default:
            price += 1.5;
            break;
    }


    if (pages < 100)
    {
        price -= (price / 100) * 5;
    }
    else if (pages  > 100 && pages < 200)
    {
        price += (price / 100) * 3;
    }
    else if (pages > 200)
    {
        price += (price /100) * 6;
    }

Console.WriteLine ($"\nBook details and price: \nBook title: {bookTitle} \nGenre: {genre} \nAuthor: {author} \nPages of the book: {pages} \nPrice: {price}");
}
else
{
    Console.WriteLine("One or more entered values are wrong");
}
