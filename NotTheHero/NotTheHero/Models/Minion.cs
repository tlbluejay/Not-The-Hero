namespace NotTheHero.Models
{
    class Minion : Entity
    {
        public Minion(int maxHealth, string name, int speed, int accuracy, int experience) : base(maxHealth, name, speed, accuracy)
        {
            this.experience = experience;
        }

        public override int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                if (experience > Rank5) experience = Rank5;
                if (rank < 5) rankedUp = CheckForRankUp();
            }
        }

        private bool rankedUp = false;
        public bool RankedUp
        {
            get
            {
                return rankedUp;
            }
        }

        private bool CheckForRankUp()
        {
            if (experience >= Rank1 && rank < 1)
            {
                return true;
            }
            else if (experience >= Rank2 && rank < 2)
            {
                return true;
            }
            else if (experience >= Rank3 && rank < 3)
            {
                return true;
            }
            else if (experience >= Rank4 && rank < 4)
            {
                return true;
            }
            else if (experience >= Rank5 && rank < 5)
            {
                return true;
            }
            return false;
        }
    }
}
