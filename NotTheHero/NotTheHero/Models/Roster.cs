using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class Roster
    {
        public readonly int MAX_ROSTER_LENGTH = 50;
        public readonly int MAX_TEAMSIZE = 5;
        public List<Entity> Entities { get; set; }
        public List<Entity> Team { get; set; }
    }
}
