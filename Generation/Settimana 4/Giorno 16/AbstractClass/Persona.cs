
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    internal abstract class Persona
    {
        private string _nome;
        private string _cognome;
        private int _eta;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public int Eta { get => _eta; set => _eta = value; }

        public Persona() { }

        public Persona(string nome, string cognome, int eta)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Eta = eta;
        }

        //La classe astratta può fornire sia classi astratte che concrete
        //Se fornisce una classe astratta "obbliga" le PRIME classi figlie concrete alle quali si estente ad implementare tutti i metodi astratti ereditati dal padre solo tramite "override"
        public abstract string Cammina(); //Un metodo astratto può stare solo dentro una classe astratta 

        public override string ToString()
        {
            return $"Nome: {Nome} \nCognome: {Cognome} \nEta: {Eta}";
        }
    }
}
