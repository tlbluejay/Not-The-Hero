using System;

namespace NotTheHero.Exceptions
{
    class HealthException : Exception
    {
        public HealthException() { }

        public HealthException(string message) : base(message)
        {
        }

        public static void CheckMaxHealth(int health)
        {
            if (health <= 0) throw new HealthException($"health is {health}, it cannot be less than or equal to 0");
        }
    }
}
