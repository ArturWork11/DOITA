using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Esercizio02
{
    internal class Farm
    {
        List<Entity> _entities;

        public List<Entity> Entities { get => _entities; set => _entities = value; }

        public Farm(string path)
        {
            Entities = new List<Entity>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] row = line.Split(';');
                switch (row.Length)
                {
                    case 7:
                        _entities.Add(new FarmWorker(row));
                        break;
                    case 6:
                        _entities.Add(new Animal(row));
                        break;
                    default:
                        break;
                }
            }
        }

        public string ListAnimal()
        {
            string list = "";
            foreach (Entity entity in Entities)
            {
                if (entity is Animal)
                {
                    list += entity.ToString();
                }
            }
            return list;

        }

        public string ListFarmWorker()
        {
            string list = "";
            foreach (Entity entity in Entities)
            {
                if (entity is FarmWorker)
                {
                    list += entity.ToString();
                }
            }
            return list;
        }


        public double FarmWorkerMonthlyCost()
        {
            double totalPrice = 0;
            foreach (Entity entity in Entities)
            {
                if (entity is FarmWorker farmWorker)
                {
                    totalPrice += farmWorker.MonthlyCost();
                }

            }
            return totalPrice;

        }

        public double CowMonthlyCost()
        {
            double totalPrice = 0;
            foreach (Entity entity in Entities)
            {
                if (entity is Animal animal && animal.Type.ToLower() == "mucca")
                {
                    totalPrice += animal.MonthlyCost();
                }

            }
            return totalPrice;
        }

        public double AnimalMonthlyCost()
        {
            double totalPrice = 0;
            foreach (Entity entity in Entities)
            {
                if (entity is Animal animal)
                {
                    totalPrice += animal.MonthlyCost();
                }
            }
            return totalPrice;
        }

        public double AnimalTypeMonthlyCost(string type)
        {
            double typePrice = 0;

            foreach (Entity entity in Entities)
            {
                if (entity is Animal && ((Animal)entity).Type.ToLower() == type.ToLower())
                {
                    typePrice += entity.MonthlyCost();
                }

            }
            return typePrice;

        }

        public double TotalMonthlyCost()
        {
            double price = 0;
            foreach (Entity entity in Entities)
            {
                price += entity.MonthlyCost();
            }
            return price;
        }

        public string FarmWorkerUserCost(double price)
        {
            string list = "";
            foreach(Entity entity in Entities)
            {
                if (entity is FarmWorker && entity.MonthlyCost() < price)
                {
                    list += $"\n{entity.Name} and is Monthly cost is {entity.MonthlyCost()}";
                }
                
            }
            return list;
        }
        
        public string ExpensiveFarmWorker()
        {
            string list = "";
            double price = 0;
            foreach (Entity entity in Entities)
            {
                if (entity is FarmWorker && entity.MonthlyCost() > price)
                {
                    price = entity.MonthlyCost();
                    list = entity.Name;
                }
            }
            return list;
        }

        public string ExpensiveType()
        {
            string list = "";
            double price = 0;
            foreach (Entity entity in Entities)
            {
                if (entity is Animal animal && entity.MonthlyCost() > price)
                {
                    price = entity.MonthlyCost();
                    list = animal.Type;
                }
            }
            return list;
        }
    }
}
