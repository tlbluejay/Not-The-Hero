using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTheHero.Models;

namespace NotTheHero.Controller
{
    class GameController
    {
        public const int MIN_BASE_DMG = 5, MIN_BASE_HEAL = 2, MAX_BASE_DMG = 10, MAX_BASE_HEAL = 10;
        private Random rand = new Random(System.DateTime.Today.Millisecond);
        private User User = new User("Trent");

        public void initForTest()
        {
            for (int i = 0; i < 4; i++)
            {
                Minion minion = new Minion(10, "Minion " + i, 6, 7, 7);
                User.Hired.Add(minion);
                User.Party.Add(minion);
            }
            User.Gold = 10;

        }
        public void takeAction()
        {
            //view things to select an action
            ActionType selection = ActionType.Attack;
            switch(selection)
            {
                case ActionType.Attack:
                    AttackAction(new Minion(6, "cat", 6, 6, 6),new Enemy(5, "dog", 5, 5, 5, 1, 10));
                    break;
                case ActionType.Heal:
                    HealAction(new Minion(6, "cat", 6, 6, 6), new Minion(6, "cat", 6, 6, 6));
                    break;
                default:
                    break;
            }
        }

        public void AttackAction(Entity usedBy, Entity usedAgainst)
        {
            int damage = rand.Next(MIN_BASE_DMG, MAX_BASE_DMG) * usedBy.ActionModifier();
            bool landed = rand.Next(0, 100) > (usedBy.Accuracy / 100);
            if (landed)
            {
                usedAgainst.Health = usedAgainst.Health - damage;
            }
        }

        public void HealAction(Entity usedBy, Entity usedAgainst)
        {
            int heal = rand.Next(MIN_BASE_HEAL, MAX_BASE_HEAL) * usedBy.ActionModifier();
            usedAgainst.Health = usedAgainst.Health + heal;

        }
    }
}
