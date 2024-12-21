using EsercizioConcessionaria;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioConcessionaria
{
    internal class DAOProdotti : IDAO
    {
        private IDatabase db;
        private DAOProdotti()
        {
            db = new Database("Concessionaria");
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
            return db.Update($"INSERT INTO Prodotti (categoria, marca, modello, affittabile, annoImmatricolazione, consumoMedioAKM, capienzaSerbatoio)" +
                             $"VALUES " +
                             $"('{((Prodotto)e).Categoria.Replace("'","''")}', " +
                             $" '{((Prodotto)e).Marca.Replace("'", "''")}', " +
                             $" '{((Prodotto)e).Modello.Replace("'", "''")}'," +
                             $"  {(((Prodotto)e).Affittabile ? 1 : 0)}, " +
                             $"  {((Prodotto)e).AnnoImmatricolazione}, " +
                             $"  {((Prodotto)e).ConsumoMedioAKM}," +
                             $"  {((Prodotto)e).CapienzaSerbatoio}), ");
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Prodotti WHERE id = {id};");
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Prodotti WHERE id = {id};");
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
            List<Entity> list = new List<Entity>();
            var righe = db.Read("SELECT * FROM Prodotti;");
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
                             $"categoria = '{((Prodotto)e).Categoria.Replace("'", "''")}', " +
                             $"marca = '{((Prodotto)e).Marca.Replace("'", "''")}', " +
                             $"modello = '{((Prodotto)e).Modello.Replace("'", "''")}', " +
                             $"affittabile = {(((Prodotto)e).Affittabile ? 1 : 0)}, " +
                             $"annoImmatricolazione = {((Prodotto)e).AnnoImmatricolazione}, " +
                             $"consumoMedioAKM = {((Prodotto)e).ConsumoMedioAKM}, " +
                             $"capienzaSerbatoio = {((Prodotto)e).CapienzaSerbatoio} " +
                             $"WHERE id = {e.Id}");
        }

        public List<Prodotto> ListaProdottiVecchi()
        {
            
            List<Prodotto> list = new List<Prodotto>();
            string query = @"SELECT * ,YEAR(GETDATE()) - Prodotti.annoImmatricolazione AS anniVeicolo FROM Prodotti WHERE YEAR(GETDATE()) - Prodotti.annoImmatricolazione > 8";
            var righe = db.Read(query);
            foreach (var riga in righe)
            {
                Entity e = new Prodotto()
                    ;
                e.FromDictionary(riga);
              
                list.Add((Prodotto)e);
                
            }
            foreach (var riga in list)
                Console.WriteLine(riga.ToString());

            return list;
        }

        public string MaxDistanza()
        {
            string schede = "";
            var righe = db.Read("SELECT * FROM Prodotti");
            Console.WriteLine("Inserisci la distanza minima percorribile dei veicoli che vuoi vedere");
            double distanzaUtente = double.Parse(Console.ReadLine());
            foreach (var riga in righe)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);
               

                if(((Prodotto)e).KMPercorribili() > distanzaUtente)
                {
                    schede += e.ToString();
                }
            }

            Console.WriteLine(schede);
            return schede;
        }

        public List<Prodotto> Cerca(string categoria)
        {

            List<Prodotto> list = new List<Prodotto>();
            Console.WriteLine("Inserisci la categoria dei prodotti che vuoi vedere");
            categoria = Console.ReadLine();
            var righe = db.Read($"SELECT * FROM Prodotti WHERE categoria = '{categoria}'");
            foreach (var riga in righe)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);

                list.Add((Prodotto)e);
                
            }

            foreach (var riga in list)
                 Console.WriteLine(riga.ToString()); 

            return list;
        }

        public Dictionary<string,int> Frequenza()
        {
            Dictionary<string, int> frequenza = new();
            var righe = db.Read($"SELECT Prodotti.categoria, COUNT(id) AS prodottiPerCategoria FROM Prodotti  GROUP BY Prodotti.categoria");
            foreach (var riga in righe)
            {
                string categoria = riga["categoria"];
                int prodottiPerCategoria = int.Parse(riga["prodottipercategoria"]);

                frequenza[categoria] = prodottiPerCategoria ;
            }

            Console.WriteLine($"Categoria   ||  Prodotti per categoria ") ;
            foreach(var riga in frequenza)
                Console.WriteLine($"{riga.Key}        ||  {riga.Value}    ");

            return frequenza;
        }

        public string CercaPerMarca(string marca)
        {
            string ricerca = "";
            Console.WriteLine("Inserisci la marca dei prodotti che vuoi vedere");
            marca = Console.ReadLine();
            var righe = db.Read($"SELECT * FROM Prodotti WHERE marca = '{marca}';");
            foreach (var riga in righe)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);

                ricerca += e.ToString();
            }

            Console.WriteLine(ricerca);
            return ricerca;
        }

        public string StampaListe(List<Prodotto> array)
        {
            string stampaListe = "";
            array = new List<Prodotto>();
            var righe = db.Read("SELECT * FROM Prodotti ORDER BY Categoria, Marca;");
            foreach (var riga in righe)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);

                array.Add((Prodotto)e);
                
            }

            stampaListe += "----- Lista Prodotti Ordinata -----\n " +
                           "Categoria | Marca | Modello | Anno | Consumo | Capienza Serbatoio\n" +
                           "---------------------------------------------------------------\n";         

            foreach (var prodotto in array)
            {
                stampaListe += prodotto.Categoria + " | " +
                              prodotto.Marca + " | " +
                              prodotto.Modello + " | " +
                              prodotto.AnnoImmatricolazione + " | " +
                              prodotto.ConsumoMedioAKM + " | " +
                              prodotto.CapienzaSerbatoio + "\n";
            }

            stampaListe += "---------------------------------------------------------------\n";
            
            Console.WriteLine(stampaListe);
            return stampaListe;
        }

        public List<Prodotto> TrovaSoluzione(double budgetMensile, int passeggeri)
        {
            Console.WriteLine("Inserisci il tuo budget Mensile");
            budgetMensile = double.Parse(Console.ReadLine());
            Console.WriteLine("Quanti passeggeri deve avere il veicolo?");
            passeggeri = int.Parse(Console.ReadLine());
            var righe = db.Read("SELECT * from Prodotti WHERE affittabile = 1;");
            List<Prodotto> autoNolo = new();
            foreach (var riga in righe)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);

                bool compatibilePasseggeri = false;

                if (((Prodotto)e).Categoria.ToLower() == "moto" && passeggeri <= 2)  
                {
                    compatibilePasseggeri = true;
                }
                else if (((Prodotto)e).Categoria.ToLower() == "macchina" && passeggeri <= 5)  
                {
                    compatibilePasseggeri = true;
                }
                else if (((Prodotto)e).Categoria.ToLower() == "camion" && passeggeri <= 3)  
                {
                    compatibilePasseggeri = true;
                }
                else if (((Prodotto)e).Categoria.ToLower() == "furgone" && passeggeri <= 9) 
                {
                    compatibilePasseggeri = true;
                }
                else if (((Prodotto)e).Categoria.ToLower() == "quad" && passeggeri == 1)  
                {
                    compatibilePasseggeri = true;
                }

                if (compatibilePasseggeri && ((Prodotto)e).AffittoMensile() <= budgetMensile)
                {
                    autoNolo.Add(((Prodotto)e)); 
                }

            }
            foreach(var riga in autoNolo) 
                Console.WriteLine(riga.ToString());

            return autoNolo;
        }

        public List<Prodotto> InOrdine()
        {
            var righe = db.Read("SELECT * FROM Prodotti");
            List<Prodotto> ordinePrezzo = new();
            foreach(var riga in righe)
            {
                Entity e = new Prodotto();
                e.FromDictionary(riga);

                ordinePrezzo.Add((Prodotto)e);
            }

            ordinePrezzo = ordinePrezzo.OrderBy(p => p.Prezzo()).ToList();

            foreach (var riga in ordinePrezzo)
                Console.WriteLine(riga.ToString());

            return ordinePrezzo;
        }
    }
}
                           