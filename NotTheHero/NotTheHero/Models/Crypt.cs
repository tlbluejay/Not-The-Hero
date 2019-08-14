using System;
using System.Collections.Generic;
using System.Linq;

namespace NotTheHero.Models
{
    [Serializable]
    class Crypt
    {
        Random rand = new Random(System.DateTime.Today.Millisecond);
        private List<string> names = System.IO.File.ReadAllLines("Not-The-Hero\\NotTheHero\\NotTheHero\\MinionNames.txt").ToList<string>();
        private List<string> titles = System.IO.File.ReadAllLines("Not-The-Hero\\NotTheHero\\NotTheHero\\MaxRankTitles.txt").ToList<string>();
        public Crypt(User user)
        {
            this.user = user;
            for (int i = 0; i < User.PARTY_CAP_SIZE; i++)
            {
                Minion minion = new Minion(100, names[rand.Next(names.Count)], rand.Next(10), rand.Next(10), rand.Next(10));
                user.Party.Add(minion);
            }
        }

        private readonly User user;

        public List<Minion> Hireable { get; set; }
    }
}
