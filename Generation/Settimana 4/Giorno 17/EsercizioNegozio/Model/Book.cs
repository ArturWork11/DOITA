using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal class Book : Product
    {
        public string Author { get; set; }
        public double PagesNumber { get; set; }

        public Book() { }

        public Book(string[] row) : base (row)
        {
            Author = row[2];
            PagesNumber = double.Parse(row[7]);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nAuhtor: {Author} \nPages: {PagesNumber}\n";
        }
    }
}
