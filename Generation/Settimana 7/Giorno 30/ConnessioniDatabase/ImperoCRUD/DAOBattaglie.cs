using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace ImperoCRUD
{
    
    internal class DAOBattaglie : IDAO
    {
        private IDatabase db;
        private DAOBattaglie()
        {
            db = new Database("ImperoRomano");
        }

        private static DAOBattaglie instance = null;

        public static DAOBattaglie GetInstance()
        {
            if (instance == null)
                instance = new DAOBattaglie();
            return instance;
        }
        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Battaglie " +
                             $"(nemico, data_battaglia, vincitore, luogo, idImperatore)" +
                             $"VALUES " +
                             $"('{((Battaglia)e).Nemico.Replace("'", "''")}'," +
                             $" '{((Battaglia)e).Data_battaglia.ToString("yyyy-MM-dd")}'," +
                             $"  {(((Battaglia)e).Vincitore ? 1 : 0)}," +
                             $" '{((Battaglia)e).Luogo.Replace("'", "''")}'," +
                             $"  {(((Battaglia)e).Imperatore != null ? ((Battaglia)e).Imperatore.Id : "null")};");
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Battaglie WHERE id = {id}");
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Battaglie WHERE id = {id}");

            if (riga != null)
            {
                Entity e = new Battaglia();
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
            List<Entity> ris = new List<Entity>();
            var righe = db.Read("SELECT * FROM Battaglie;");

            foreach (var riga in righe)
            {
                Entity e = new Battaglia();
                e.FromDictionary(riga);
                ris.Add(e);
            }
            return ris;
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Battaglie SET  " + 
                            $"nemico = '{((Battaglia)e).Nemico.Replace("'", "''")}'," + 
                            $"data_battaglia = '{((Battaglia)e).Data_battaglia.ToString("yyyy-MM-dd")}', " + 
                            $"vincitore = {(((Battaglia)e).Vincitore ? 1 : 0)}, " + 
                            $"luogo = '{((Battaglia)e).Luogo.Replace("'","''")}', " + 
                            $"idImperatore = {(((Battaglia)e).Imperatore != null ? ((Battaglia)e).Imperatore.Id : "null")} " +
                            $"WHERE id = {e.Id}; ");
        }
    }
}
