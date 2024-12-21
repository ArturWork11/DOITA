/* Vorrei istanziare delle macchine
 * prenderò i dati da file
 * e li userò per definire le caratteristiche delle macchine che voglio creare */

// 1.Indico dove si trova il modello
// 2.indico dove si trova il file per prendere i dati


// 1.devo indicare al file Program cosa sia una macchina e quindi dove andare a prendere le informazioni che la definiscono
using EsercitazioneClassiMacchine;


//Creo una macchina di prova, ad ora non leggo i dati del file
//Dichiarazione: Tipo nomeOggetto;
//Inizializzazione: nomeOggetto = new Tipo();
Macchina m = new Macchina();
Console.WriteLine(m.Scheda());
//quando creo un'oggetto e non assegno dei valori specifici alle sue proprietà  queste assumono valori di DEFAULT:
//string --> null
//numeri --> 0
//bool --> false

//quando si cambia uno o più valori di una proprietà si cambia quello che è lo STATO di un'OGGETTO:
//è l'insieme dei valori delle proprietà in un dato momento

 m.marca = "Fiat";
Console.WriteLine(m.Scheda());


// 2. Setto il percorso del file e lo passo allo strumento in grado di leggerlo
string[] righeFile = File.ReadAllLines("../../../datiMacchina.txt");

//ogni cella contiene una riga del file che a sua volta contiene i dati relativi ad una macchina
//prendere i dati di una riga, separarli e a seconda di come è formattato il file salvare ogni valore nella sua specifica proprietà
//tante righe ci sono nel file tante macchine diverse dobbiamo creare
Macchina[] macchine = new Macchina[righeFile.Length];

//L'array è vuoto e devo riempirlo
//per farlo prenderò una riga del file che si trova nella cella righeFile
//la divido in modo da separare i valori
//creo una macchina
//salvo nelle proprietà della macchina i valori separati presi dalla riga del file
//nel file ci sono 6 righe quindi dovrò  creare 6 macchine e ripetere gli step precedenti per quel numero di volte

//  dove parto; dove arrivo ;come mi muovo
for (int i = 0; i < righeFile.Length; i++)
{
    //per farlo prenderò una riga del file che si trova nella cella dell'array righeFile
    //prendo la prima stringa salvata nella cella 0 dell'array righeFile e la salvo nella variabile riga 
    string riga = righeFile[i]; //riga = "Ferrari;Testa Rossa;Rossa;2022;S;S"
    //la divido in modo da separare i valori
    string[] datiSeparati = riga.Split(';'); //lo split genera tante stringhe quante volte ha separato la stringa principale ->> verranno create 6 stringhe a parte

    //creo una macchina
    Macchina macchina = new Macchina();
    //salvo nelle proprietà della macchina i valori separati presi dalla riga del file
    macchina.marca = datiSeparati [0];
    macchina.modello = datiSeparati [1];
    macchina.colore = datiSeparati[2];
    macchina.anno = int.Parse(datiSeparati[3]);
    macchina.ariaCondizionata = (datiSeparati[4] == "S" ? true : false);
    macchina.cerchiInLega = (datiSeparati[5] == "S"? true : false);

    //la macchina è creata e ho assegnato alle sue proprietà i valori letti 
    macchine[i] = macchina;
    Console.WriteLine("-----------------------");
    Console.WriteLine(macchine[i].Scheda());
    

}
