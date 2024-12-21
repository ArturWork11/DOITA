/*
 Creare un programma che permetta di:
leggere un file, esso contiene le informazioni inerenti a dei videogiochi
per poter gestore le info in modo efficace ->
creare una classe modello per Videogioco che avrà le seguenti caratteristiche:
.titolo
.console
.dataRilascio
.studioDiSviluppo
.votoCritica
.votoUtente
.genere

inoltre avrà i seguenti metodi:
.scheda()
.votoMedio() -> dato dalla media tra votodell'utente e voto della critica
.etaVideogioco() -> da quanti anni è stato pubblicato

leggere il file
prendere i dati e separarli
creare i videogiochi e salvare in essi i dati letti dal file
salvare i videogiochi in una lista
stampare la lista completa dei videogiochi
trovare il videogioco con la media più alta
trovare il gioco più vecchio

BONUS:
stampare la lista dei videogiochi di solo genere "Survival" e sviluppati da "Naughty Dog"*/

using Giorno10Esercizio0;
List<string> linesFile = new List<string>(File.ReadAllLines("../../../DatiVideogame.txt"));
List<Videogames> videogamesList = new();
int minimumVote = 0;
string videogameMaxVote = "";
string oldestGame = "";
int minDay = int.MaxValue;
int minMonth = int.MaxValue;
int minYears = int.MaxValue;
List<string> gamesNAughtyDogSurvival = new List<string>();

for (int i = 0; i < linesFile.Count; i++)
{
    linesFile[i].Split(";");
    Videogames videogame = new Videogames();
    videogame.title = linesFile[i].Split(";")[0];
    videogame.console = linesFile[i].Split(";")[1];
    videogame.releaseDate = linesFile[i].Split(";")[2];
    videogame.day = int.Parse(linesFile[i].Split(";")[2].Split("-")[0]);
    videogame.month = int.Parse(linesFile[i].Split(";")[2].Split("-")[1]);
    videogame.years = int.Parse(linesFile[i].Split(";")[2].Split("-")[2]);
    videogame.publisher = linesFile[i].Split(";")[3];
    videogame.critVote = int.Parse(linesFile[i].Split(";")[4]);
    videogame.userVote = int.Parse(linesFile[i].Split(";")[5]);
    videogame.genre = linesFile[i].Split(";")[6];
    Console.WriteLine("========================");
    Console.WriteLine(videogame.scheda());
    if (minimumVote < videogame.averageGrade())
    {
        minimumVote = videogame.averageGrade();
        videogameMaxVote = linesFile[i].Split(";")[0];
    }
    

    if (minYears > videogame.years  && minMonth > videogame.month && minDay > videogame.day)
    {
        minYears = videogame.years;
        minMonth = videogame.month;
        minDay = videogame.day;
        oldestGame = videogame.title + " Release Date: " + videogame.releaseDate;
    }
    if (videogame.genre == "Survival" && videogame.publisher == "Naughty Dog")
    {
        gamesNAughtyDogSurvival.Add(videogame.title);
    }

}

Console.WriteLine("\n The game with the highest average grade is " + videogameMaxVote);
Console.WriteLine("The oldest game is " + oldestGame);
Console.WriteLine("Giochi Survival e della Naughty Dog:");
for (int i=0; i < gamesNAughtyDogSurvival.Count; i++)
{
    Console.WriteLine(gamesNAughtyDogSurvival[i]);

}







