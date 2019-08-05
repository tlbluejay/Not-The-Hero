using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class Crypt
    {
        public readonly int MAX_CRYPT_SIZE = 10;
        public List<DungeonRoom> DungeonLayout { get; set; }
    }
}
