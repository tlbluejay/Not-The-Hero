using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Enemy : Entity
    {
        public Enemy(int maxHealth, string name, int speed, int accuracy, int defense, int rank, int gold, int power) : base(maxHealth, name, speed, accuracy, defense, rank)
        {
            this.gold = gold;
            this.power = power;
        }

        public const int MIN_POWER = 10, MAX_POWER = 30, ACTION_MODIFIER_DIVIDER = 35;

        private int power;
        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                PowerException.CheckPower(value);
                power = value;
            }
        }

        private int gold;
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                GoldException.CheckGold(gold - value);
                gold = value;
            }
        }

        protected bool isBoss = false;
        public bool IsBoss
        {
            get
            {
                return isBoss;
            }
        }

        public override double ActionModifier()
        {
            return 1 + (power / ACTION_MODIFIER_DIVIDER);
        }
    }
}
