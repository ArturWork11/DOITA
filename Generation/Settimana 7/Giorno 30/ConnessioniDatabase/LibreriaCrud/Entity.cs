using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCrud
{
    internal class Entity
    {
        public int Id { get; set; }

        //Questo costruttore lo uso solo per testare nel program
        public Entity(int id) 
        {  
           Id = id; 
        }

        //Questo sarà il costruttore 
        public Entity() { }

        public override string ToString()
        {
            return $"\tID: {Id}\n";
        }

        // REFLECTION
        // E' una libreria in grado di "riflettere" il contenuto di una classe.
        // Permette quindi di far leggere alla classe quali metodi e quali properties lo compongono,
        // al fine di poterle manipolare in modo automatico.

        public virtual void FromDictionary(Dictionary<string,string> riga) 
        {

            // Questo ciclo ha lo scopo di ottenere la lista di tutte le properties di questo oggetto (Libro)
            // Lo fa tramite 'this.GetType().GetProperties()' dove this indica l'oggetto su cui chiamiamo il metodo,
            // GetType() estrapola il tipo (Libro)
            // GetProperties() estrae le proprietà (string Titolo)
            foreach (PropertyInfo proprieta in this.GetType().GetProperties())
            {
                // Questo if serve per vedere se tra le chiavi del dictionary è presente il nome della property che sto guardando
                // Lo fa grazie a 'proprieta.Name.ToLower()' dove proprieta.Name estrapola la stringa che contiene il nome assegnato
                // a quella property (es. 'Titolo','Autore',ecc.)
                if (riga.ContainsKey(proprieta.Name.ToLower()))
                {

                    //Questa riga serve per salvare il valore di tipo string in qualcosa che potrà contenere
                    // qualunque tipo mi serva.
                    object valore = riga[proprieta.Name.ToLower()];

                    //Questo switch mi serve per capire a quale tipo devo castare il valore del dictionary.
                    //Lo faccio tramite 'proprieta.PropertyType.Name.ToLower() dove:
                    //      PropertyType -> Mi dice il tipo di quella property (int, double, DateTime, ecc)
                    //      Name ---------> Estrapolo il nome trovato e lo rendo stringa
                    switch (proprieta.PropertyType.Name.ToLower())
                    {
                        case "int32":
                            valore = int.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                        case "double":
                            valore = double.Parse(riga[proprieta.Name.ToLower()]); 
                            break;
                        case "datetime":
                            valore = DateTime.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                        case "bool":
                        case "boolean":
                        case "bit":
                            valore = bool.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                    }
                    //Questo comando mi serve per salvare nella property che ho in mano il valore parsato ottenuto
                    proprieta.SetValue(this, valore);
                } 
            }
        }
    }
}
