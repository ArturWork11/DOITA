using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnessioniDatabase
{
    internal class Libreria
    {
        private DAOLibri daoL;
        private List<Entity> libri;
        public Libreria()
        {
            
            daoL = new DAOLibri();

            libri = daoL.Read();

            
        }

        public string Lista()
        {
            string ris = "";

            foreach (Entity e in libri)
            {
                ris += e.ToString();
            }
            return ris;
        }

        public string LibriDal2000()
        {
            string ris = "";
            foreach (Entity e in daoL.LibriDal2000())
            {
                ris += e.ToString();
            }
            return ris;
            
            
        }

        public string LibriAutoreUser(string autore)
        {
            string ris = "";
            foreach (Entity e in daoL.LibriAutoreUser(autore))
            {
                ris += e.ToString();
            }
            return ris;
        }
    }
}