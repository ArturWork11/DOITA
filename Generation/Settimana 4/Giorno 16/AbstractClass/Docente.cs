using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    internal class Docente : Persona
    {
        int _anniEsperienza;
        
        public int AnniEsperienza { get => _anniEsperienza; set => _anniEsperienza = value; }

        public Docente(string nome,string cognome, int anni,int anniEsperienza ) : base(nome,cognome,anni) 
        {
            this.AnniEsperienza = anniEsperienza;
        }

        public override string Cammina()
        {
            return "Cammina da docente";
        }

    }
}
