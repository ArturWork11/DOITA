using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioConnessione01
{
    internal class Entity
    {
        public int Id { get; set; }


        public Entity(int id)
        {
            Id = id;
        }
        public Entity() { }

        public override string ToString()
        {
            return $"ID: {Id}";
        }

        public virtual void FromDictionary(Dictionary<string, string> row)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                {
                    if (row.ContainsKey(property.Name.ToLower()))
                    {
                        object value = row[property.Name.ToLower()];
                        switch (property.Name.ToLower())
                        {
                            case "Int32":
                                value = int.Parse(row[property.Name.ToLower()]);
                                break;
                            case "double":
                                value = double.Parse(row[property.Name.ToLower()]);
                                break;
                            case "datetime":
                                value = DateTime.Parse(row[property.Name.ToLower()]);
                                break;
                            case "bool":
                            case "boolean":
                            case "bit":
                                value = bool.Parse(row[property.Name.ToLower()]);
                                break;
                        }
                        property.SetValue(this, value);
                    }
                }
            }
        }
    }
}
