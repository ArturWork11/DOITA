using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EsercizioPolimorfismo
{
    internal class CarShowroom
    {
        List<Vehicle> _vehicles;

        public List<Vehicle> Vehicles { get => _vehicles; set => _vehicles = value; }

        public CarShowroom() { }

        public CarShowroom(string path)
        {
            Vehicles = new List<Vehicle>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] row = line.Split(';'); 
                switch(row[0].ToLower()) 
                {
                    case "a":
                        Vehicles.Add(new Car(row));
                        break;
                    case "m":
                        Vehicles.Add(new Motorcycle(row)); 
                        break;
                    default:
                        break;
                }
            }
        }

        public string ListFull()
        {
            string list = "";
            foreach (Vehicle vehicle in Vehicles)
            {
                list += vehicle.ToString() + "\n";
            }
            return list;
        }

        public string MotorcycleList()
        {
            string list = "";
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle)
                {
                    list += vehicle.ToString() + "\n";
                }
            }
            return list;
        }

        public string CarList()
        {
            string list = "";
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car)
                {
                    list += vehicle.ToString() + "\n";
                }
            }
            return list;
        }

        public string VintageCars()
        {
            string list = "";
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car && vehicle.Year < 2000)
                {
                    list += vehicle.ToString() + "\n";
                }
            }
            return list;

        }
        
        public string ExpensiveMotorcycles()
        {
            string list = "";
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle && vehicle.Price() > 9500)
                {
                    list += vehicle.ToString() + "\n";
                }
            }
            return list;
        }

    }
}
