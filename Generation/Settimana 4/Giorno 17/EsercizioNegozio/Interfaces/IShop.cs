using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal interface IShop
    {
        //void ImportData(string path);
        List<Entity> FullList();
        List<Book> BooksList();

        List<Film> FilmList();
        string CdList();

        string ProductAfterUserYears(string userChoice);
        double AverageFilmPriceGenre(string userChoice);
        double SumPriceCdArtist(string userChoice);
        double SumPriceBookAfterUserYears(string userChoice);
        string ArtistWithMostCD();
        string DirectorFilmMostExpensive();
        string AuthorShortestBookGenre(string userChoice);

        public string PrintList(List<Entity> list)
        {
            string ris = "\n";
            foreach (Entity ent in list)
            {
                ris += ent.ToString() + "\n";
            }
            return ris;
        }
    } 
}
