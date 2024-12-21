using Polimorfismo;

Persona persona = new Persona("Persona1", "CognomeP1", "23-08-1998");
Console.WriteLine(persona.Scheda());

Studente studente = new Studente("Studente1", "CognomeS1", "12-03-2018", "1A", null);
Console.WriteLine(studente.Scheda());


Docente docente = new Docente("Docente1", "CognomeD1", "09-09-1980", "storia", true);
Console.WriteLine(docente.Scheda());

//il POLIMORFISMO di OGGETTI permette ad un oggetto di avere forme diverse se il rapporto tra le forme ha un senso logico
//dettato dal rapporto di parentela
//Tipo nomeOggetto = new Tipo(); 
//  TipoFormale nomeOggetto = new TipoConcreto();
// Tipo FOrmale è il tipo con cui quell'oggetto viene visto dal programma -> tipo della superclasse
// Tipo Concreto è il tipo con cui quell'oggetto viene creato -> tipo sottoclasse
//Studente s = new Persona(); -> non è possibile scrivere questo comando

Persona p = new Studente("Studente2", "Cognome2", "14-07-2016", "2C", null);
Console.WriteLine(p.Scheda());


Persona p1 = new Docente("Docente2", "CognomeD2", "23-04-2000", "matematica", false);
Console.WriteLine(p1.Scheda());

List<Persona> persone = new List<Persona>();
persone.Add(p);
persone.Add(p1);


