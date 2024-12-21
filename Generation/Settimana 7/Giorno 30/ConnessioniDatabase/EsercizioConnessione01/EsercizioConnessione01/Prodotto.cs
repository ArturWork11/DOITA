using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioConnessione01
{
    internal class Prodotto : Entity
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public int Quantita { get; set; }
        public DateTime DataInserimento { get; set; }
        
        public Prodotto() { }
        public Prodotto(string nome,string categoria,string marca,int quantita,DateTime dataInserimento) 
        { 
            Nome = nome;
            Categoria = categoria;
            Marca = marca;
            Quantita = quantita;
            DataInserimento = dataInserimento;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nNome Prodotto: {Nome} \nCategoria: {Categoria} \nMarca: {Marca} \nQuantità disponibile: {Quantita} \nData inserimento: {DataInserimento}\n------------------------------\n";
        }
    }
}
