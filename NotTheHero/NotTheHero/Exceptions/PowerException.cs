using System;

namespace NotTheHero.Exceptions
{
    class PowerException : Exception
    {
        public PowerException() { }

        public PowerException(string message) : base(message)
        {

        }

        public static void CheckPower(int power)
        {
            if (power < Models.Enemy.MIN_POWER || power > Models.Enemy.MAX_POWER) throw new RankException($"rank is {power}, rank must be greater than or equal to {Models.Enemy.MIN_POWER} and less than or equal to {Models.Enemy.MAX_POWER}");
        }

    }
}
