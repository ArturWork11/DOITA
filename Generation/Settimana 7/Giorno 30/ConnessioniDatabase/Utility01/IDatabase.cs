using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility01
{
    public interface IDatabase
    {
        public List<Dictionary<string, string>> Read(string query);

        public Dictionary<string, string> ReadOne(string query);
        public bool Update (string query);
    }
}
