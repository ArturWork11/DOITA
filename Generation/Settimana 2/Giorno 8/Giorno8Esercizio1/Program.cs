//        Creare un programma che chiede all'utente di inserire i dati di medici.
//        Chiedere innanzitutto il numero di medici da inserire
//        Per ogni medico chiedere: - Il nome
//        - I suoi anni di esperienza
//        - Il reparto in cui lavoro
//        - Il numero di interventi - Il numero di interventi riusciti
//        Per ogni medico calcoleremo il suo stipendio nel seguente modo: - A seconda del reparto hanno stipendi di base differenti: � Anatomia: 1300
//        � Chirurgia: 1500
//        � Pediatria: 2000
//        � Tutti gli altri casi: 1700
//        - Per ogni anno di esperienza aggiungere al medico 50�, MA se lavora nel reparto pediatria, l'aumento per ogni 
//        anno � di 100�
//        - Per ogni intervento RIUSCITO aggiungere 10�
//        - Per ogni intervento NON RIUSCITO togliere 50� Ma se lavora nel reparto pediatria non glieli togliamo, anzi 
//        gliene diamo 20 in pi�
//        Calcolare e stampare le seguenti informazioni: - Lo stipendio totale dei medici - Lo stipendio medio dei medici - Il NUMERO di medici che lavorano nel reparto pediatria
//        - Lo stipendio medio dei pediatri
//        PARTE BONUS: - Trovare il nome del medico che percepisce lo stipendio pi� ALTO, ma non del reparto Pediatria
//        - Voglio trovare il numero di serial killer che ci sono: un medico � serial killer se il numero di interventi FALLITI � 
//        almeno il doppio di quelli riusciti. Ad eccezione dei pediatri. Loro possono uccidere senza diventare serial killer. - Voglio anche la lista dei serial killer
//        - Trovare il nome del medico che ha il massimo delle uccisioni - Trovare il nome del medico che ha il rapporto uccisioni / salvataggi pi� alta

Console.WriteLine("Quanti medici ci sono?");
int numMedici = int.Parse(Console.ReadLine());
string[] doc = new string[numMedici];
int[] anni = new int[numMedici];
string[] reparto = new string[numMedici];
int[] interventi = new int[numMedici];
int[] riusciti = new int[numMedici];
int[] stipendio = new int[numMedici];
int pediatri = 0;
int stipendioPed = 0;

for (int i = 0; i < numMedici; i++)
{
    Console.WriteLine($"Come si chiama il medico {i+1}?");
    doc[i] = Console.ReadLine();
    Console.WriteLine("Quanti anni di esperienza ha?");
    anni[i] = int.Parse(Console.ReadLine());
    Console.WriteLine("in quale reparto lavora?");
    reparto[i] = Console.ReadLine().ToLower();
    Console.WriteLine("Quanti interventi ha eseguito?");
    interventi[i] = int.Parse(Console.ReadLine());
    Console.WriteLine("Quanti interventi son riusciti?");
    riusciti[i] =int.Parse(Console.ReadLine());
}

for (int i = 0; i < numMedici; i++)
{
    switch (reparto[i])
    {
        case "anatomia":
            stipendio[i] = 1300 + (anni[i] * 50) + (riusciti[i] * 10) - ((interventi[i] - riusciti[i]) * 50);
            break;
        case "chirurgia":
            stipendio[i] = 1500 + (anni[i] * 50) + (riusciti[i] * 10) - ((interventi[i] - riusciti[i]) * 50);
            break;
        case "pediatria":
            stipendio[i] = 2000 + (anni[i] * 100) + (riusciti[i] *10) + ((interventi[i] - riusciti[i]) * 20);
            stipendioPed += stipendio[i];
            pediatri++;
            break;
        default:
            stipendio[i] = 1700 +(anni[i] * 50) +(riusciti[i] * 10) - ((interventi[i] - riusciti[i]) * 50);
            break;
    }

}

int StipendioTotale = 0;
string nomiStipendi = "";
for (int i = 0; i < numMedici; i++)
{
    nomiStipendi += $"{doc[i]}  {stipendio[i]} \n"; 
    StipendioTotale += stipendio[i];
}

Console.WriteLine($"\n Lo stipendio di ognuno è \n{nomiStipendi} ");
Console.WriteLine($"Lo stipendio totale è {StipendioTotale}");

int StipendioMedio = StipendioTotale / numMedici;
int StipendioMedioPed = stipendioPed / pediatri;
Console.WriteLine($"Lo stipendio medio è {StipendioMedio}");
Console.WriteLine($"Lo stipendio medio dei pediatri è {StipendioMedioPed}");

string DocRicco = "";
int minimo = 0;
for (int i = 0; i < numMedici; i++)
{
    if (reparto[i] != "pediatria" && stipendio[i] > minimo)
    {
            minimo = stipendio[i];
            DocRicco = doc[i];  
    }
}

Console.WriteLine($"il medico piu ricco è {DocRicco}");

int Kill = 0;
string SerialKiller = "";
string Killer = "";
for (int i = 0; i < numMedici; i++)
{
    if (reparto[i] != "pediatria" && (interventi[i] - riusciti[i]) > (riusciti[i] * 2))
    {   
            SerialKiller += doc[i] + ",";
        if ((interventi[i] - riusciti[i]) > Kill)
        {
            Killer = doc[i];
            Kill = (interventi[i] - riusciti[i]);
        }

    }
}

Console.WriteLine($"i dottori serial killer sono: \n {SerialKiller}");
Console.WriteLine($"il dottore con più uccisioni è: {Killer}");

double rapporto = 0;
double rapportoMax = 0;
string docRapporto = "";

for (int i = 0; i < numMedici; i++)
{
    if (riusciti[i] != 0)
    {
        rapporto = (interventi[i] - riusciti[i]) / riusciti[i];
        if (rapporto > rapportoMax)
        {
            rapportoMax = rapporto;
            docRapporto = doc[i];
        }

    }
}

Console.WriteLine($"il dottore con il rapporto piu alto è {docRapporto}");
