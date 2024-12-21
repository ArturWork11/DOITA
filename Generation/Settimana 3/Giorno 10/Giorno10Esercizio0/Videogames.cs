using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giorno10Esercizio0
{
    internal class Videogames
    {
        public string title;
        public string console;
        public string releaseDate;
        public string publisher;
        public int critVote;
        public int userVote;
        public string genre;
        public int day;
        public int month;
        public int years;

        public string scheda()
        {
            string result = "";
            result = $"Title of the game: {title} \nConsole: {console} \nRelease Date: {releaseDate} \nSviluppatori: {publisher} \nCrits vote: {critVote} \nUser vote: {userVote} \nGenre: {genre} \nAvearge Grade: {averageGrade()} \nPublished {videogameAge()} years ago";
            return result ;
        }
        
        public int averageGrade()
        {
            int result = 0 ;
            result = (critVote + userVote) / 2;
            return result ;
        }

        public int videogameAge()
        {
            int result = 0;
            result = (DateTime.Now.Year) - years;
            return result;
        }

    }
}
