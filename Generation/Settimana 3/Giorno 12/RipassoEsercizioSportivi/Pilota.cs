using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    internal class Pilota
    {
        private string _nome;
        private string _cognome;
        private double _eta;
        private string _veicolo;
        private string _scuderia;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public double Eta { get => _eta; set { if (value > 0 && value < 123) _eta = value; } }
        public string Veicolo { get => _veicolo; set => _veicolo = value; }
        public string Scuderia { get => _scuderia; set => _scuderia = value; }
        public Pilota(string nome, string cognome, double eta, string veicolo, string scuderia)  
        {
            this._nome=nome;
            this._cognome=cognome;
            this._eta=eta;
            this._veicolo=veicolo;
            this._scuderia=scuderia;
        }
        public string Scheda()
        {
            string ris = "";
            ris = $"PILOTA\nNome: {Nome} \nCognome: {Cognome} \nEta: {Eta} \nVeicolo: {Veicolo} \nScuderia: {Scuderia}";
            return ris;
        }
    }

}
