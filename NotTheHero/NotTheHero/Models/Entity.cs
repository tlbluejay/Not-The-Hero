using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Entity
    {
        public Entity(int maxHealth, string name, int speed, int accuracy)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.name = name;
            this.speed = speed;
            this.accuracy = accuracy;
        }

        protected static readonly int Rank1 = 40, Rank2 = 80, Rank3 = 160, Rank4 = 320, Rank5 = 640;

        private int maxHealth;
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

        private int speed;
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

        private int accuracy;
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
                RankException.CheckLevel(value);
                rank = value;
            }
        }
    }
}
