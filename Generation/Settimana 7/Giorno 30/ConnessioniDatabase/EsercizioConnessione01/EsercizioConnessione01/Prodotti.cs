using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioConnessione01
{
    internal class Prodotti
    {
        private static DAOProdotti Dao = DAOProdotti.GetInstance();

        public Prodotti() 
        {

        }

        public static string AllProducts()
        {
            string ris = "";
            foreach (Entity e in Dao.Read())
            {
                ris += e.ToString();
            }
            return ris;
        }
    }
}
