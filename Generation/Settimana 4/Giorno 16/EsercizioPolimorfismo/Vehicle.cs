using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioPolimorfismo
{
    internal class Vehicle
    {
        private string _type;
        private string _brand;
        private string _model;
        private string _color;
        private int _year;

        public string Type { get => _type; set => _type = value; }
        public string Brand { get => _brand;  set => _brand = value;  }
        public string Model { get => _model;  set => _model = value;  }
        public string Color { get => _color;  set => _color = value;  }
        public int Year { get => _year;  set => _year = value;  }

        public Vehicle() { }

        public Vehicle(string[] row)
        {
            Type =  row[0] == "a" ? "Car" : "Motorcycle";
            Brand = row[1];
            Model = row[2];
            Color = row[3];
            Year = int.Parse(row[4]);
        }

        public virtual string ToString()
        {
            return $"Type: {Type} \nBrand: {Brand} \nModel: {Model} \nColor: {Color} \nYear: {Year} \nPrice: {Price()}";
        }

        public virtual double Price()
        {
            return 1000;
        }
    }
}
