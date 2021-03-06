﻿using System;

namespace Liner.Inventory.Core
{
    public class Bus
    {
        public string Id { get; }
        public Route Route { get; }
        public DateTime Schedule { get; }
        public int Slots { get; private set; }

        public Bus(Route route, DateTime schedule, int slots)
        {
            Route = route ?? throw new ArgumentNullException(nameof(route));
            Schedule = schedule;

            if (slots < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(slots));
            }

            Slots = slots;

            Id = Generate();
        }

        protected virtual string Generate()
        {
            return $"{Route.Destination[0]}{Schedule.Hour:00}{Schedule.Year}{Schedule.Month:00}{Schedule.Day:00}";
        }

        public void Reserve(int paxCount)
        {
            if(Slots < paxCount)
            {
                throw new ArgumentOutOfRangeException(nameof(paxCount));
            }

            Slots -= paxCount;
        }
    }
}
