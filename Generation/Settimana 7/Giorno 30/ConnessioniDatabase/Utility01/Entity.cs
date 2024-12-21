using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility01
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public Entity(int id) 
        {  
           Id = id; 
        }

        public Entity() { }

        public override string ToString()
        {
            return $"\tID: {Id}\n";
        }

        

        public virtual void FromDictionary(Dictionary<string,string> riga) 
        {

            
            foreach (PropertyInfo proprieta in this.GetType().GetProperties())
            {

                if (riga.ContainsKey(proprieta.Name.ToLower()))
                {
                    object valore = riga[proprieta.Name.ToLower()];


                    switch (proprieta.PropertyType.Name.ToLower())
                    {
                        case "int32":
                            valore = int.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                        case "double":
                            valore = double.Parse(riga[proprieta.Name.ToLower()]); 
                            break;
                        case "datetime":
                            valore = DateTime.Parse(riga[proprieta].Name.ToLower());
                            break;
                        case "bool":
                        case "boolean":
                        case "bit":
                            valore = bool.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                    }
                    proprieta.SetValue(this, valore);
                } 
            }
        }
    }
}
