using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    internal class Calciatori
    {
        private string _nome;
        private string _cognome;
        private double _eta;
        private int _numeroMaglia;
        private string _ruolo;
        private string _squadra;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public double Eta { get => _eta; set { if (value > 0 && value < 123) _eta = value; } }
        public int NumeroMaglia { get => _numeroMaglia; set => _numeroMaglia = value; }
        public string Ruolo { get => _ruolo; set => _ruolo = value; }
        public string Squadra { get => _squadra; set => _squadra = value; }




        public Calciatori (string nome, string cognome, double eta, int numeroMaglia, string ruolo, string squadra)
        {
            this._nome=nome;
            this._cognome=cognome;
            this._eta=eta;
            this._numeroMaglia=numeroMaglia;
            this._ruolo=ruolo;
            this._squadra=squadra;
        }

        public string Scheda()
        {
            string ris = "";
            ris = $"CALCIATORE\nnome: {Nome} \ncognome: {Cognome} \nEta: {Eta} \nMaglia: {NumeroMaglia} \nRuolo: {Ruolo} \nSquadra: {Squadra}";
            return ris;
        }
    }
}
