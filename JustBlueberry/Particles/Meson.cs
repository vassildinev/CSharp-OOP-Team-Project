namespace JustBlueberry.Particles
{
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Meson : Hadron, IHadron
    {
        protected Meson(Point position)
            :base(position)
        { }
    }
}
