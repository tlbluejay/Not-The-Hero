using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Enemy : Entity
    {
        public Enemy(int maxHealth, string name, int speed, int accuracy, int defense, int rank, int gold) : base(maxHealth, name, speed, accuracy, defense, rank)
        {
            this.gold = gold;
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

        public override int ActionModifier()
        {
            return 1 + (power / ACTION_MODIFIER_DIVIDER);
        }
    }
}
