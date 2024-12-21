using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Utility01
{
     public interface IDAO
    {
        public List<Entity> Read();
        public bool Delete(int id);
        public bool Update(Entity e);
        public bool Create(Entity e );
        public Entity Find(int id);
    }
}
