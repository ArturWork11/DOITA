using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class Animale
    {
        private string _nome;
        private int _eta;
        private string _razza;
        private string _colore;


        public string Nome { get => _nome; set => _nome = value; }
        public int Eta { get => _eta; set => _eta = value; }
        public string Razza { get => _razza; set => _razza = value; }
        public string Colore { get => _colore; set => _colore = value; }

        public Animale (string nome, int eta, string razza, string colore)
        {
            _nome = nome;
            _eta = eta;
            _razza = razza;
            _colore = colore;
        } 
    }
}
