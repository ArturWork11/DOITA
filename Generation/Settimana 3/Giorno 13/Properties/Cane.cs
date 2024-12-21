using Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    internal class Cane : Animale
    {
      /*  private string _nome;
        private int _eta;
        private string _razza;
        private string _colore; */

        private bool _feste;

      /*  public string Nome { get => _nome; set => _nome = value; }
        public int Eta { get => _eta; set => _eta = value; }
        public string Razza { get => _razza; set => _razza = value; }
        public string Colore { get => _colore; set => _colore = value; } */
        public bool Feste { get => _feste; set => _feste = value; }


        public Cane(string nome, int eta, string razza, string colore, bool feste) : base (nome,eta, razza, colore)
        {
           
            _feste = feste;
        } 
    }
}
