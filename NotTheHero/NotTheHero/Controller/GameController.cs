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
        public void takeAction()
        {
            //view things to select an action
            ActionType selection = ActionType.Attack;
            switch(selection)
            {
                case ActionType.Attack:
                    AttackAction(new Entity(0, "cat", 0, 0, 0),new Entity(0, "dog", 0, 0, 0));
                    break;
                case ActionType.Heal:
                    HealAction(new Entity(0, "cat", 0, 0, 0), new Entity(0, "dog", 0, 0, 0));
                    break;
                default:
                    break;
            }
        }

        public void AttackAction(Entity usedBy, Entity usedAgainst)
        {
            int damage = rand.Next(MIN_BASE_DMG, MAX_BASE_DMG) /* * usedBy.ActionModifier()*/;
            int accuracy = usedBy.Accuracy / 100;
            bool landed = rand.Next(0, 100) > usedBy.Accuracy;
            usedAgainst.Health = usedAgainst.Health - damage;
        }

        public void HealAction(Entity usedBy, Entity usedAgainst)
        {
            int heal = rand.Next(MIN_BASE_HEAL, MAX_BASE_HEAL) /* *usedBy.ActionModifier()*/;
            usedAgainst.Health = usedAgainst.Health + heal;

        }
    }
}
