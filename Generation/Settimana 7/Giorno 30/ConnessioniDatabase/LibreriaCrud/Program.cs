using LibreriaCrud;

// Stampo la lista completa


foreach (Entity ent in DAOLibri.GetInstance().Read())
    Console.WriteLine(ent.ToString());

// Cerco un id specifico
Console.WriteLine(DAOLibri.GetInstance().Find(3).ToString());

// Inserisco un nuovo elemento
Entity ex = new Libro { Titolo="Carry", Autore="King", Genere="Horror", Anno_pubblicazione=1990 };
Console.WriteLine(DAOLibri.GetInstance().Create(ex));

// Modifica di un elemento
Entity e = DAOLibri.GetInstance().Find(16);
((Libro)e).Genere = "Storico";

Console.WriteLine(DAOLibri.GetInstance().Update(e));

foreach(Entity en  in DAOLibri.GetInstance().Read())
    Console.WriteLine(en.ToString());

// Eliminare un'elemento
Console.WriteLine(DAOLibri.GetInstance().Delete(10));
foreach (Entity entity in DAOLibri.GetInstance().Read())
    Console.WriteLine(entity.ToString());