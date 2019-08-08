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
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies.Add(new Enemy(10, "Enemy " + i, 6, 7, 7, 1, 5));
            }
        }
    }
}
