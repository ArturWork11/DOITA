//I dizionari sono delle strutture dati che permettono il salvatggio di elementi (valori) tramite delle chiavi.
//Quello che otteniamo quindi è una struttura composta di coppie chiave-valore
//le chiavi all'interno dei dizionari non possono ripetersi, possono comparire solo una volta e quindi sono uniche
//alla chiave posso associare un solo valore, cioè la stessa chiave non può restituire valori differenti.
//Lo stesso valore invece potrebbe essere associato a più chiavi differenti

/*
 * DICTIONARY<int, string>
 
 +---------+---------+
 |  CHIAVE | VALORE  |
 +---------+---------+
 !    5    | "Mario" |
 +---------+---------+
 |    2    | "Luigi" |
 +---------+---------+
 |    1    | "Franca"!
 +---------+---------+
 
 
 
 */

//Dichiarazione e inizializzazione di un dizionario (in questo caso con chiave intera e valore stringa)
Dictionary<int, string> dizionario = new Dictionary<int, string>();

//Per aggiungere una chiave e un valore asssociato alla chiave posso utilizzare .Add(chiave ,valore) oppure [chiave] = valore
//Se la chiave non esiste nel dizionario allora viene creata con il valore attuale associato,
//se invece la chiave esisteva già ed aveva un valore associato allora viene sostituito il valore vecchio con quello nuovo

dizionario.Add(5, "Mario");
dizionario[5] = "Mario";
dizionario[2] = "Luigi";
dizionario[1] = "Franca";

//Per leggere un valore conoscendone la chiave posso utilizzare
Console.WriteLine(dizionario[5]);
Console.WriteLine(dizionario[7]); //Se la chiave non esiste mi viene lanciata la KeyNotFoundException

//il  metodo .ContainsKey(chiave) mi dice se la chiave è presente oppure no
Console.WriteLine(dizionario.ContainsKey(3));

//.Remove(key) elimina la coppia chiave-valore data la chiave
dizionario.Remove(3);

//Altri metodi utili:
//.Count Restituisce il numero di coppie chiave-valore presenti  nel dizionario
dizionario.Count;
//.Clear() Ripulisce il dizionario da tutte le coppie chiave-valore 
dizionario.Clear();
//.TryGetValue() 
dizionario.TryGetValue();

if (dizionario.TryGetValue(2, out string valore))
{
    Console.WriteLine("Ho trovato il valore" + valore);
}


Dictionary<int, string>.KeyCollection keys = dizionario.Keys;

foreach (int key in dizionario.Keys)
{
    Console.WriteLine("Chiave: " + key + "Valore: " + dizionario[key]);
}

foreach (string value in dizionario.Values)
{
    Console.WriteLine($"Valore: {value}");
}