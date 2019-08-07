using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class Enemy : Entity
    {
        public Enemy(int maxHealth, string name, int speed, int accuracy, int rank, int gold) : base(maxHealth, name, speed, accuracy, rank)
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
