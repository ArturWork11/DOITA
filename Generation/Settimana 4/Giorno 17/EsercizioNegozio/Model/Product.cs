using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal abstract class  Product : Entity
    {
        
        public string ProductType { get; set; }
        public string Title { get; set; }
        public string  Genre { get; set; }
        public double Price { get; set; }
        public int YearsPublished { get; set; }

        public Product () { }


        public Product (string[] row) : base (row)
        {
            ProductType = row[1];
            Title = row[3];
            Genre = row[4];
            Price = double.Parse(row[5]);
            YearsPublished = int.Parse(row[6]);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nProduct: {ProductType} \nTitle: {Title} \nGenre: {Genre} \nPrice: {Price} \nYears Published: {YearsPublished}";
        }
    }
}
