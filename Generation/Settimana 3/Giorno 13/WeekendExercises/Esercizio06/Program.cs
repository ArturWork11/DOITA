

//Esercizio06_LetturaDaFile
// Scrivere un file che contenga le marche delle auto di un concessionario.
// Voglio un programma che legga il file e stampi in console:
// - Il numero di marche presenti (Se nel file ci sono ripetizioni, non dovete contarle)
// - La marca più corta
// - Permettete all'utente di cercare una marca a sua scelta


using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;

string[] fileLines = File.ReadAllLines("../../../carBrand.txt");
string brandOneTime = "";
int noRepetion = 0;
int minLenght = int.MaxValue;
string minLenghtBrand = "";

for (int i = 0; i < fileLines.Length;i++)
{
    if (!brandOneTime.Contains(fileLines[i]))
    {
        brandOneTime += "\n" + fileLines[i];
        noRepetion++;
    }
}
Console.WriteLine($"There are {noRepetion} car brand in the list\nHere it is the list without ripetion: {brandOneTime} ");

for (int i = 0;i <fileLines.Length; i++)
{
    if (fileLines[i].Length < minLenght) 
    {
        minLenght = fileLines[i].Length;
        minLenghtBrand = fileLines[i];
    }
    else if (fileLines.Length == minLenght && !minLenghtBrand.Contains(fileLines[i]))
    {
        minLenghtBrand = "," + fileLines[i];
    }
}

Console.WriteLine($"\nThe shorter car brand is {minLenghtBrand}");

string userBrandSearch = "";
Console.WriteLine($"\nChoose a car brand and i will found it for you");
userBrandSearch = Console.ReadLine().ToLower();
for (int i = 0;i < fileLines.Length; i++)
{
    if (userBrandSearch == fileLines[i].ToLower())
    {
        break;
    }
}
Console.WriteLine($"\nThe car brand {userBrandSearch} is avaible!!");

