using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    internal class Studente : Persona //Studente è una classe figlia di Persona. Può avere un solo padre
                                      //In C# l'ereditarietà è SINGOLA, Studnete conosce i campi e i metodi che eredita da Persona, Persona invece non sa quanto e quali figli abbia
    {
        //CAMPI
        string _classe;
        List<int> _voti;

        //PROPERTIES
        public string Classe{ get => _classe; set => _classe = value;}
        public List<int> Voti { get => _voti; set => _voti = value;}

        //COSTRUTTORE

        //POLIMORFISMO PER METODI:
        //OVERLOAD -> sovraccarico una classe con metodi dallo stesso nome ma con FIRMA DIVERSA
        //un esempio è il costruttore
        public Studente() { }

        //nel costruttore parametrizzato dobbiamo come si crea uno studente, esso eredita anche i campi di Persona per cui
        //anch'essi devno essere valorizzati in questo momento
        public Studente(string nome,string cognome,string dob,string classe,List<int> voti)
            : base(nome, cognome, dob) //richiamo il costruttore di Persona che gestisce i suoi campi
        {
            //gestisce i campi specifici di Studente
            this._classe = classe;
            this._voti = voti;

        }

        //POLIMORFISMO PER METODI
        //in Scheda()
        //eredito Scheda() dalla classe padre e lavoro esattamente su quel metodo -> nella classe padre devo aver aggiunto la parola chiave 
        //virtual
        //qui, nella classe figlia devo usare la parola OVERRIDE -> SOVRASCRIVERE  parzialmente o totalmente un metodo ereditato dal padre
        //LA FIRMA DEVE essere la STESSA in entrambe le classi
        public override string Scheda() 
        {
            // string ris = $"Nome: {Nome}\n,Cognome: {Cognome},Data di nascita: {Dob},Classe: {_classe}\n,Voti: {_voti}" ;
            //non voglio sovrascrivere completamente la funzione che ha il metodo nella classe padre ma 
            //vorrei usare quello che il padre ha già dichiarato e aggiungere le caratteristiche specifiche di Studente
            //uso base per indicare l'istanza del padre 
            //quell'istanza è in grado di invocare i suoi metodi, in questo contesto ha senso invocare il metodo Scheda() del padre per usarne il 
            //valore di ritorno
            string ris = base.Scheda() +
                         "\nClasse: " + _classe + "\n" +
                         "Voti: " + (_voti==null?"nessun voto":_voti.ToString()) +"\n";
                        
            return ris;
        }



    }
}
