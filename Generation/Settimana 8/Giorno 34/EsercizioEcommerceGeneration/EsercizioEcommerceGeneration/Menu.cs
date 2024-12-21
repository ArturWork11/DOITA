using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class Menu
    {
        private DAOClienti daoC = DAOClienti.GetInstance();
        private DAOProdotti daoP = DAOProdotti.GetInstance();
        private IDatabase db;

        private Menu()
        {
            db = new Database("GenerationEcommerce");
        }

        private static Menu instance = null;

        public static Menu GetInstance()
        {
            if (instance == null)
                instance = new Menu();
            return instance;

        }
        public static void MenuEcommerce()
        {
                string digit = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto nell'Ecommerce di generation, digita: \n " +
                                  "1.  Per vedere il cliente che ha speso maggiormente sul nostro sito (il nostro spender) \n " +
                                  "2.  Per vedere il nostro prodotto di tendenza! \n " +
                                  "3.  Per visualizzare i/il prodotto/i prossimi alla scadenza \n " +
                                  "4.  Per vedere tutti i clienti \n " +
                                  "5.  Per vedere tutti i prodotti \n " +
                                  "6.  Per vedere tutti gli ordini \n " +
                                  "7.  Per Modificare un dato a scelta di un cliente \n " +
                                  "8.  Per Eliminare un cliente \n " +
                                  "9.  Per Trovare un cliente \n " +
                                  "10. Per Creare un nuovo cliente");
                digit = Console.ReadLine();
                switch (digit)
                {
                    case "1":
                        Spender();
                        break;
                    case "2":
                        ProdottoDiTendenza();
                        break;
                    case "3":
                        ProdottiDaSostituire();
                        break;
                    case "4":
                        TuttiIClienti();
                        break;
                    case "5":
                        TuttiIProdotti();
                        break;
                    case "6":
                        TuttiGliOrdini();
                        break;
                    case "7":
                        ModificaDatoCliente();
                        break;
                    case "8":
                        EliminaCliente();
                        break;
                    case "9":
                        TrovaCliente();
                        break;
                    case "10":
                        CreaCliente();
                        break;
                    case "0":
                        Console.WriteLine("Grazie e alla prossima!");
                        break;
                    default:
                        break;
                }
                if (digit != "0")
                {
                    Console.WriteLine("Premi un qualsiasi tasto se desideri fare altro, altrimenti premi 0 per fermare il programma");
                    digit = Console.ReadLine();
                    if (digit == "0") 
                        Console.WriteLine("Grazie e alla prossima!");
                }
            } while (digit != "0");
        }

        public static void Spender()
        {
            var db = new Database("GenerationEcommerce");
            string query = "SELECT TOP 1 \r\n       Cliente.username ,\r\n    SUM(Carrello.quantitaAcquisto * Prodotti.prezzo) AS TotaleSpeso\r\nFROM \r\n    Carrello\r\nINNER JOIN \r\n    Cliente ON Carrello.idCliente = Cliente.id\r\nINNER JOIN \r\n    Prodotti ON Carrello.idProdotto = Prodotti.id\r\nGROUP BY \r\n    Cliente.id, Cliente.username\r\nORDER BY \r\n    TotaleSpeso DESC;";

            var ris = db.Read(query);
            if (ris != null && ris.Count > 0)
            {
                Console.WriteLine("\nCliente che ha speso di più:");
                foreach (var riga in ris)
                {
                    Console.WriteLine($"Username:{riga["username"]}, Totale Speso:{double.Parse(riga["totalespeso"]):C}");
                }
            }
            else
            {
                Console.Write("Nessun cliente trovato.");
            }
        }

        public static void ProdottoDiTendenza()
        {
            var db = new Database("GenerationEcommerce");
            string query = "SELECT top 1 Prodotti.nome, sum(carrello.quantitaAcquisto) AS volteAcquistato\r\nFROM \r\n    Carrello\r\nINNER JOIN \r\n    Cliente ON Carrello.idCliente = Cliente.id\r\nINNER JOIN \r\n    Prodotti ON Carrello.idProdotto = Prodotti.id\r\nGROUP BY Prodotti.nome\r\norder by volteAcquistato desc;\r\n";

            var ris = db.Read(query);
            if (ris != null && ris.Count > 0)
            {
                Console.WriteLine("\nProdotto maggiormente acquistato:");
                foreach (var riga in ris)
                {
                    Console.WriteLine($"Prodotto:{riga["nome"]}, Volte che è stato acquistato:{int.Parse(riga["volteacquistato"])}");
                }
            }
            else
            {
                Console.Write("Nessun prodotto trovato.");
            }
        }

        public static void ProdottiDaSostituire()
        {
            var db = new Database("GenerationEcommerce");
            string query = "SELECT Prodotti.nome, dataScadenza, DATEDIFF(DAY,SYSDATETIME(),dataScadenza) as giorniAllaScadenza\r\nFROM Prodotti\r\nWHERE categoria = 'Alimentari' AND DATEDIFF(DAY,SYSDATETIME(),dataScadenza) <= 3";

            var ris = db.Read(query);
            if (ris != null && ris.Count > 0)
            {
                Console.WriteLine("\nProdotti prossimi alla scadenza:");
                foreach (var riga in ris)
                {

                    Console.WriteLine($"Prodotto:{riga["nome"]},Giorni rimanenti alla scadenza:{(int.Parse(riga["giorniallascadenza"]) <= 0 ? " Prodotto scaduto" : int.Parse(riga["giorniallascadenza"]))}");
                }
            }
            else
            {
                Console.Write("Nessun prodotto trovato.");
            }
        }

        public static void TuttiIClienti()
        {
            foreach (Entity e in DAOClienti.GetInstance().Read())
                Console.WriteLine(e.ToString());
        }

        public static void TuttiIProdotti()
        {
            foreach (Entity e in DAOProdotti.GetInstance().Read())
                Console.WriteLine(e.ToString());
        }

        public static void TuttiGliOrdini()
        {
            foreach (Entity e in DAOCarrello.GetInstance().Read())
                Console.WriteLine(e.ToString());
        }

        public static void ModificaDatoCliente() // Da risolvere , Object reference not set to an instance of an object
        {
            var DAOCliente = DAOClienti.GetInstance();
            Console.WriteLine("Digita il numero di id del cliente del quale si voglia modificare un dato");
            int id = int.Parse(Console.ReadLine());
            var cliente = DAOCliente.Find(id) as Cliente;
            Console.WriteLine("Quale dato si vuole modificare? digita: \n1. Per modificare l'username \n2. Per modificare la data di iscrizione \n3. Per modificare la maggiore età");
            string digit = Console.ReadLine();
            switch (digit)
            {
                case "1":
                    Console.WriteLine("inserisci il nuovo Username");
                    cliente.Username = Console.ReadLine();
                    break;
                case "2": Console.WriteLine("Inserisci la nuova data di iscrizione");
                    cliente.DataIscrizione = DateTime.Parse(Console.ReadLine());
                    break;
                case "3": Console.WriteLine("Inserisci l'età del cliente");
                    int scelta = int.Parse(Console.ReadLine());
              
                        if (scelta > 18)
                        {
                            cliente.Maggiorenne = true;
                        }
                        else if (scelta < 18)
                        {
                            cliente.Maggiorenne = false;
                        }
                        else
                            Console.WriteLine("inserimento non valido");
                    break;
                default: Console.WriteLine("Numero digitato non valido");
                    break;
            }
            
            Console.WriteLine(DAOClienti.GetInstance().Update(cliente));
        }

        public static void EliminaCliente() // Da risolvere , Object reference not set to an instance of an object
        {
            Console.WriteLine("Digita l'id del Cliente che vuoi eliminare");
            int id = int.Parse(Console.ReadLine());
            DAOClienti.GetInstance().Delete(id);
            if (DAOClienti.GetInstance().Delete(id))
            {
                Console.WriteLine("Cliente eliminato con successo");
            }
            else
            {
                Console.WriteLine("Errore nell'eliminare il cliente");
            }
        }

        public static void TrovaCliente() // Da risolvere, Object reference not set to an instance of an object
        {
            Console.WriteLine("Digita l'id del Cliente che vuoi visualizzare");
            int id = int.Parse(Console.ReadLine());
            Entity e = DAOClienti.GetInstance().Find(id);
            Console.WriteLine(e.ToString());


        }

        public static void CreaCliente()
        {
            bool maggiorenne;
            DateTime dataIscrizione;
            Console.WriteLine("Inserisci l'username del nuovo cliente");
            string username = Console.ReadLine();
            Console.WriteLine("Inserisci la data di iscrizione, digita Y se vuoi inserire la data di oggi,oppure digita a mano la data");
            string data = Console.ReadLine();
            if (data.ToUpper() == "Y")
            {
                 dataIscrizione = DateTime.Now;
            }
            else
            {
                dataIscrizione = DateTime.Parse(data);
            }
            Console.WriteLine("Inserisci l'età");
            int eta = int.Parse(Console.ReadLine());
            if (eta > 18)
                maggiorenne = true;
            else
                maggiorenne = false;
            Entity e = new Cliente { Username = username, DataIscrizione = dataIscrizione, Maggiorenne = maggiorenne };
            if (DAOClienti.GetInstance().Create(e))
            {
                Console.WriteLine("Cliente creato con successo");
            }
            else
            {
                Console.WriteLine("Errore nella creazione del cliente");
            }
            
        }
    }
}
