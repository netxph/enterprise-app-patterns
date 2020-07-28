using System;
using System.Collections.Generic;

namespace Liner.Inventory.Core
{
    public class Route
    {
        public string Origin { get; }
        public string Destination { get; }

        public Route(string origin, string destination)
        {
            if (string.IsNullOrEmpty(nameof(origin)))
            {
                throw new ArgumentNullException(nameof(origin));
            }

            Origin = origin;

            if (string.IsNullOrEmpty(nameof(destination)))
            {
                throw new ArgumentNullException(nameof(destination));
            }

            Destination = destination;

        }

        public override bool Equals(object obj)
        {
            return obj is Route route &&
                   Origin == route.Origin &&
                   Destination == route.Destination;
        }

        public override int GetHashCode()
        {
            int hashCode = 1937123878;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Origin);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Destination);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Origin}-{Destination}";
        }
    }
}
