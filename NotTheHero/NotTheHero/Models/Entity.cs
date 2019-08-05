using System.Collections.Generic;
using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Entity
    {
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health <= 0) dead = true;
            }
        }

        private bool dead = false;
        public bool Dead
        {
            get { return dead; }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                NameException.CheckName(value);
                name = value;
            }
        }

        public List<Item> Inventory { get; set; }
    }
}
