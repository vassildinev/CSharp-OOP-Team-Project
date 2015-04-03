namespace JustBlueberry.Particles
{
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    using System;
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

        public ConsoleColor ProjectColor()
        {
           return System.ConsoleColor.DarkGray;
        }
    }
}
