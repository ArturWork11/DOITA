using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EsercizioConnessione01
{
    internal class DAOProdotti
    {
        private Database db;

        private DAOProdotti()
        {
            db = new Database("Ecommerce");
        }

        private static DAOProdotti instance = null;

        public static DAOProdotti GetInstance()
        {
            if (instance == null)
                instance = new DAOProdotti();
            return instance;
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Prodotti SET + " +
                             $"nome = '{((Prodotto)e).Nome.Replace("'", "''")}'," +
                             $"categoria = '{((Prodotto)e).Categoria.Replace("'", "''")}'," +
                             $"marca = '{((Prodotto)e).Marca.Replace("'", "''")}'," +
                             $"quantita = {((Prodotto)e).Quantita}," +
                             $"dataInserimento = '{((Prodotto)e).DataInserimento}'," +
                             $"WHERE id = {e.Id}; ");
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Prodotti WHERE id = {id}");
        }
        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Prodotti (nome,categoria,marca,quantita,dataInserimento) VALUES " +
                             $"('{((Prodotto)e).Nome.Replace("'", "''")}'," +
                             $"'{((Prodotto)e).Categoria.Replace("'", "''")}'," +
                             $"'{((Prodotto)e).Marca.Replace("'", "''")}'," +
                             $"{((Prodotto)e).Quantita}," +
                             $"'{((Prodotto)e).DataInserimento}');");

        }
        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> rows = db.Read("SELECT * FROM Prodotti");

            foreach (Dictionary<string, string> row in rows)
            {
                Entity e = new Prodotto();
                e.FromDictionary(row);

                ris.Add(e);
            }
            return ris;
        }

        public Entity Find(int id)
        {
            var row = db.ReadOne($"SELECT * FROM Prodotti WHERE id = {id}");

            if (row == null)
            {
                Entity e = new Prodotto();
                e.FromDictionary(row);
                return e;
            }
            else
            {
                return null;
            }
        }

        public List<Entity> ListByBrand(string userChoice)
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> rows = db.Read($"SELECT * FROM Prodotti WHERE marca = {userChoice}");

            foreach (Dictionary<string, string> row in rows)
            {
                Entity e = new Prodotto();
                e.FromDictionary(row);

                ris.Add(e);
            }
            return ris;
        }

        public List<Entity> ListByCategory(string userChoice)
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> rows = db.Read($"SELECT * FROM Prodotti WHERE categoria = {userChoice}");

            foreach (Dictionary<string, string> row in rows)
            {
                Entity e = new Prodotto();
                e.FromDictionary(row);

                ris.Add(e);
            }
            return ris;
        }

        public List<Entity> ListByQuantity(int userChoice,string lessOrMore)
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> rows = db.Read($"SELECT * FROM Prodotti WHERE quantita {lessOrMore} {userChoice}");

            foreach (Dictionary<string, string> row in rows)
            {
                Entity e = new Prodotto();
                e.FromDictionary(row);

                ris.Add(e);
            }
            return ris;
        }
    }
}
