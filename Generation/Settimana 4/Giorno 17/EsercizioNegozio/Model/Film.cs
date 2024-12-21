using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal class Film : Product
    {
        public string Director { get; set; }
        public double Duration { get; set; }  

        public Film () { }

        public Film (string[]row) : base(row)
        {
            Director = row[2];
            Duration = double.Parse(row[7]);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDirector: {Director} \nDuration: {Duration}\n";
        }
    }
}
