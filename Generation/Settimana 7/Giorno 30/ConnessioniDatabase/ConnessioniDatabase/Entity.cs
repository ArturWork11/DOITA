using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnessioniDatabase
{
    internal abstract class Entity
    {
        //Campo
        private int id;

        //Properties
        public int Id { get => id; set => id = value; }

        //Costruttore
        public Entity(int id) 
        {
            Id = id;
        }

        //Metodi
        public override string ToString()
        {
            return $"\tID {Id}\n";
        }
    }
}
