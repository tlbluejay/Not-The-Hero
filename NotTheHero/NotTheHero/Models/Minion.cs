﻿using System;

namespace NotTheHero.Models
{
    class Minion : Entity
    {
        public Minion(int maxHealth, string name, int speed, int accuracy, int defense) : base(maxHealth, name, speed, accuracy, defense)
        {
        }

        public Minion(int maxHealth, string name, int speed, int accuracy, int defense, int rank) : base(maxHealth, name, speed, accuracy, defense)
        {
            if (rank == 1)
            {
                experience = RANK_1;
            }
            else if (rank == 2)
            {
                experience = RANK_2;
            }
            else if (rank == 3)
            {
                experience = RANK_3;
            }
            else if (rank == 4)
            {
                experience = RANK_4;
            }
            else if (rank == MAX_RANK)
            {
                experience = RANK_5;
            }
        }

        private const int /*RANK_0 = 0,*/RANK_1 = 40, RANK_2 = 80, RANK_3 = 160, RANK_4 = 320, RANK_5 = 640, ACTION_MODIFIER_DIVIDER = 6;

        private const int MIN_HEALTH_UPGRADE = 0, MaxHealthUpgrade = 6,
            MinAccuracyUpgrade = 1, MaxAccuracyUpgrade = 4,
            MinSpeedUpgrade = 0, MaxSpeedUpgrade = 3,
            MinDefenseUpgrade = 0, MaxDefenseUpgrade = 4;

        public override int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                if (experience > RANK_5) experience = RANK_5;
                if (rank < 5 && !rankedUp) rankedUp = CheckForRankUp();
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

        public override int Defense
        {
            get
            {
                return defense * DefenseMultiplier();
            }
            set
            {
                defense = value;
            }
        }

        private int weaponRank = 0;
        public int WeaponRank
        {
            get
            {
                return weaponRank;
            }
        }

        private int armorRank = 0;
        public int ArmorRank
        {
            get
            {
                return armorRank;
            }
        }

        public void UpgradeArmor()
        {
            Exceptions.RankException.CheckRank(armorRank + 1);
            armorRank++;
        }

        public void UpgradeWeapon()
        {
            Exceptions.RankException.CheckRank(weaponRank + 1);
            weaponRank++;
        }

        public override int ActionModifier()
        {
            return 1 + (weaponRank / ACTION_MODIFIER_DIVIDER);
        }

        public void RankUp()
        {
            rank++;
            rankedUp = false;
            Random random = new Random(System.DateTime.Today.Millisecond);
            maxHealth += random.Next(MIN_HEALTH_UPGRADE, MaxHealthUpgrade);
            health = maxHealth;
            accuracy += random.Next(MinAccuracyUpgrade, MaxAccuracyUpgrade);
            speed += random.Next(MinSpeedUpgrade, MaxSpeedUpgrade);
            defense += random.Next(MinDefenseUpgrade, MaxDefenseUpgrade);
        }

        private int DefenseMultiplier()
        {
            return 1 + (armorRank / ACTION_MODIFIER_DIVIDER);
        }

        private bool CheckForRankUp()
        {
            if (experience >= RANK_1 && rank < 1)
            {
                return true;
            }
            else if (experience >= RANK_2 && rank < 2)
            {
                return true;
            }
            else if (experience >= RANK_3 && rank < 3)
            {
                return true;
            }
            else if (experience >= RANK_4 && rank < 4)
            {
                return true;
            }
            else if (experience >= RANK_5 && rank < MAX_RANK)
            {
                return true;
            }
            return false;
        }
    }
}
