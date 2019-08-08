using System;
using System.Collections.Generic;

namespace NotTheHero.Models
{
    [Serializable]
    class Crypt
    {
        public Crypt(User user)
        {
            this.user = user;
        }

        private readonly User user;

        public List<Minion> Hireable { get; set; }
    }
}
