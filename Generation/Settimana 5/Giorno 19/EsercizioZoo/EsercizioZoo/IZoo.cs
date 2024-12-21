using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioZoo
{
    internal interface IZoo
    {
        public void ImportData(string[]path);
        public List<Animal> AnimalList();
        public List<Staff> StaffList();
        public List<Animal> AnimalOrderByType(string type);
        public List<Animal> AnimalOrderByCage();
    }
}
