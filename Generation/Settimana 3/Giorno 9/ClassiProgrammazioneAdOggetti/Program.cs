// Gli oggetti sono istanze delle classi
// Es. una persona è un'istanza della classe esseri umani, un triangolo è un'istanza della classe forme geometriche
// Le caratteristiche che definiscono un'oggetto si chiamano campi (field)

//C# è un linguaggio orientato agli oggetti (OOP: Object Oriented Programming)
//Questo ci permette di trasporre e descrivere cose della vita reale nel codice
//Gli oggetti sono descritti dalla propria classe, la classe è la struttura , il telaio o ancora lo scheletro sulla quale gli oggetti vengono poi costruiti
//Nel codice si possono avere tutte le classi che vogliamo
//L'oggetto di una specifica classe altro non è che una sua istanza.

//Esempio: Vogliamo rappresentare nel codice  le persone, per farlo , creo una classe denominata Persona
//Nella classe andrò a descrivere i campi (quindi le caratteristiche generali che tutte le persone hanno)

//Per creare una nuova classe, devo creare un nuovo file di C# che ne contenga la definizione 
//Tasto destro sul nome del progetto in Esplora Soluzioni > Aggiungi > Classe.. > Seleziono ancora Classe e do un nome > aggiungi (tasto in basso a destra)

using ClassiProgrammazioneAdOggetti;

Persona p1 = new Persona();
p1.nome = "Mario";
p1.cognome = "Rossi";
p1.eta = 34;

Persona p2 = new Persona();
p2.nome = "luigi";
p2.cognome = "Verdi";
p2.eta = 33;

Console.WriteLine("Nome Persona 2:" + p2.nome);
Console.WriteLine("Scheda Persona 2\n" + p2.Scheda());