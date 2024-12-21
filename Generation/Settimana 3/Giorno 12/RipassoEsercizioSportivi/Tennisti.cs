using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    internal class Tennisti
    {
        private string _nome;
        private string _cognome;
        private double _eta;
        private string _sponsor;
        private bool _isDestro;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public double Eta { get => _eta; set { if (value > 0 && value < 123) _eta = value; } }
        public string Sponsor { get => _sponsor; set => _sponsor = value; }
        public bool IsDestro { get => _isDestro; set => _isDestro = value; }
        public Tennisti(string nome,string cognome, double eta,string sponsor,bool isDestro) 
        {
            this._nome = nome;
            this._cognome = cognome;
            this._eta = eta;
            this._sponsor = sponsor;
            this._isDestro = isDestro;

        }
    
        public string Scheda()
        {
            string ris = "";
            ris = $"TENNISTA\nnome: {Nome} \ncognome: {Cognome} \nEta: {Eta} \nSponsor: {Sponsor} \nbraccio:" + (IsDestro ? "destro" : "Mancino");
            return ris;
        }
    }
}
