using Costruttori;

//creo un oggetto di tipo Videogioco
//il NEW indica la CREAZIONE
//come viene creato? -> tramite un metodo infatti new Videogioco() ha le ()
//questo metodo è detto COSTRUTTORE perché crea oggetti
//questo costruttore crea oggetti i cui valori delle proprietà sono quelli di DEFAULT
//questo tipo di costruttore ci viene dato a disposizione senza doverlo dichiarare nella classe modello è IMPLICITO
Videogioco videogioco = new Videogioco();
videogioco.titolo = "Mario Party";

Videogioco v4 = new Videogioco("Mario Party", "Switch");
Console.WriteLine(v4.Scheda());

string console = "Switch";
string titolo = "Sonic";
Videogioco v2 = new Videogioco(titolo,console);
Console.WriteLine("Videogioco: " + v2.Scheda());

Videogioco v3 = new Videogioco();
Console.WriteLine(v3.Scheda());

Negozio n1 = new Negozio("../../../Dati.txt","","");
Console.WriteLine(n1.Catalogo());
//Negozio n2 = new Negozio("../../../ListaVideo.txt");

Console.WriteLine("Lista dei videogiochi con la media votipiù alta:\n");
List<Videogioco> lista = n1.VideogiocoMediaMax();

for(int i = 0; i < lista.Count; i++)
{
    Console.WriteLine(lista[i].Scheda() + "\n");
}

List<Videogioco> listePerRcerca = n1.CercaPerGenereEStudio("Action/Adventure", "Nintendo EPD");



Console.WriteLine(n1.CercaPerGenereEStudio("Exploration","studio a caso"));