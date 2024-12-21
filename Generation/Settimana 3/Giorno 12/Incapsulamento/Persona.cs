using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Nella programmmazione ad oggetti abbiamo tre principi fondamentali 
//INCAPSULAMENTE
//L'incapsulamento è la necessità di nascondere e proteggere i dati prsenti negli oggetti e non solo, definire i metodi di accesso a questi dati, sia in lettura che in scrittura.
//Questo è possibile grazie ai livelli di visibilità (vedi classe Persona) che ci permettono di limitare l'accesso.
//I modi che abbiamo quindi per accedere a questi dati sono le properties
//EREDETARIETA'
//POLIMORFISMO

namespace Incapsulamento
{
    internal class Persona
    {
        //Esistono vari livelli di visibilità: public, internal, protected, private
        //public: il metodo/campo/proprietà sono accessibili da qualsiasi punto (anche da progetti esterni)
        //internal: il metodo/campo/proprietà è public SOLO per il PROGETTO in cui si trova
        //protected: il metodo/campo/proprietà è accessibile solo dall'interno della classe stessa oppure dall'interno delle classi che estendono la classe che lo definisce
        //private: il metodo/campo/proprietà è accessibile solo e solamente dall'interno della classe che lo definisce
        //il livello di DEFAULT è PRIVATE

        //per i campi che sono private la nomenclatura diventa _camelCase (quindi underscore davanti al nome)
        private string _nome;
        private string _cognome;
        private double _eta;

        //Properties
        //Le properties permettono di definire quelli che vengono chiamati getter e setter che permettono un maggior controllo sui dati che gli diamo
        public string Nome { get => _nome; }
        public string Cognome { get => _cognome; }
        public string Nominativo { get => _nome + " " + _cognome;} 

        public string NomeFormattato {
            get
            {
                string primaLettera = _nome[0].ToString().ToUpper();
                string nome = primaLettera + _nome.Substring(1);
                return nome;

            }

            //set
            //{
            //    Il set con le graffe aperte quindi con più istruzioni non ha bisogno del return
            //}
        }

        public Persona(string nome, string cognome, double eta)
        {
            this._nome = nome;
            this._cognome = cognome;
            this._eta = eta;
        }

        public string Scheda()
        {
            return $"Nome: {Nome}\nCognome: {_cognome} \nEta: {_eta}";
        }
    }
}
