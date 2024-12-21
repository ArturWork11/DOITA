using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal class Shop : IShop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List <Entity> entities { get; set; }

        public Shop() 
        {
           
        }

        public Shop(string path)
        {
            entities = new List<Entity>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] row = line.Split(';');
                switch (row[1].ToLower())
                {
                    case "libro":
                        entities.Add(new Book(row));
                        break;
                    case "film":
                        entities.Add(new Film(row));
                        break;
                    case "cd":
                        entities.Add(new Cd(row));
                        break;
                    default:
                        break;
                }
            }
        }

        public List<Entity> FullList() //metodo per avere una lista con le sole specifiche dei prodotti (esempio Bangarabang - Skrillex - 3 ecc.)
        {
            List<Entity> list = new List<Entity>();
            foreach (Entity entity in entities)
            {
              list.Add(entity);  
            }
            return list;
        }

        public List<Book> BooksList()
        {
           return entities.OfType<Book>().ToList();
        }

        public List<Film> FilmList() 
        {
            return entities.OfType<Film>().ToList();
        }

        public string CdList() //metodo per avere i prodotti Cd in modo ordinato da costruttore (es. Titolo: Bangarabang \nArtista: Skrillex \nDurata: 3... ecc.)
        {
            string list = "";
            foreach (Entity entity in entities)
            {
                if (entity is Cd)
                {
                    list += entity.ToString();
                }
            }
            return list;
        }

        public string ProductAfterUserYears(string userChoice) //metodo che ritorna una stringa con titolo e anno dei prodotti pubblicati dopo un'anno a scelta dell'utente
        {
            string list = "";
            foreach (Entity entity in entities)
            {
                if (entity is Product product  && product.YearsPublished > int.Parse(userChoice))
                {
                    list += "\n" + product.Title + product.YearsPublished + "\n";
                }
            }
            return list;
        }

        public double AverageFilmPriceGenre(string userChoice)
        {
            double averagePrice = 0;
            double sum = 0;
            int EntityNumber = 0;
            foreach (Entity entity in entities)
            {
                if (entity is Film film && film.Genre == userChoice)
                {
                    sum += film.Price;
                    EntityNumber++;

                }
            }
            averagePrice = sum / EntityNumber; 
            return averagePrice;
        }

        public double SumPriceCdArtist(string userChoice)
        {
            double sum = 0;
            foreach (Entity entity in entities)
            {
                if (entity is Cd cds && cds.Artist == userChoice)
                {
                    sum += cds.Price;
                } 
            }
            return sum;
        }

        public double SumPriceBookAfterUserYears(string userChoice)
        {
            double sum = 0;
            foreach (Entity entity in entities)
            {
                if (entity is Book book && book.YearsPublished == int.Parse(userChoice))
                {
                    sum += book.Price;
                }
            }
            return sum;
        }

        
        public string ArtistWithMostCD()
        {
            string list = "";
            double count = 0;
            foreach (Entity entity in entities)
            {
                if (entity is Cd cds && cds.Artist.Count() > count)
                {
                    count = cds.Artist.Count();
                    list = cds.Artist;
                   
                }
            }
            return list;

        }

        public string DirectorFilmMostExpensive()
        {
            string list = "";
            double price = 0;
            foreach (Entity entity in entities)
            {
                if (entity is Film film && film.Price > price)
                {
                    price = film.Price;
                    list = film.Director;
                }

            }
            return list;
        }

        public string AuthorShortestBookGenre(string userChoice)
        {
            string list = "";
            double Max = double.MaxValue;
            foreach (Entity entity in entities)
            {
                if (entity is Book books && books.Genre == userChoice && books.PagesNumber < Max)
                {
                    Max = books.PagesNumber;
                    list = books.Author;
                }
            }
            return list;
        }
    }
}
