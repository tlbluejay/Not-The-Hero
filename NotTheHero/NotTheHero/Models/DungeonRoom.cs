using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class DungeonRoom
    {
        public bool BossRoom { get; set; }
        public List<Enemy> Enemies = new List<Enemy>(4);
        Random rand = new Random(System.DateTime.Today.Millisecond);
        private List<string> names = System.IO.File.ReadAllLines("Not-The-Hero\\NotTheHero\\NotTheHero\\HeroNames.txt").ToList<string>();
        private List<string> titles = System.IO.File.ReadAllLines("Not-The-Hero\\NotTheHero\\NotTheHero\\MaxRankTitles.txt").ToList<string>();

        public DungeonRoom()
        {
            if (BossRoom)
            {
                Enemies.Add(new Boss(new Enemy(100, names[rand.Next(names.Count)] + titles[rand.Next(titles.Count)], rand.Next(20, 30), rand.Next(25, 30), rand.Next(15, 25), rand.Next(1, 5), rand.Next(20, 25), 15)));
            }
            else
            {
                for (int i = 0; i < Enemies.Capacity; i++)
                {
                    Enemies.Add(new Enemy(10, names[rand.Next(names.Count)], rand.Next(10), rand.Next(10), rand.Next(10), 1, rand.Next(10), 5));
                }
            }
        }
    }
}
