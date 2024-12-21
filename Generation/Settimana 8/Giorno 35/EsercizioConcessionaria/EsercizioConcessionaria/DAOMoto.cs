using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioConcessionaria
{
    internal class DAOMoto : IDAO
    {
        private IDatabase db;
        private DAOMoto()
        {
            db = new Database("Concessionaria");
        }
        private static DAOMoto instance = null;
        public static DAOMoto GetInstance()
        {
            if (instance == null)
                instance = new DAOMoto();
            return instance;
        }
        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Moto (id,passeggeri) " +
                             $"VALUES " +
                             $"({(((Moto)e).Id != null ? ((Moto)e).Id : null)}, " +
                             $" {(((Moto)e).Passeggeri ? 1 : 0)} );");
                                
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Moto WHERE id = {id};");
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Moto WHERE id = {id};");
            if (riga !=  null)
            {
                Entity e = new Moto();
                e.FromDictionary(riga);

                return e;
            }
            else
                return null;
        }

        public List<Entity> Read()
        {
            List<Entity> list = new List<Entity>();
            var righe = db.Read("SELECT * FROM Moto;");
            foreach (var riga in righe)
            {
                Entity e = new Moto();
                e.FromDictionary(riga);

                list.Add(e);
            }
            return list;
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Moto SET " +
                             $"id = {(((Moto)e).Prodotto != null ? ((Moto)e).Prodotto.Id : "null")}," +
                             $"passeggeri = {(((Moto)e).Passeggeri ? 1 : 0)} " +
                             $"WHERE id = {e.Id};");
        }

        public List<Moto> Sportive()
        {
            List<Moto> list = new List<Moto>();
            var righe = db.Read($"SELECT * FROM Prodotti WHERE categoria = 'moto';");
            foreach (var riga in righe)
            {
                Entity e = new Moto();
                e.FromDictionary(riga);
                if (((Moto)e).Passeggeri == false)
                {
                    list.Add((Moto)e);
                }
            }
            foreach (var riga in list)
                    Console.WriteLine(riga.ToString());

            return list;
        }
    }
}
