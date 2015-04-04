namespace JustBlueberry.Particles
{
    using System;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Hadron : IHadron, IColor
    {
        protected Hadron(Point position)
        {
            this.Position = position;
        }

        public Point Position { get; protected set; }

        public Point GetPosition()
        {
            return this.Position;
        }

        public virtual ConsoleColor ProjectColor()
        {
            return GlobalConstants.DefaultParticleRenderColor; 
        }
    }
}
