using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioPolimorfismo
{
    internal class Car : Vehicle
    {

    
            private int _carDoors;
            private bool _optional;
            private bool _spareWheel;

           
            public int CarDoors { get => _carDoors;  set => _carDoors = value;  }
            public bool Optional { get => _optional;  set => _optional = value;  }
            public bool SpareWheel { get => _spareWheel;  set => _spareWheel = value;  }
            
            public Car () { }
            public Car(string[]row) : base(row) 
            {
              
                CarDoors = int.Parse(row[5]);
                Optional = row[6] == "S" ? true : false;
                SpareWheel = row[7] == "S" ? true : false;

            }

        public override string ToString()
        {
            return base.ToString() + $"\nCar Doors: {CarDoors} \nOptional: {(Optional ? "Yes" : "no")} \nSpare Wheel: {(SpareWheel ? "Yes" : "No")}\n--------------";
        }

        public override double Price()
        {
            double price = base.Price();
            switch (Brand.ToLower())
            {
                case "fiat":
                    price += 10000;
                    break;
                default:
                    price += 20000;
                    break;
            }

            switch (CarDoors)
            {
                case 3:
                    price += 3000;
                    break;
                case 5:
                    price += 5000;
                    break;
                default:
                    price += 1000;
                    break;
            }

            if (Optional)
            {
                price += 3500;
            }
            else
            {
                price += 1500;
            }

            if (SpareWheel) 
            {
                price += 2000;
            }
            else
            {
                price += 1000;
            }

            return price;
        }

        public bool Vintage()
        {
            return Year < 2000;
        }
    }
}
