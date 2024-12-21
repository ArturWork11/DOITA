using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace ImperoCRUD
{
    internal class DAOImperatori : IDAO
    {
        private IDatabase db;
        private DAOImperatori()
        {
            db = new Database("ImperoRomano");
        }

        private static DAOImperatori instance = null;

        public static DAOImperatori GetInstance() 
        { 
            if (instance == null) 
                instance = new DAOImperatori();
            return instance;
        }
        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Imperatori (nome, dinastia, dob, dod, assassinio) " +
                             $"VALUES " +
                             $"('{((Imperatore)e).Nome.Replace("'", "''")}'," +
                             $"'{((Imperatore)e).Dinastia.Replace("'", "''")}'," +
                             $"'{((Imperatore)e).Dob.ToString("yyyy-MM-dd")}'," +
                             $"'{((Imperatore)e).Dod.ToString("yyyy-MM-dd")}'," +
                             $" {(((Imperatore)e).Assassinio ? 1 : 0)});");
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Imperatori WHERE id = {id};");
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Libri WHERE id = {id}");

            if (riga != null)
            {
            Entity e = new Imperatore();
                e.FromDictionary(riga);

            return e;

            }
            else
            {
                return null;
            }
        }

        public List<Entity> Read()
        {
            List<Entity> ris = new();

            var righe = db.Read("SELECT * FROM Imperatori;");

            foreach(var riga in righe)
            {
                Entity e = new Imperatore();
                e.FromDictionary(riga);

                ris.Add(e);
            }

            return ris;
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Imperatori SET  " + 
                            $"nome = '{((Imperatore)e).Nome.Replace("'", "''")}'," + 
                            $"dinastia = '{((Imperatore)e).Dinastia.Replace("'", "''")}', " + 
                            $"dob = '{((Imperatore)e).Dob.ToString("yyyy-MM-dd")}', " + 
                            $"dod = '{((Imperatore)e).Dod.ToString("yyyy-MM-dd")}' " +  
                            $"assassinio = {(((Imperatore)e).Assassinio ? 1 : 0)} " +  
                            $"WHERE id = {e.Id}; ");
        }
    }
}
