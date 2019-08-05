using System;

namespace NotTheHero.Exceptions
{
    class NameException : Exception
    {
        public NameException() { }

        public NameException(string message) : base(message)
        {

        }

        public static void CheckName(string value)
        {
            if (value.Length > 40) throw new NameException("name cannot be more than 40 characters long");
        }
    }
}
