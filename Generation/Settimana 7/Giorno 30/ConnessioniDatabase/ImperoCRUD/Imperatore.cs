using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace ImperoCRUD
{
    internal class Imperatore : Entity
    {
        public string Nome { get; set; }
        public string Dinastia { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Dod { get; set; }

        public bool Assassinio { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Nome: {Nome} \nDinastia: {Dinastia} \nNato il: {Dob.ToString("dd-MM-yyyy")} \nMorto il: {Dod.ToString("dd-MM-yyyy")} Causa morte: {(Assassinio ? "Assasinato" : "Naturale")}\n----------------------------------------------\n";

        }
    }
}
