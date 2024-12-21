
// Scrivere un programmino che letti da file i dati di alcuni pazienti mostri:
// - Lista delle schede dei pazienti
// - Paziente più anziano
// - Pazienti per una malattia a scelta dell'utente
// - nome,cognome,dataNascita,malattia,reparto

using EsercizioOspedaleOggetti;
using System.Drawing;

string[] righePazienti = File.ReadAllLines("../../../DatiPazienti.txt");
Pazienti[] pazienti = new Pazienti[righePazienti.Length];
for (int i = 0;i < righePazienti.Length; i++)
{
    string[] info = righePazienti[i].Split(';');
    Pazienti paziente = new Pazienti();
    paziente.nome = info[0];
    paziente.cognome = info[1];
    paziente.dataNascita = info[2];
    paziente.malattia = info[3];
    paziente.reparto = info[4];
    paziente.giorno = int.Parse(info[2].Split('-')[0]);
    paziente.mese = int.Parse(info[2].Split('-')[1]);
    paziente.anno = int.Parse(info[2].Split('-')[2]);

    pazienti[i] = paziente;

}
for  (int i = 0;i < righePazienti.Length; i++)
{
    Console.WriteLine("---------------------------");
    Pazienti paziente = pazienti[i];
    Console.WriteLine(paziente.scheda());
}
int annoAnziano = pazienti[0].anno;
int mese = pazienti[0].mese;
int giorno = pazienti[0].giorno;
string pazienteAnziano = "";
string dataAnziano = "";
for (int i = 0;i < righePazienti.Length; i++)
{
    
    if (pazienti[i].anno < annoAnziano && pazienti[i].mese < mese && pazienti[i].giorno < giorno )
    {
        annoAnziano = pazienti[i].anno;
        mese = pazienti[i].mese;
        giorno = pazienti[i].giorno;
        pazienteAnziano = pazienti[i].nome + " " + pazienti[i].cognome;
        dataAnziano = pazienti[i].dataNascita;
    }
    
}
Console.WriteLine("\n Il paziente più anziano è " + pazienteAnziano + " nato il " + dataAnziano);

Console.WriteLine("Inserisci la malattia del paziente/i che ricerchi");
string malattiaScelta = Console.ReadLine();
string pazienteRicercato = "";
bool malattiaPresente = false;
for (int i = 0;i < righePazienti.Length; i++)
{
    if (pazienti[i].malattia.ToLower() == malattiaScelta)
    {
        pazienteRicercato += "\n" + pazienti[i].nome + " " + pazienti[i].cognome;
        malattiaPresente = true;
    }
}

if (malattiaPresente == false)
{
    Console.WriteLine("Malattia non presente nel sistema, ritenta controllando di averla scritta giusta");
}
else
{
    Console.WriteLine($"Il paziente con la malattia {malattiaScelta} è {pazienteRicercato}");
}

