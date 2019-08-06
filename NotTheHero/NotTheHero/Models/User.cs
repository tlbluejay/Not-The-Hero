using NotTheHero.Exceptions;

namespace NotTheHero.Models
{
    class User
    {
        private long gold;
        public long Gold
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
        //needs to save the each roster of entities and the stats of each entity
        //needs to save the crypt's current state
        //will not be saved during a run through the dungeon
    }
}
