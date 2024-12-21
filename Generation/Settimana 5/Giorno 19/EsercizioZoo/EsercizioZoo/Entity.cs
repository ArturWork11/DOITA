using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioZoo
{
    internal abstract class Entity
    {
        public int Id { get; set; }

        protected Entity() { }
        public Entity(int id) 
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"ID: {Id}";
        }
    }
}
