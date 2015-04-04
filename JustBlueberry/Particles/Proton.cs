namespace JustBlueberry.Particles
{
    using System;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public class Proton : Baryon, IHadron, IRenderable, IColor
    {
        const char PROTON_SHAPE = '+';

        public Proton(Point position)
            : base(position)
        { }

        public override char GetShape()
        {
            return PROTON_SHAPE;
        }

        public override ConsoleColor ProjectColor()
        {
            return GlobalConstants.DefaultProtonRenderColor;
        }
    }
}
