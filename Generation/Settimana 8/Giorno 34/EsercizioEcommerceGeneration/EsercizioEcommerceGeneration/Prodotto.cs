using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioEcommerceGeneration
{
    internal class Prodotto : Entity
    {
        public string Nome { get; set; }
        public int QuantitaMagazzino { get; set; }
        public DateTime DataCambio { get; set; }

        public DateTime DataScadenza { get; set; }
        public string Categoria { get; set; }
        public double Prezzo { get; set; }

        public override string ToString()
        {

            return base.ToString() + $"Nome: {Nome} \nQuantità prodotto: {QuantitaMagazzino} \nData cambio: {DataCambio} \nData scadenza: {(DataScadenza == DateTime.MinValue ? "non scade" : DataScadenza.ToString("yyyy-MM-dd"))} \nCategoria: {Categoria} \nPrezzo: {Prezzo} \n-------------------------------------\n";
        }

        public override void FromDictionary(Dictionary<string, string> riga)
        {


            foreach (PropertyInfo proprieta in this.GetType().GetProperties())
            {

                if (riga.ContainsKey(proprieta.Name.ToLower()))
                {
                    string valoreStringa = riga[proprieta.Name.ToLower()];
                    object valore = null;




                    switch (proprieta.PropertyType.Name.ToLower())
                    {
                        case "int32":
                            valore = int.Parse(valoreStringa);
                            break;
                        case "double":
                            valore = double.Parse(valoreStringa);
                            break;
                        case "datetime":
                            if (string.IsNullOrEmpty(valoreStringa) || valoreStringa.ToLower() == "null" )
                            {
                                valore = DateTime.MinValue;
                            }
                            else if (DateTime.TryParse(valoreStringa, out DateTime valoreDateTime))
                            {
                                valore = valoreDateTime;
                            }
                            else
                            {
                                throw new FormatException($"Il valore '{valoreStringa}' non è un formato valido per DateTime.");
                            }
                            break;
                        case "bool":
                        case "boolean":
                        case "bit":
                            valore = bool.Parse(valoreStringa);
                            break;
                        case "string":
                            valore = valoreStringa;
                            break;
                    }
                   

                    proprieta.SetValue(this, valore);
                }
            }
            
        }

    }
}
