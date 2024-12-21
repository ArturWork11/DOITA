using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class DAOProdotti : IDAO
    {
        private IDatabase db;
        private DAOProdotti()
        {
            db = new Database("GenerationEcommerce");
        }

        private static DAOProdotti instance = null;
        public static DAOProdotti GetInstance()
        {
            if (instance == null)
                instance = new DAOProdotti();
            return instance;
        }
        public bool Create(Entity e)
        {
            

            return db.Update($"INSERT INTO Prodotti (nome,quantitaMagazzino,dataCambio,dataScadenza,categoria,prezzo) VALUES" +
                   $"('{((Prodotto)e).Nome.Replace("'", "''")}'," +
                   $"  {((Prodotto)e).QuantitaMagazzino}," +
                   $" '{((Prodotto)e).DataCambio.ToString("yyyy-MM-dd")}'," +
                   $" '{((Prodotto)e).DataScadenza.ToString("yyyy-MM-dd")}'," +
                   $" '{((Prodotto)e).Categoria.Replace("'", "''")}'," +
                   $"  {((Prodotto)e).Prezzo});");
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE  FROM Prodotti WHERE id = {id};");
        }

        public Entity Find(int id)
        {
            var riga =  db.ReadOne($"SELECT * FROM Prodotti WHERE id = {id};");

            if (riga != null)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);
                return e;
            }
            else
                return null;
            
        }

        public List<Entity> Read()
        {
            List<Entity> list = new();
            var righe = db.Read($"SELECT * FROM Prodotti;");

            foreach (var riga in righe) 
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);

                list.Add(e);
            }
            return list;
        }

        public bool Update(Entity e)
        {


            return db.Update($"UPDATE Prodotti SET " +
                             $"nome = '{((Prodotto)e).Nome.Replace("'","''")}'," + 
                             $"quantitaMagazzino = {((Prodotto)e).QuantitaMagazzino}," + 
                             $"dataCambio = '{((Prodotto)e).DataCambio.ToString("yyyy-MM-dd")}'," + 
                             $"dataScadenza = '{((Prodotto)e).DataScadenza.ToString("yyyy-MM-dd")}'," + 
                             $"categoria = '{((Prodotto)e).Categoria.Replace("'","''")}'," + 
                             $"prezzo = {((Prodotto)e).Prezzo} " + 
                             $"WHERE id = {e.Id};");
                             
        }
    }
}
