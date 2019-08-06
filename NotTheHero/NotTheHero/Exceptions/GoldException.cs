using System;

namespace NotTheHero.Exceptions
{
    class GoldException : Exception
    {
        public GoldException() { }

        public GoldException(string message) : base(message)
        {
        }

        public static void CheckGold(long goldAfterChange)
        {
            if (goldAfterChange < 0) throw new GoldException($"gold is {goldAfterChange}, gold cannot be less than 0");
        }
    }
}