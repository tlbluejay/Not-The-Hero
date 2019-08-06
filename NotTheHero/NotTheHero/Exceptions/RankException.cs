using System;

namespace NotTheHero.Exceptions
{
    class RankException : Exception
    {
        public RankException() { }

        public RankException(string message) : base(message)
        {

        }

        public static void CheckLevel(int rank)
        {
            if (rank < 0) throw new RankException($"rank is {rank}, rank must be greater than 0");
        }
    }
}
