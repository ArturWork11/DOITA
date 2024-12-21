//        Voglio creare un programma che sia in grado di
//        calcolare il prezzo di un PC basandosi sulle sue
//        caratteristiche.
//        Chiediamo le seguenti informazioni:
//        - Processore (I3, I5, I7 etc)
//        - quantità di ram
//        - tipologia di ram
//        - quantità di memoria
//        - tipo di memoria
//        - marca del PC
//        Il costo del PC dipende da molti fattori:
//        - I3: 150
//        - I5: 220
//        - I7: 350
//        - I9: 400
//        - in tutti gli altri casi: 180
//        Anche la ram ha un prezzo diverso, ma a seconda della
//        tipologia. Ogni GB di ram costa diversamente a seconda
//        del tipo:
//        - DDR3: 5  euro/GB
//        - DDR4: 10 euro/GB
//        - altri tipologie sconosciute: 7 euro/GB
//        Stesso discorso vale per la memoria:
//        - HDD: 0.01  euro/GB
//        - SSD: 0.2   euro/GB
//        - SSDM2: 0.5 euro/GB
//        Se la marca è ANANAS raddoppiare il prezzo finale.

double PrezzoPc = 0, Ram, Memoria;
string Processore,  TipoRam, TipoMemoria, MarcaPc;

Console.WriteLine("Con quale processore vorresti acquistare il tuo pc? I3, I5, I7, I9 o altri?");
Processore = Console.ReadLine();
Console.WriteLine("Con quale tipo di ram vorresti acquistare il tuo pc? DDR3,DDR4 O ALTRI?");
TipoRam = Console.ReadLine();
Console.WriteLine("Quanta ram vuoi che abbia?");
Ram = double.Parse(Console.ReadLine());
Console.WriteLine("Quale sistema di archiviazione memoria vorresti che abbia? HDD , SSD O SSDM2");
TipoMemoria = Console.ReadLine();
Console.WriteLine("Quanta memoria deve avere?");
Memoria = double.Parse(Console.ReadLine());
Console.WriteLine("Di quale marca vorresti acquistare il tuo pc?");
MarcaPc = Console.ReadLine();

switch (Processore)
{
    case "I3":
        PrezzoPc += 150;
        break;
    case "I5":
        PrezzoPc += 220;
        break;
    case "I7":
        PrezzoPc += 350;
        break;
    case "I9":
        PrezzoPc += 400;
        break;
    default:
        PrezzoPc += 180;
        break;
}

switch (TipoRam) 
{
    case "DDR3":
        PrezzoPc += 5 * Ram;
        break;
    case "DDR4":
        PrezzoPc += 10 * Ram;
        break;
    default:
        PrezzoPc += 7 * Ram;
        break;
}

switch (TipoMemoria)
{
    case "HDD":
        PrezzoPc += 0.01 * Memoria;
        break;
    case "SSD":
        PrezzoPc += 0.2 * Memoria;
        break;
    case "SSDM2":
        PrezzoPc += 0.5 * Memoria;
        break;
}

switch (MarcaPc)
{
    case "ANANAS":
        PrezzoPc *= 2;
        break;
}

Console.WriteLine("Il prezzo per il tuo pc è " + PrezzoPc);