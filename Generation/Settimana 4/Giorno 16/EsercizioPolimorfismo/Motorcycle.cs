using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioPolimorfismo
{
    internal class Motorcycle : Vehicle
    {
        private bool _passenger;
        private int _trunk;
        private bool _cruiseControl;

        public bool Passenger { get => _passenger; set => _passenger = value;  }
        public int Trunk { get => _trunk; set => _trunk = value; }
        public bool CruiseControl { get => _cruiseControl; set => _cruiseControl = value; }

        public Motorcycle () { }

        public Motorcycle(string[] row) : base(row)
        {
            Passenger = row[5] == "S" ? true : false;
            Trunk = int.Parse(row[6]);
            CruiseControl = row[7] == "S" ? true : false;

        }

        public override string ToString()
        {
            return base.ToString() + $"\nPassenger: {(Passenger ? "Yes" : "No")} \nTrunk: {Trunk} \nCruise Control: {(CruiseControl ? "Yes" : "No")}\n--------------";
        }

        public override double Price()
        {
            double price = base.Price();

            switch (Brand.ToLower())
            {
                case "ducati":
                    price += 5000;
                    break;
                case "harley davidson":
                    price += 8000;
                    break;
                case "kawasaki":
                    price += 5500;
                    break;
                default:
                    break;
            }

            if (CruiseControl) 
            {
                price += 2000;
            }
            else
            {
                price += 100;
            }

            price += 100 * Trunk;

            if (Passenger)
            {
                price += 1000;
            }
            else
            {
                price += 500;
            }

            return price;
        }
    }
}
