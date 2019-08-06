using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Enemy : Entity
    {
        public Enemy(int maxHealth, string name, int speed, int accuracy, int gold) : base(maxHealth, name, speed, accuracy)
        {
            this.gold = gold;
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
    }
}
