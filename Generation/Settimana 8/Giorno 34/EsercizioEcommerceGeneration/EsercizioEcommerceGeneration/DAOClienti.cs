using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class DAOClienti : IDAO
    {
        private IDatabase db;
        private DAOClienti()
        {
            db = new Database("GenerationEcommerce");
        }

        private static DAOClienti instance = null;

        public static DAOClienti GetInstance()
        {
            if (instance == null)
                instance = new DAOClienti();
            return instance;
        }
        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Cliente (username, dataIscrizione, maggiorenne) VALUES  " + 
                             $"('{((Cliente)e).Username.Replace("'","''")}'," + 
                             $" '{((Cliente)e).DataIscrizione.ToString("yyyy-MM-dd")}'," + 
                             $"  {(((Cliente)e).Maggiorenne ? 1 : 0)});"); 
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Cliente WHERE id = {id};");
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Cliente WHERE id = {id};");

            if (riga != null)
            {
                Entity e = new Cliente();
                e.FromDictionary(riga);
                return e;
            }
            else
                return null;
        }

        public List<Entity> Read()
        {
            List<Entity> list = new();

            var righe = db.Read($"SELECT * FROM Cliente;");
            foreach (var riga in righe)
            {
                Entity e = new Cliente();
                e.FromDictionary(riga);

                list.Add(e);
            }
            return list;
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Cliente SET " + 
                             $"username = '{((Cliente)e).Username.Replace("'","''")}'," + 
                             $"dataIscrizione = '{((Cliente)e).DataIscrizione.ToString("yyyy-MM-dd")}'," + 
                             $"maggiorenne = '{(((Cliente)e).Maggiorenne ? 1 : 0)} " +  
                             $"WHERE id = {e.Id};");

        }
    }
}
