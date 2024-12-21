using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio02
{
    internal class Animal : Entity
    {
        string _type;
        int _legsNumber;
        string _nutrition;

        public string Type { get => _type; set => _type = (value.ToLower() != "gallina" && value.ToLower() != "toro" && value.ToLower() != "mucca" && value.ToLower() != "cavallo") ? "mucca" : value; }
        public int LegsNumber { get => _legsNumber; set => _legsNumber = value; }
        public string Nutrition { get => _nutrition; set => _nutrition = value; }

        public Animal () { }
        public Animal(string[]row) : base (row) 
        {
            Type = row[3];
            LegsNumber = int.Parse(row[4]);
            Nutrition = row[5];
            
        }

        public override string ToString()
        {
            return base.ToString() + $"\nType: {Type} \nNumber of legs: {LegsNumber} \nType of nutrition: {Nutrition} \nMonthly cost: {MonthlyCost()}";
        }

        public override double MonthlyCost()
        {
            double price = 3;
            switch (Type.ToLower())
            {
                case "gallina":
                    price += 0.5;
                    break;
                case "cavallo":
                    price += 7;
                    break;
                case "mucca":
                    price += 12;
                    break;
                default:
                    price += 8;
                    break;
            }
            if (Nutrition.ToLower() == "carnivoro")
            {
                price += 4;
            }
            return price;
        }
    }
}
