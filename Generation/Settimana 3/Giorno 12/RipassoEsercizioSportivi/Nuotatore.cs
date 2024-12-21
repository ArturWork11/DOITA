using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    internal class Nuotatore
    {
        private string _nome;
        private string _cognome;
        private double _eta;
        private string _stilePreferito;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public double Eta { get => _eta; set { if (value > 0 && value < 123) _eta = value; } }
        public string StilePreferito { get => _stilePreferito; set => _stilePreferito = value; }

        public Nuotatore (string nome, string cognome, double eta, string stilePreferito)
        {
            this._nome=nome;
            this._cognome=cognome;
            this._eta=eta;
            this._stilePreferito=stilePreferito;
        }

        public string Scheda()
        {
            string ris = "";
            ris = $"NUOTATORE\nNome: {Nome} \nCognome: {Cognome} \nEta: {Eta} \nStile preferito: {StilePreferito}";
            return ris;
        }
    }
}

