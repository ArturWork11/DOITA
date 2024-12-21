using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioConcessionaria
{
    internal class Menu
    {
        private static DAOProdotti daoP = DAOProdotti.GetInstance();
        private static DAOMacchine daoMacchine = DAOMacchine.GetInstance();
        private static DAOMoto daoMoto = DAOMoto.GetInstance();
        public static void MenuPrincipale()
        {
            string digit = "";
            do
            {
                Console.Clear();
                Console.WriteLine($"Benvenuto nella Concessionaria di Generation! \n" +
                                  $"Digita: \n" +
                                  $"1.Per Visualizzare la lista dei veicoli vecchi \n" +
                                  $"2.Per visualizzare le schede dei mezzi che possono fare i km a vostra scelta \n" +
                                  $"3.Per Visualizzarre le SuperCar \n" +
                                  $"4.Per visualizzare le moto sportive \n" +
                                  $"5.Per Visualizzare i mezzi di una categoria a scelta \n" +
                                  $"6.Per visualizzare la frequenza dei veicoli per categoria \n" +
                                  $"7.Per le schede dei mezzi dei veicoli ricercati per marca \n" +
                                  $"8.Per visualizzare i prodotti ordinati per nome \n" +
                                  $"9.Per trovare una soluzione di noleggio \n" +
                                  $"10.Per visualizzare le auto più veloci di una velocita a scelta \n" +
                                  $"11.Per visualizzare i prodotti ordinati per prezzo \n" +
                                  $"0. Per uscire dal programma\n");
                digit = Console.ReadLine();
                switch (digit)
                {
                    case "1":
                        daoP.ListaProdottiVecchi();
                        break;
                    case "2":
                        daoP.MaxDistanza();
                        break;
                    case "3":
                        daoMacchine.AutoSuper();
                        break;
                    case "4":
                        daoMoto.Sportive();
                        break;
                    case "5":
                        string categoria = "";
                        daoP.Cerca(categoria);
                        break;
                    case "6":
                        daoP.Frequenza();
                        break;
                    case "7":
                        string marca = "";
                        daoP.CercaPerMarca(marca);
                        break;
                    case "8":
                        List<Prodotto> array = new();
                        daoP.StampaListe(array);
                        break;
                    case "9":
                        double budgetMensile = 0;
                        int passeggeri = 0;
                        daoP.TrovaSoluzione(budgetMensile,passeggeri);
                        break;
                    case "10":
                        daoMacchine.Veloci();
                        break;
                    case "11":
                        daoP.InOrdine();
                        break;
                    case "0":
                        Console.WriteLine("Grazie e arrivederci");
                        break;
                    default:
                        break;
                }

                if (digit != "0")
                {
                    Console.WriteLine("\n-----------------\nPremi un tasto qualsiasi per continuare oppure premi 0 per uscire dal programma");
                    digit = Console.ReadLine();
                }
            } while (digit != "0");
        }

       
    }
}
