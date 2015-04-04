namespace JustBlueberry.Particles.Contracts.BaseParticles
{
    using System;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Baryon : Hadron, IHadron, IRenderable, IColor
    {
        protected Baryon(Point position)
            :base(position)
        {}

        public abstract char GetShape();
    }
}
