using System;

namespace NotTheHero.Exceptions
{
    class RankException : Exception
    {
        public RankException() { }

        public RankException(string message) : base(message)
        {

        }

        public static void CheckRank(int rank)
        {
            if (rank < Models.Entity.MIN_RANK || rank > Models.Entity.MAX_RANK) throw new RankException($"rank is {rank}, rank must be greater than or equal to {Models.Entity.MIN_RANK} and less than or equal to {Models.Entity.MAX_RANK}");
        }
    }
}
