using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    internal class Docente : Persona
    {
        string _materiaInsegnata;
        bool _diRuolo;

        public string MateriaInsegnata{ get => _materiaInsegnata; set => _materiaInsegnata = value; }
        public bool DiRuolo {  get => _diRuolo; set => _diRuolo = value;}

        public Docente() { }

        public Docente(string nome,string cognome,string dob,string materiaInsegnata,bool diRuolo):
            base(nome, cognome, dob)
        {
            this.MateriaInsegnata= materiaInsegnata ;
            this.DiRuolo = diRuolo;
        }

        //metodo scheda che eredita da Persona e che Docente modificherà a seconda delle sue necessità
        public override string Scheda()
        {
            return base.Scheda() + "\nMateria insegnata: " + _materiaInsegnata + "\nDi ruolo: " + (_diRuolo?"sì":"no");
        }

        public double Stipendio()
        {
            return 2000;
        }

        public double Stipendio(bool supplente)
        {
            double ris = 1800;
            ris -=(supplente)?500:0;
            return ris;
        }


    }
}
