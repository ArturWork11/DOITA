using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EsercizioSportivi
{
    internal class Federation
    {
        public List<SoccerPlayer> soccerPlayers = new List<SoccerPlayer>();
        public List<TennisPlayer> tennisPlayers = new List<TennisPlayer>();
        public List<Swimmer> swimmers = new List<Swimmer>();
        public List<Boxer> boxers = new List<Boxer>();
        public List<Rider> riders = new List<Rider>();
        public Federation(string path)
        {
            string [] linesFile = File.ReadAllLines(path);
            for (int i = 0; i < path.Length; i++)
            {
                string[] splitFile = linesFile[i].Split(",");

                switch (splitFile[0])
                {
                    case "calciatore":
                        SoccerPlayer soccerPlayer = new SoccerPlayer(splitFile[0], splitFile[1], splitFile[2], double.Parse(splitFile[3]), int.Parse(splitFile[4]), splitFile[5], splitFile[6]);
                        soccerPlayers.Add(soccerPlayer);
                        break;
                    case "tennista":
                        TennisPlayer tennisPlayer = new TennisPlayer(splitFile[0], splitFile[1], splitFile[2], double.Parse(splitFile[3]), splitFile[4], splitFile[5]);
                        tennisPlayers.Add(tennisPlayer);
                        break;
                    case "nuotatore":
                        Swimmer swimmer = new Swimmer(splitFile[0], splitFile[1], splitFile[2], double.Parse(splitFile[3]), splitFile[4]);
                        swimmers.Add(swimmer);
                        break;
                    case "pugile":
                        Boxer boxer = new Boxer(splitFile[0], splitFile[1], splitFile[2], double.Parse(splitFile[3]), double.Parse(splitFile[4]));
                        boxers.Add(boxer);
                        break;
                    case "pilota":
                        Rider rider = new Rider(splitFile[0], splitFile[1], splitFile[2], double.Parse(splitFile[3]), splitFile[4], splitFile[5]);
                        riders.Add(rider);
                        break;
                }

                
            }

        }

        public void SportFinder()
        {
            string userSport;
            Console.WriteLine("Quale categoria di sport cerchi?");
            userSport = Console.ReadLine();

            
            switch (userSport)
            {
                case "calciatore":
                    for (int i  = 0; i < soccerPlayers.Count;i++)
                        Console.WriteLine($"\n{soccerPlayers[i].Card}");
                    break;
                case "tennista":
                    for (int i = 0; i < tennisPlayers.Count; i++)
                        Console.WriteLine(tennisPlayers[i].Card);
                    break;
                case "nuotatore":
                    for (int i = 0; i < swimmers.Count; i++)
                        Console.WriteLine(swimmers[i].Card);
                    break;
                case "pugile":
                    for (int i = 0; i < boxers.Count; i++)
                        Console.WriteLine(boxers[i].Card);
                    break;
                case "pilota":
                    for (int i = 0; i < riders.Count; i++)
                        Console.WriteLine(riders[i].Card);
                    break;
            }
        }
        
        public void FilterAge(int min, int max)
        {
            for (int i=0; i < 
        }


    }
}

