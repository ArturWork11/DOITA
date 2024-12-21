using ImperoCRUD;
using Utility01;

//foreach (Entity e in DAOImperatori.GetInstance().Read())
//{
//    Console.WriteLine(e.ToString());
//}

/* Entity e = new Imperatore {Nome = "Commodo", Dinastia = "Flavia", Dob=DateTime.Parse("0161-08-31"), Dod = DateTime.Parse("0192-12-31"), Assassinio=true };
    Console.WriteLine(DAOImperatori.GetInstance().Create(e)); */
/*
Entity ex = DAOImperatori.GetInstance().Find(10);
((Imperatore)ex).Dob = DateTime.Parse("0030-10-23");
    Console.WriteLine(DAOImperatori.GetInstance().Update(ex)); */

// Console.WriteLine(DAOImperatori.GetInstance().Delete(17));


//foreach (Entity ex in DAOBattaglie.GetInstance().Read())
//    Console.WriteLine(ex.ToString()); 

Imperatore i = (Imperatore)DAOImperatori.GetInstance().Find(1);
Entity e = new Battaglia { Nemico = "Asterix", Data_battaglia = DateTime.Parse("0200-02-02"), Vincitore = false, Luogo = "Gallia", Imperatore = i };
Console.WriteLine(DAOBattaglie.GetInstance().Create(e));