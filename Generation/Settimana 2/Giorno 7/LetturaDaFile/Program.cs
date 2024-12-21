
/* LETTURA DA FILE 
 LEGGO i dati salvati in un file-> per poterlo leggere devo sapere dove si trova:
- 1 se il file non è integrato nella cartella del progetto ma si trova sul vostro disco allora dovrò indicare il suo percorso GLOBALE
    es.    "C:\Users\mxput\source\repos\Settimana 2\Giorno 7\LetturaDaFile\Dati.txt"    

       non va bene se dobbiamo condividere il progetto con qualcun'altro
- 2 se il file è integrato nella cartella del progetto indicherò il suo percorso LOCALE 
    es.    
 */

// SINTASSI DEI PERCORSI:
// GLOBALE -> (@"C:\Users\mxput\source\repos\Settimana 2\Giorno 7\LetturaDaFile\Dati.txt");
// LA @ E INDICA CHE IL TESTO CHE SEGUE NON è TESTO MA UN PERCORSO
// Se non mettete la @ il programma si rompe
// globale -> ("C:\\Users\\mxput\\source\\repos\\Settimana 2\\Giorno 7\\LetturaDaFile\\Dati.txt")

//LOCALI -> "../../../Dati.txt"

/* Struttura di dati:
 * ARRAY/ VETTORI
 * è un'insieme ordinato di elementi dello STESSO TIPO di DIMENSIONE FISSA
 * INSIEME ORDINATO -> UN'ARRAY può contenere più elementi che verrano salvati in un modo ordinato 
 *                     tramite un'indice numerico assegnato in modo automatico 
 *                     gli indici partono da 0 , l'indice più piccolo è sempre lo 0 e l'indice  massimo è sempre dato dalla misura dell'array meno 1*/

// --> STESSO TIPO -> IMPLICA che gli elementi al suo interno saranno dello stesso tipo ( o tutti string, o tutti int, o tutti double, ecc.)
// --> DIMENSIONE FISSA -> IMPLICA che una volta creato l'array avrà tante celle quante indicate alla creazione, non sarà più possibile eliminare o aggiungere celle
//                         (è possibile lasciare celle vuote)
// un'array è di tipo array e non del tipo di dati che in esso vengono salvati

// tipoDelDatoContenuto [] NomeArray; --> DICHIARAZIONE
// NomeArray = new tipoDelDatoContenuto[DIMENSIONE]; INIZIALIZZAZIONE
// tipoDelDatoContenuto [] NomeArray = NomeArray = new tipoDelDatoContenuto[DIMENSIONE] --> TUTTO SULLA STESSA RIGA

int[] numeri;
numeri = new int[9]; // creo un'array con 9 celle, l'indice minimo sarà 0 e quello massimo sarà 9-1 cioè 8

//salvo dei valori nell'array, ogni cella potrà contenere un solo valore
//ogni cella è IDENTIFICATA da un INDICE UNIVOCO -> che permette di recuperare un valore salvato cioè di accedere ad una cella
//nomeArray[indice] = valore 1;

numeri[0] = 8;
numeri[1] = 5;
numeri[2] = 6;
numeri[3] = 7;
numeri[4] = 23;
numeri[5] = 24;
numeri[6] = 2;
numeri[7] = 1;
numeri[8] = 87;

Console.WriteLine(numeri[0]);
Console.WriteLine(numeri[1]);
Console.WriteLine(numeri[2]);
Console.WriteLine(numeri[3]);

int i = 0;

while (i < numeri.Length)  // cosa voglio fare -> stampare il contenuto di ogni cella
{
    Console.WriteLine("Valore: " + numeri[i] + " salvato nella cella con indice " + i);
    i++; 

}

// Lettura da file 
/* Capire dove si trova il file/crearlo
 * leggo i dati in esso salvati
 * salvo i dati letti in  un contenitore
 * */

//setto il percorso
string percorso = "../../../Dati.txt";
File.ReadAllLines(percorso);
string[] NumeriFile = File.ReadAllLines(percorso);
// File.ReadAllLines(percorsoFile) -> cerca il file al percorso inserito tra le (), lo apre, legge tutte le righe del file, lo chiude 
int[] num = new int[NumeriFile.Length];

i = 0;
while(i < NumeriFile.Length)
{
    num[i] = int.Parse(NumeriFile[i]);
    i++;
}