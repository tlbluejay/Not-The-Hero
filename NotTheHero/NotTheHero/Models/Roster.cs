using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class Roster : List<Entity>
    {
        public Roster() : base()
        { }

        public Roster(int capacity) : base(capacity)
        {

        }

        private const int MAX_ROSTER_LENGTH = 50;
        public const int PARTY_SIZE = 4;

    }
}
