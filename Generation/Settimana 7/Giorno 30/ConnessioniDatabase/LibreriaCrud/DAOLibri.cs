using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCrud
{
    internal class DAOLibri
    {
        private Database db;

        // PATTERN: è una soluzione a un problema ricorrente.
        #region SINGLETON
        // Singleton ->  impedisce la creazione di oggetti copie
        // Per usarlo servono 3 passaggi:
        //     1) Privatizzare il costruttore 
        //     2) Creare un campo statico che restituisca l'oggetto in questione
        //     3) Creare un metodo statico che gestisca la chiamata al costruttore
        private DAOLibri()
        {
            db = new Database("LibreriaDOITA14");
        }

        private static DAOLibri instance = null;

        public static DAOLibri GetInstance()
        {
            if (instance == null)
                instance = new DAOLibri();
            return instance;
        }
        #endregion

        #region CRUD
        // CRUD -> Create,Read,Update,Delete
        // Ogni Classe DAO avrà sempre i metodi del CRUD perchè ogni classe DAO deve permettere di gestire
        // a 360 gradi i record della tabella anche senza accedere fisicamente al server.

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Libri WHERE id = {id}");
            
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Libri SET  " + 
                             $"titolo = '{((Libro)e).Titolo.Replace("'","''")}'," + 
                             $"autore = '{((Libro)e).Autore.Replace("'", "''")}', " + 
                             $"genere = '{((Libro)e).Genere.Replace("'", "''")}', " + 
                             $"anno_pubblicazione = {((Libro)e).Anno_pubblicazione} " + 
                             $"WHERE id = {e.Id}; ");
        }

        public bool Create(Entity e) 
        {
            return db.Update($"INSERT INTO Libri (titolo, autore, genere, anno_pubblicazione) VALUES " +
                             $"('{((Libro)e).Titolo.Replace("'", "''")}'," +
                             $" '{((Libro)e).Autore.Replace("'", "''")}', " +
                             $" '{((Libro)e).Genere.Replace("'", "''")}', " +
                             $"  {((Libro)e).Anno_pubblicazione});");
        }

        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> righe = db.Read("SELECT * FROM Libri;");

            foreach (Dictionary<string, string> riga in righe)
            {
                Entity e = new Libro();

                e.FromDictionary(riga);

                ris.Add(e);
            }

            return ris;
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Libri WHERE id = {id}");

            if (riga != null)
            {
                Entity e = new Libro();
                e.FromDictionary(riga);

                return e;
            }
            else
                return null;

        }
        #endregion
    }
}
