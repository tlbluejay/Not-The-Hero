using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class Entity
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
    }
}
