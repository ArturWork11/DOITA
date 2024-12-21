using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioNegozio
{
    internal class Cd : Product
    {
        public string Artist { get; set; }
        public double Tracks { get; set; } 

        public Cd () { }

        public Cd(string[]row) : base(row)
        {
            Artist = row[2];
            Tracks = double.Parse(row[7]);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nArtist: {Artist} \nTracks: {Tracks}\n";
        }
    }
}
