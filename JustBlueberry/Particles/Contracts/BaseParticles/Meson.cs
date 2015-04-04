namespace JustBlueberry.Particles.Contracts.BaseParticles
{
    using System;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Meson : Hadron, IHadron, IColor
    {
        protected Meson(Point position)
            :base(position)
        { }
    }
}
