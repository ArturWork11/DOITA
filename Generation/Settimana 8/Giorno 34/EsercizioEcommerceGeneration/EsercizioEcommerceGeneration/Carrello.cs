using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class Carrello : Entity
    {
        public Cliente Cliente { get; set; }
        public Prodotto Prodotto { get; set; }
        public int QuantitaAcquisto { get; set; }

        public override void FromDictionary(Dictionary<string, string> riga)
        {
            if (riga["idcliente"] != "" && riga["idcliente"].ToLower() != "null")
                Cliente = (Cliente)DAOClienti.GetInstance().Find(int.Parse(riga["idcliente"]));
            if (riga["idprodotto"] != "" && riga["idprodotto"].ToLower() != "null")
                Prodotto = (Prodotto)DAOProdotti.GetInstance().Find(int.Parse(riga["idprodotto"]));

            base.FromDictionary(riga);
        }

        public override string ToString()
        {
            return $"Cliente: {(Cliente != null ? Cliente.Username : "User Non registrato o sconosciuto")} \nProdotto: {(Prodotto != null ? Prodotto.Nome : "Articolo inesistente")} \nQuantità: {QuantitaAcquisto}\n-------------------------------------\n";
        }

       
    }
}
