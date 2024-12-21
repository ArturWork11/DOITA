using EsercizioConnessione01;

foreach (Entity ent in DAOProdotti.GetInstance().Read())
    Console.WriteLine(ent.ToString());

// Cerco un id specifico
Console.WriteLine(DAOProdotti.GetInstance().Find(3).ToString());

// Inserisco un nuovo elemento
Entity ex = new Prodotto { Nome="Monitor", Categoria="Elettronica", Marca="Asus", Quantita=10, DataInserimento = DateTime.Today };
Console.WriteLine(DAOProdotti.GetInstance().Create(ex));

// Modifica di un elemento
/*
Entity e = DAOProdotti.GetInstance().Find(16);
(Prodotto)e).Marca = "Wolf";

Console.WriteLine(DAOProdotti.GetInstance().Update(e)); 

foreach (Entity en in DAOProdotti.GetInstance().Read())
    Console.WriteLine(en.ToString());
*/
// Eliminare un'elemento
Console.WriteLine(DAOProdotti.GetInstance().Delete(10));
foreach (Entity entity in DAOProdotti.GetInstance().Read())
    Console.WriteLine(entity.ToString());
