using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal abstract class Entity
    {
        int Id { get; set; }

        public Entity() { }

        public Entity(string[] row)
        {
            Id = int.Parse(row[0]);
        }

        public override string ToString()
        {
            return $"\n-----------------\nId: {Id}\n";
        }
    }
}
