using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioZoo
{
    internal class Zoo : IZoo
    {
        public string Name { get; set; }
        public string Address { get; set; } 
        List<Entity> entities { get; set; }

        protected Zoo() { }

        public void ImportData(string[] path)
        {
            string[] lines = File.ReadAllLines("../../../Dati.txt");
            entities = new List<Entity>();
            foreach (var item in lines)
            {
                string[]row = item.Split(';');
                if (row.Length == 6)
                {
                    entities.Add(new Staff(int.Parse(row[0]), row[1], row[2], DateTime.Parse(row[3]), int.Parse(row[4]), row[5]));
                }
                else if(row.Length == 7)
                {
                    entities.Add(new Animal(int.Parse(row[0]), row[1], int.Parse(row[2].Substring(7)), row[3], row[4], double.Parse(row[5]), double.Parse(row[6])));
                }

            }


        }

        public List<Animal> AnimalList()
        {
            return entities.OfType<Animal>().ToList();
        }
        public List<Staff> StaffList()
        {
            return entities.OfType<Staff>().ToList();
        }
        public List<Animal> AnimalOrderByType(string type)
        {
            //return entities.OfType<Animal>().ToList().OrderBy(animal  => animal.Type).ToList();
            List<Entity> listType = new List<Entity>();
            foreach (Animal animal in AnimalList()) 
            {
                if ((((Animal)animal).Type) == type)
                {
                    listType.Add(animal);
                }
            }
            return listType;
        }
        public List<Animal> AnimalOrderByCage()
        {
            return entities.OfType<Animal>().ToList().OrderBy(animal => animal.NumberCage).ToList() ;
        }
    }
}

