using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    internal class Scuola
    {
        //CAMPI
        //List<Studente> _studenti;
        //List<Docente> _docenti;
        List<Persona> _persone;

        //Properties
        public List<Persona> Persone { get => _persone; set => _persone = value; }
        
        //Costruttore
        public Scuola(string percorso)
        {
            leggiFile(percorso);
        }

        //metodi
        void leggiFile(string percorso)
        {
            string[] righe=File.ReadAllLines(percorso);
            _persone = new List<Persona>();
            Persona p = null;
            foreach(string s  in righe)
            {
                string[] dati =s.Split(";");

                if (dati[0].ToLower() == "s")
                {
                    //se trovo s creo uno studente
                    //s;Tizio;Caio;23-09-2009;1C;8-9-8-10
                    string[] votiSplittati = dati[5].Split("-");
                    List<int> voti = new List<int>();
                    foreach(string a in votiSplittati)
                    {
                        voti.Add(int.Parse(a));
                    }

                    p = new Studente(dati[1], dati[2], dati[3], dati[4],voti);

                }else if(dati[0].ToLower() == "d")
                {
                    //d;Fiona;Verdi;25-07-1968;Matematica;N
                    p = new Docente(dati[1], dati[2], dati[3], dati[4], dati[5].ToLower() == "s");
                }

                if(p != null)
                {
                   _persone.Add(p);
                }

            }
            
        }

        //metodo che mi restituisce solo gli studenti
        public List<Studente> Studenti()
        {
            List<Studente> ris = new List<Studente>();
            //ora scorrerò la lista delle persone e controllerò quali di esse sono Studenti, cioè quali di esse
            //sono state CREATE CONCRETAMENTE come istanze di tipo Studente
            foreach(Persona p in _persone)
            {
                //verifico il tipo concreto di un oggetto
                //p.GetType() -> restituisce un oggetto di tipo Type
                //.Name permette di invocare la properties Name dell'oggetto Type
                //if(p.GetType().Name == "Studente")
                //if(p.GetType()  == typeof(Studente))
                if(p is  Studente) //is indica è un'istanza di -> verifica il tipo concreto con cui ho creato l'oggetto
                {
                    //CASTING: questa operazione permette TEMPORANEAMENTE di cambiare il tipo formale di un oggetto
                    //il casting non perdura per tutto il programma ma solo per la riga di codice in cui lo inserisco
                    //prima di castare un oggetto bisogna sempre controllare di poter effettuare l'operazione cioè
                    //di verificare che quell'oggetto possa essere trasformato nel tipo indicato tra le ()
                    Studente st = (Studente)p;
                    ris.Add(st);
                    //ris.Add((Studente)p); indico per questo comando che l'oggetto p non è più formalmente di tipo Persona ma di tipo Studente 
                    
                }
            }

            return ris;
        } 


        public string listaSchede()
        {
            string ris = "";
            foreach(Persona p in _persone)
            {
                ris += p.Scheda() + "\n";
            }
            return ris;
        }

        public string listaSchedeStud()
        {
            string ris = "";
            foreach (Studente p in Studenti())
            {
                ris += p.Scheda() + "\n";
            }
            return ris;
        }

    }
}
