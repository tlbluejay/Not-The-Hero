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

        public DungeonRoom()
        {
            for (int i = 0; i < Enemies.Capacity; i++)
            {
                Random rand = new Random(System.DateTime.Today.Millisecond);
                Enemies.Add(new Enemy(10, "Enemy " + i, rand.Next(10), rand.Next(10), rand.Next(10), 1, rand.Next(10), 5));
            }
        }
    }
}
