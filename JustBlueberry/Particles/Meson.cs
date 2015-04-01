namespace JustBlueberry.Particles
{
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Commons;

    public abstract class Meson : Hadron, IHadron
    {
        protected Meson(Point position)
            :base(position)
        { }
    }
}
