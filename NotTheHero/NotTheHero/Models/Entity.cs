using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Entity
    {
        public const int MIN_RANK = 0, MAX_RANK = 5;

        public Entity(int maxHealth, string name, int speed, int accuracy)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.name = name;
            this.speed = speed;
            this.accuracy = accuracy;
        }

        public Entity(int maxHealth, string name, int speed, int accuracy, int rank)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.name = name;
            this.speed = speed;
            this.accuracy = accuracy;
            this.rank = rank;
        }

        protected int maxHealth;
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                HealthException.CheckMaxHealth(value);
                maxHealth = value;
            }
        }

        protected int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health > maxHealth) health = maxHealth;
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

        protected int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        protected int accuracy;
        public int Accuracy
        {
            get
            {
                return accuracy;
            }
            set
            {
                accuracy = value;
            }
        }

        protected int defense;
        public virtual int Defense
        {
            get
            {
                return defense;
            }
            set
            {
                defense = value;
            }
        }

        protected int experience = 0;
        public virtual int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }

        protected int rank = 0;
        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                RankException.CheckRank(value);
                rank = value;
            }
        }
    }
}
