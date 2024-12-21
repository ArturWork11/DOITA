//LE ECCEZIONI
//Concettualmente sono delle situazioni eccezionali rispetto alla normale esecuzione del programma,
//Sono cose che accadono NON regolarmente.
//Tecnicamente parlando sono degli errori come ad esempio: accesso ad una posizione (indice) di un array o lista che non esiste, lettura di un file il cui percorso non esiste o è errato
//parse di una stringa che però contiene delle lettere,accesso o utilizzo di un oggetto null

//esempio 1:
using System.IO.Pipes;

string[] strArray = new string[3];
strArray[0] = "Prima";
strArray[1] = "Seconda";
strArray[2] = "Terza";
//strArray[3] = "Quarta"; //qui il programma crasha con IndexOutOfRangeException

//esempio 2:
List <string> strList = new List<string>();
//strList.Add = ("Prima");
//strList.Add = ("Seconda");
//strList.Add = ("Terza");

//esempio 3:
//File.ReadAllLines();

//esempio 4:
//Persona p = null;


//esempio 5:
//string numeroStr = "56k";

//int n = int.Parse(numeroStr); //il programma crasha con FormatException

//in C# abbiamo la possibilità di gestire le eccezzioni tramite il costrutto try-catch-finally
//Questo costrutto ci permette di inserire del codice potenzialmente esplosivo
//(codice che potrebbe potenzialmente generare un'eccezione) all'interno del blocco try.
//Se il codice viene eseguito senza problemi il programma prosegue tranquillamente altrimenti
//se qualcosa esplode (viene lanciata un'eccezione) all'interno del try, viene interrota l'esecuzione
//del codice e il programma passa ad eseguire il codice che c'è all'interno del blocco catch
//(a patto che il catch, catturi l'eccezione lanciata nel try)

//esempio 5 con try-catch

string numeroStr = "56k";

//In questo caso andiamo a definire due catch differenti per due tipi di eccezioni differebti
//Questo ci permette di gestire in maniera differente le due eccezioni 
try
{
    int n = int.Parse(numeroStr);
}
catch(FormatException e) 
{
    Console.WriteLine("Errore formato: " + e.Message);
}
catch(ArgumentNullException e)
{
    Console.WriteLine("Errore null: " + e.Message);
}

//Dato che possiamo inserire più catch io posso inserire anche un catch che gestisce tutte le altre eccezioni
//non gestite nei catch più specifici.
//Questo è possibile grazie alla gerarchia delle eccezioni, tutte le eccezioni ereditano una classe
//padre chiamata Exception

try
{
    int n = int.Parse(null);
}
catch(Exception e)
{
    Console.WriteLine("Errore generico: " + e.Message);
}