namespace JustBlueberry.Particles
{
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Baryon : Hadron, IHadron, IRenderable, IColor
    {
        protected Baryon(Point position)
            :base(position)
        {}

        public abstract char GetShape();

        System.ConsoleColor IColor.ProjectColor()
        {
            return System.ConsoleColor.DarkYellow;
        }
    }
}
