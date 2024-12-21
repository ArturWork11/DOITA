using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Esercizio02
{
    internal abstract class Entity
    {
        private int _id;
        private string _name;
        private string _dob;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Dob { get => _dob; set => _dob = value; }

        public Entity () { }

        public Entity(string[] row)
        {
            Id = int.Parse(row[0]);
            Name = row[1];
            Dob = row[2];
        }

        public override string ToString()
        {
            return $"\n------------\nId: {Id} \nName: {Name} \nDate of Birth: {Dob}";
        }

        public abstract double MonthlyCost();
        


    }
}
