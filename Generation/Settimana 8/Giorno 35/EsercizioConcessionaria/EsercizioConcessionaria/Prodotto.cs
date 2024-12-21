using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioConcessionaria
{
    internal class Prodotto : Entity
    {
          public string Categoria {  get; set; }
          public string Marca { get; set; }
          public string Modello { get; set; }
          public bool Affittabile { get; set; }
          public int AnnoImmatricolazione { get; set; }
          public double ConsumoMedioAKM { get; set; }
          public double CapienzaSerbatoio { get; set; }

        public override string ToString()
        {
            return $"\n-----------------\n" + base.ToString() + $"Categoria: {Categoria} \nMarca: {Marca} \nModello: {Modello} \nAffittabile: {(Affittabile ? "si" : "no")} \nAnno Immatricolazione: {AnnoImmatricolazione} \nConsumo medio: {ConsumoMedioAKM} \nCapienza Serbatoio: {CapienzaSerbatoio} \nPrezzo: {Prezzo()} \nMarchio famoso: {(Famoso() ? "si" : "no")} \nKm percorribili con un pieno: {KMPercorribili()} \nPrezzo Noleggio al mese: {(Affittabile ? AffittoMensile() : "non affittabile")} \nEta: {Eta()}";
        }
        public double Prezzo()
        {
            double prezzo = 0;
            switch (Categoria.ToLower())
            {
                case "macchina":
                    prezzo += 10000;
                    break;
                case "moto":
                    prezzo += 5000;
                    break;
                case "camion":
                    prezzo += 25000;
                    break;
                case "furgone":
                    prezzo += 15000;
                    break;
                case "quad":
                    prezzo += 600;
                    break;
                default:
                    break;
            }

            switch (AnnoImmatricolazione)
            {
                case > 2010 and < 2015:
                    prezzo += 3000;
                    break;
                case < 2010:
                    prezzo += 1500;
                    break;
                case > 2015 and < 2020:
                    prezzo += 4000;
                    break;
                case > 2020:
                    prezzo += 5000;
                    break;
                default :
                    break;
            }

            switch (Marca.ToLower())
            {
                case "audi":
                    prezzo += 10000;
                    break;
                case "bmw":
                    prezzo += 12000;
                    break;
                case "mercedes":
                    prezzo += 15000;
                    break;
                case "ferrari":
                    prezzo += 100000;
                    break;
                case "rolls royce":
                    prezzo += 250000;
                    break;
                case "ducati":
                    prezzo += 4000;
                    break;
                case "harley davidson":
                    prezzo += 5500;
                    break;
            }
            return prezzo;
        }

        public bool Famoso()
        {

            if (Marca.ToLower() == "rolls royce" || Marca.ToLower() == "ferrari" || Marca.ToLower() == "ducati" || Marca.ToLower() == "harley davidson")
                return true;
            else
                return false;
        }

        public double KMPercorribili()
        {
           double kmPercorribili = CapienzaSerbatoio / ConsumoMedioAKM;
            kmPercorribili = Math.Round(kmPercorribili, 2);
            return kmPercorribili;
        }

        public double AffittoMensile()
        {
            double prezzoNolo = 0;

            if (Affittabile)            
                prezzoNolo = Prezzo() * 0.4 / 12;
            
            prezzoNolo = Math.Round(prezzoNolo, 2);
            return (prezzoNolo);
        }

        public int Eta()
        {
            int eta = DateTime.Now.Year - AnnoImmatricolazione;
            return eta;
        }
    }
}
