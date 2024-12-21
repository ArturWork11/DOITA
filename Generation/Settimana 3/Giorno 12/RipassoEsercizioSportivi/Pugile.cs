using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    internal class Pugile
    {
        private string _nome;
        private string _cognome;
        private double _eta;
        private int _peso;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public double Eta { get => _eta; set { if (value > 0 && value < 123) _eta = value; } }
        public int Peso { get => _peso; set => _peso = value; }
        public Pugile (string nome, string cognome, double eta, int peso)
        {
            this._nome=nome;
            this._cognome=cognome;
            this._eta=eta;
            this._peso=peso;
        }

        public string Scheda()
        {
            string ris = "";
            ris = $"PUGILE\nNome: {Nome} \nCognome: {Cognome} \nEta: {Eta} \nPeso: {Peso}";
            return ris;
        }

    }

}
