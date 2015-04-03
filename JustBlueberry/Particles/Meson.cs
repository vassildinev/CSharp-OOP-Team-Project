namespace JustBlueberry.Particles
{
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Meson : Hadron, IHadron, IColor
    {
        protected Meson(Point position)
            :base(position)
        { }

        public System.ConsoleColor ProjectColor()
        {
            return System.ConsoleColor.Cyan;
        }
    }
}
