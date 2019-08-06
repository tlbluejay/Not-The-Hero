using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class Roster : List<Entity>
    {
        public readonly int MAX_ROSTER_LENGTH = 50;
        public readonly int MAX_TEAMSIZE = 5;
        public List<Entity> entities { get; set; }

        Roster()
        {
            entities = new List<Entity>();
        }
    }
}
