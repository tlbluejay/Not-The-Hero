using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTheHero.Models;
using NotTheHero.View;

namespace NotTheHero.Controller
{
    class GameController
    {
        public const int MIN_BASE_DMG = 5, MIN_BASE_HEAL = 2, MAX_BASE_DMG = 10, MAX_BASE_HEAL = 10;
        private Random rand = new Random(System.DateTime.Today.Millisecond);
        private User User = new User("Trent");
        private DungeonRoom room = new DungeonRoom();


        public void InitForTest()
        {
            for (int i = 0; i < 4; i++)
            {
                Minion minion = new Minion(10, "Minion " + i, 6, 7, 7);
                User.Party.Add(minion);
            }
            User.Gold = 10;

        }

        public void EnterDungeonRoom()
        {
            string[] options = { "Fight" };
            switch (ConsoleIO.PromptForMenuSelection(options, false, "Select an Action: "))
            {
                case 1:
                    FightPhase();
                    break;
                default:
                    break;
            }
        }

        private void FightPhase()
        {
            List<Entity> turnOrder = new List<Entity>(8);
            setTurnOrder(turnOrder);
            int turn = 0;
            bool fighting = true;
            while (fighting)
            {
                if (User.Party.Count == 0 || room.Enemies.Count == 0)
                {
                    fighting = false;
                }
                else
                {
                    if (turnOrder[turn] is Minion)
                    {
                        //view things to select an action
                        string[] options = { ActionType.Attack.ToString(), ActionType.Heal.ToString() };
                        string[] enemies = { };
                        string[] minions = { };
                        foreach (Enemy e in room.Enemies)
                        {
                            enemies.Append(e.Name);
                        }
                        foreach (Minion m in User.Party)
                        {
                            minions.Append(m.Name);
                        }

                        switch (ConsoleIO.PromptForMenuSelection(options, false, "Select an action: "))
                        {
                            case 1:
                                AttackAction(turnOrder[turn],
                                    room.Enemies[ConsoleIO.PromptForMenuSelection(enemies, false, "Select an enemy to attack: ")]);
                                break;
                            case 2:
                                HealAction(turnOrder[turn],
                                    User.Party[ConsoleIO.PromptForMenuSelection(minions, false, "Select a member of the party to heal: ")]);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        AttackAction(turnOrder[turn], User.Party[rand.Next(User.Party.Count)]);
                    }
                }
                turn++;
            }
        }

        private void setTurnOrder(List<Entity> turnOrder)
        {
            foreach (Minion m in User.Party)
            {
                turnOrder.Add(m);
            }
            foreach (Enemy e in room.Enemies)
            {
                turnOrder.Add(e);
            }
            for (int i = turnOrder.Count - 1; i >= 0; i--)
            {
                for (int numAtI = 1; numAtI <= i; numAtI++)
                {
                    if (turnOrder[numAtI - 1].Speed < turnOrder[numAtI].Speed)
                    {

                        Entity temp = turnOrder[numAtI - 1];
                        turnOrder[numAtI - 1] = turnOrder[numAtI];
                        turnOrder[numAtI] = temp;
                    }
                }
            }
        }

        private void PostAttackCheckPhase(Entity attacker, Entity toCheck)
        {
            if (toCheck.Dead)
            {
                if (toCheck is Enemy)
                {
                    Enemy e = (Enemy)toCheck;
                    User.Gold = e.Gold;
                    attacker.Experience = e.Experience;
                    room.Enemies.Remove(e);
                }
                else if (toCheck is Minion)
                {
                    Minion m = (Minion)attacker;
                    User.Party.Remove(m);
                }
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
            PostAttackCheckPhase(usedBy, usedAgainst);
        }

        public void HealAction(Entity usedBy, Entity usedAgainst)
        {
            int heal = rand.Next(MIN_BASE_HEAL, MAX_BASE_HEAL) * usedBy.ActionModifier();
            usedAgainst.Health = usedAgainst.Health + heal;

        }
    }
}
