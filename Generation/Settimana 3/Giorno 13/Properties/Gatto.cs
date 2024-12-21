using Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereditarieta
{
    internal class Gatto : Animale
    {
        /* private string _nome;
        private int _eta;
        private string _razza;
        private string _colore; */

        private bool _fusa;
       /* public string Nome { get => _nome; set => _nome = value; }
        public int Eta { get => _eta; set => _eta = value; }
        public string Razza { get => _razza; set => _razza = value; }
        public string Colore { get => _colore; set => _colore = value; } */
        public bool Fusa { get => _fusa; set => _fusa = value; }


        //Quando definisco il costruttore su una classe figlia e ho un costruttore esplicitato diverso su quello di default sulla classe padre,
        //devo 'dire' a C# come chiamare anche il costruttore della classe padre.
        //Questo è possibile aggiungendo ": base()" dopo la chiusura della tonda dei parametri possiamo
        public Gatto(string nome,int eta,string razza,string colore, bool fusa) : base(nome,eta,razza,colore)
        {
          
            _fusa = fusa;
        } 
    }
}
