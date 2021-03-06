﻿namespace JustBlueberry.Blueberries.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public interface IMatter
    {
        MeaningOfLife LifetimeGoal { get; }

        IEnumerable<IHadron> Particles { get; } // A foreachable collection of particles

        Point GetPosition();

        string GetInfo();
    }
}
