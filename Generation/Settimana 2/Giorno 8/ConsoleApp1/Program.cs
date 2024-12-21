string percorso = "../../../Dati (1).txt";
string[] file = File.ReadAllLines(percorso);
string[] nomi = new string[file.Length / 2];
int[] eta = new int[file.Length / 2];
int sommaEta = 0;
int etaMin;
int indiceScelto;

int i = 0;
int j = 0;
while (i < file.Length)
{
    nomi[j] = file[i];
    i += 2;
    j++;
}

i = 1;
j = 0;
while (i <= file.Length)
{
    eta[j] = int.Parse(file[i]);
    i += 2;
    j++;
}

// NOME: ETA
i = 0;
while (i < eta.Length)
{
    Console.WriteLine(nomi[i] + ": " + eta[i]);
    i++;
}

// ETA MEDIA
i = 0;
while (i < eta.Length)
{
    sommaEta += eta[i];
    i++;
}
Console.WriteLine("La somma delle eta' e': " + sommaEta + " e la media e' " + (double)sommaEta / eta.Length);

// NOMI ETA MINIMA
i = 0;
etaMin = eta[0];
while (i < eta.Length)
{
    if (eta[i] < etaMin)
    {
        etaMin = eta[i];
    }
    i++;
}

Console.Write("Le persone piu' giovani sono: ");
i = 0;
while (i < eta.Length)
{
    if (eta[i] == etaMin)
    {
        Console.Write(nomi[i] + ", ");
    }
    i++;
}

// NOME ETA SCELTI
Console.WriteLine("Inserisci un numero da 1 a " + file.Length/2 +"!");
indiceScelto = (int.Parse(Console.ReadLine())-1);

Console.WriteLine(nomi[indiceScelto] + ": " + eta[indiceScelto]);

//NO RIPETIZIONI
string[] nomiSenzaRipetizioni = new string[nomi.Length];
int numUnici = 0;
i = 0;

while (i < nomi.Length)
{
    bool esiste = false;
    j = 0;
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
    i++;
}


i = 0;
Console.WriteLine("Nomi senza ripetizioni:");
while (i < numUnici)
{
    Console.WriteLine(nomiSenzaRipetizioni[i]);
    i++;
}