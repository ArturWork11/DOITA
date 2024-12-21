using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioZoo
{
    internal class Animal : Entity
    {
        public string Type { get; set; }
        public int NumberCage { get; set; }
        public string Nutrition { get; set; }
        public string Genre { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }

        protected Animal() { }
        
        public Animal(int id, string type ,int numberCage, string nutrition, string genre, double weight, double size) : base(id)
        {
            Type = type;
            NumberCage = numberCage;
            Nutrition = nutrition;
            Genre = genre;
            Weight = weight;
            Size = size;
        }
        public override string ToString()
        {
            return base.ToString() + $"Type: {Type} \nCage number: {NumberCage} \nNutrition: {Nutrition} \nGenre: {Genre} \nWeight: {Weight} \nSize: {Size}";
        }
    }
}
