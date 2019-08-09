using NotTheHero.Exceptions;
using System;
using System.Collections.Generic;

namespace NotTheHero.Models
{
    [Serializable]
    class User
    {
        public User(string name)
        {
            this.name = name;
            crypt = new Crypt(this);
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                NameException.CheckName(value);
                name = value;
            }
        }

        private long gold;
        public long Gold
        {
            get
            {
                return gold;
            }
            set
            {
                GoldException.CheckGold(gold + value);
                gold = value;
            }
        }

        private readonly List<Minion> party = new List<Minion>(4);
        public List<Minion> Party
        {
            get
            {
                return party;
            }
        }

        private readonly List<Minion> hired = new List<Minion>();
        public List<Minion> Hired
        {
            get
            {
                return hired;
            }
        }

        private readonly Crypt crypt;
        public Crypt Crypt
        {
            get
            {
                return crypt;
            }
        }
    }
}
