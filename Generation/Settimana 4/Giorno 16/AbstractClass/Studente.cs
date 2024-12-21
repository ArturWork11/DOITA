using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    internal class Studente : Persona
    {
        private string _matricola;

        public string Matricola { get => _matricola; set => _matricola = value;  }

        public Studente(string nome,string cognome, int eta,string matricola) :  base (nome,cognome,eta)
        {

            this.Matricola = matricola;
        }

        public override string Cammina()
        {
            return "Cammina da studente";
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMatricola: {Matricola}";
        }
    }
}
