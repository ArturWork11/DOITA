/*
   Liste: array dinamici
   
    definizione: una lista è un'insieme ordinato di elementi dello stesso tipo di dimensione VARIABILE
    --> quando creo una lista non devo obbligatoriamente indicare la sua dimensione perchè si aggiorna in automatico
    per cui posso togliere e/o aggiungere elementi in qualunque momento

    dichiarazione: 
    List<tipo> nomeLista;

    inizializzazione:
    nomeLista = new List<tipo>();
 
 */

// Dichiaro una lista che conterrà stringhe
List<string> parole;
// Inizializzo la lista
parole = new List<string>(); //creo un oggetto di tipo List -->  NEW vuol dire che sto usando un metodo, costruttore, che usa l'oggetto
parole = new(); //inizializzo su una riga

// Dichiaro e inizializzo su una riga 
List<string> parole2 = new List<string>();
List<string> parole3 = new(); // versione abbreviata

// Come riempio una lista
// nomeLista.Add(valore/variabile);
parole.Add("ciao"); //la lista è in grado di settare in automatico il valore di indice della cella a cui assegnare il valore appena aggiunto
// Il primo valore di indice disponibile è quello che verra preso in considerazione
parole.Add("telecomando");
parole.Add("ciao");


// Rimuovo un elemento della lista
// Rimuovo per valore
parole.Remove("ciao");//elimina il primo elemento che ha lo stesso contenuto indicato tra le parentesi (), nel nostro caso elimina il primo "ciao"
// Gli altri elementi scorrono per evitare di lasciare una cella vuota, per cui "telecomando" si troverà nella cella con indice 0, il secondo "ciao" nella cella 1

// Rimuovere un valore/elemento indicando l'indice a cui si trova
parole.RemoveAt(0);//elimina l'elemento che si trova nella cella con indice 0, nel nostro caso elimina "telecomando", per cui nella lista ci sarà una sola cella

// Rimuovo tutti gli elementi da una lista, la svuoto
parole.Clear();

// Riaggiungo una parola alla lista
parole.Add("ciao");
// Rimuove tutte le parole con il valore tra le parentesi di parole.Contains
parole.RemoveAll(parole => parole.Contains("ciao"));

// Modifico un elemento già esistente
// Cambio il valore della prima cella, quella con indice 0
parole[0] = "tazza";
parole.Count(); // Determina la lunghezza della lista

bool trovato = parole.Contains("tazza"); //ritorna vero o falso se ha trovato una corrispondenza