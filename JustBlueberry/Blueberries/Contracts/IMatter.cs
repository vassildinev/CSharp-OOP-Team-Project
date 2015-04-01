namespace JustBlueberry.Blueberries.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;

    public interface IMatter
    {
        IEnumerable<IHadron> Particles { get; } // A foreachable collection of particles
    }
}
