using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class DAOCarrello : IDAO
    {
        private IDatabase db;

        private DAOCarrello()
        {
            db = new Database("GenerationEcommerce");
        }

        private static DAOCarrello instance = null;

        public static DAOCarrello GetInstance()
        {
            if (instance == null)
                instance = new DAOCarrello();
            return instance;

        }
        public List<Entity> Read()
        {
            List<Entity> list = new List<Entity>();
           
            var righe = db.Read("SELECT * FROM Carrello;");
            foreach (var riga in righe) 
            {
                Entity e = new Carrello();
                e.FromDictionary(riga);

                list.Add(e);
            }
            return list;
        }

        public bool Delete(int id)
        {
           return db.Update($"DELETE FROM Carrello WHERE id = {id};");
        }

        public bool Update(Entity e)
        {
            return db.Update($"UPDATE Carrello SET " + 
                             $"idCliente = {((Carrello)e).Cliente}, " + 
                             $"idProdotto = {((Carrello)e).Prodotto}," + 
                             $"quantitaAcquisto = {((Carrello)e).QuantitaAcquisto};");
        }

        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Carrello (idCliente,idProdotto,quantitaAcquisto) VALUES " +
                             $"({((Carrello)e).Cliente}," + 
                             $" {((Carrello)e).Prodotto}," + 
                             $" {((Carrello)e).QuantitaAcquisto});");
        }

        public Entity Find(int id)
        {
             var riga = db.ReadOne($"SELECT * FROM Carrello WHERE id = {id};");
            if (riga != null)
            {
                Entity e = new Carrello();
                e.FromDictionary(riga);

                return e;
            }
            else
                return null;
            
        }

        

    }
}
