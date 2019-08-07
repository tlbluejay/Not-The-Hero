using System;

namespace NotTheHero.Exceptions
{
    class PowerException : Exception
    {
        public PowerException() { }

        public PowerException(string message) : base(message)
        {

        }

        public static void CheckPower(int rank)
        {
            if (rank < Models.Enemy.MIN_POWER || rank > Models.Enemy.MAX_POWER) throw new RankException($"rank is {rank}, rank must be greater than or equal to 0 and less than or equal to 5");
        }

    }
}
