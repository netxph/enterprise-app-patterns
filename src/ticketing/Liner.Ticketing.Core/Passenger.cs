using System;

namespace Liner.Ticketing.Core
{
    public class Passenger
    {

        public Passenger(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;

            if (age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(age));
            }

            Age = age;
        }

        public int Age { get; }
        public string Name { get; }
    }
}
