using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    internal class Persona
    {
        //CAMPI dell'oggetto
        string _nome;
        string _cognome;
        string _dob;

        //PROPERTIES
        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public string Dob { get => _dob; set => _dob = value; }


        //COSTRUTTORE
        public Persona() {} //ereditato da Object, classe padre di tutti gli oggetti

        public Persona(string nome, string cognome,string dob)
        {
            this._nome = nome;
            this._cognome = cognome;
            this._dob = dob;
        }

        //METODI
        //POLIMORFISMO per METODI : permette ad un metodo di avere forme diverse
        //OVERRIDE -> permette ad un figlio di usare un metodo del padre, aggiornandolo o sovcrascirvendolo completamente nel corpo del metodo
        //cioè in classe relazionate()padre-figlia richiamerò questo metodo con esattamente la stessa firma(nomeMetodo(parametri))
        public virtual string Scheda() //rappresenta in stringa le caratteristiche di un oggetto, viene ereditato da Object
            //la parola VIRTUAL indica che questo metodo potrà essere modificato/influenzato dai figli, ognuno a seconda delle sue necessità
        {
            string ris = $"Nome: {_nome}\n,Cognome: {_cognome}\n,Data di nascita: {_dob}";

            return ris;
        }

        //metodo che calcola l'età


    }
}
