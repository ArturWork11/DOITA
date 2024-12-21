using System.Security.Cryptography;
using Sportivi;

Federazione federazione = new Federazione("../../../sportivi.txt");
string cmd = "";
string output = "";



do
{
    Console.WriteLine("Benvenuto! Cosa vorresti fare?");
    Console.WriteLine("1- Visualizza la lista degli sportivi in base alla categoria scelta");
    Console.WriteLine("2- Cerca sportivi tra i 18 e i 28 anni");
    Console.WriteLine("3- Cerca sportivi per nome e cognome");
    Console.WriteLine("4- Stampa media eta per categoria");
    Console.WriteLine("0- ESCI");

    cmd = Console.ReadLine();
    switch (cmd)
    {
        case "1":
            Console.WriteLine("Quale categoria vorresti vedere?");
            string cat = Console.ReadLine();
            output = federazione.StampaListe(cat);
            Console.WriteLine(output);
            break;
        case "2":
            Console.WriteLine("Ecco gli sportivi giovani");
            output = federazione.SportiviGiovani();
            Console.WriteLine(output);
            break;
        case "3":
            Console.WriteLine("Digita prima il nome e poi il cognome dell'atleta che cerchi");
            string nome = Console.ReadLine();
            string cognome = Console.ReadLine();
            output = federazione.RicercaNome(nome,cognome);
            Console.WriteLine(output);
            break;
        case "4":
            Console.WriteLine("Stamperò la media dell'età di ogni categoria di sportivo");
            output = federazione.MediaEta();
            Console.WriteLine(output);
            break;
        case "0":
            Console.WriteLine("Grazie e arrivederci");
            break;
        default:
            Console.WriteLine($"Errore!! Comando {cmd} non riconosciuto!");
            break;
    }

} while (cmd != "0");
