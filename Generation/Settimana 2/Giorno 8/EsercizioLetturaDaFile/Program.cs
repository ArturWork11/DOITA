// Scrivere un file che contenga il nome e l'età di una persona.
// Stampate poi in console l'accoppiata Nome: età
// Voglio vedere:
// - l'età media delle persone
// - Il nome delle persone più giovani
// - L'accoppiata nome-eta di un nome a scelta dell'utente
// - l'elenco dei nomi senza ripetizioni

using System.Numerics;

int i = 0;
string[] nomi = File.ReadAllLines("../../../Dati.txt");

while (i < nomi.Length)
{
    Console.WriteLine($"{nomi[i]} : {nomi[i+1]}");
    i += 2;
}


i = 0;
double totEta=0;
while (i < nomi.Length)
{
    totEta += double.Parse(nomi[i+1]);
    i += 2;
}

double Media = totEta / (nomi.Length / 2);
Console.WriteLine($"L'età media è {Media:F2}");

i = 0;
string giovani = "";
while (i < nomi.Length)
{
    if (int.Parse(nomi[i+1]) < 24 && !giovani.Contains(nomi[i]))
    {
        giovani += nomi[i] + "\n";
    }
    i+=2;
}
Console.WriteLine($"i nomi dei ragazzi più giovani sono \n{giovani}");



Console.WriteLine("Scegli un nome e ti restituirò l'accoppiata");
string accoppiata = Console.ReadLine();
string accoppiataNum ="";
i=0;
while (i < nomi.Length)
{
    if (nomi[i].Contains(accoppiata))
    {
        accoppiataNum += nomi[i] + ": " + nomi[i+1] + " ";
    }
    i += 2;
}
Console.WriteLine("Ecco l'accoppiata del nome " + accoppiata + "\n" + accoppiataNum + " ");

/*
i = 0;
int k = 0;
bool isPresent = false;
string noRipetizioni ="";
while (i < nomi.Length - 2)
{
    isPresent = false;
    string nome = nomi[i];
    int j = 0;
    while (j <)
       

        
  
}
Console.WriteLine("\n Ecco la lista senza ripetizioni \n" + noRipetizioni); */

string[] nomiSenzaRipetizioni = new string[nomi.Length];
int numUnici = 0;
i = 0;

while (i < nomi.Length)
{
    bool esiste = false;
    int j = 0;
    while (j < numUnici)
    {
        if (nomi[i] == nomiSenzaRipetizioni[j])
        {
            esiste = true;
            break;
        }
        j++;
    }
    if (!esiste)
    {
        nomiSenzaRipetizioni[numUnici] = nomi[i];
        numUnici++;
    }
    i += 2;
}


i = 0;
Console.WriteLine("Nomi senza ripetizioni:");
while (i < numUnici)
{
    Console.WriteLine(nomiSenzaRipetizioni[i]);
    i++;
}

