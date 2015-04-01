namespace JustBlueberry.Particles
{
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Commons;

    public abstract class Baryon : Hadron, IHadron, IRenderable
    {
        protected Baryon(Point position)
            :base(position)
        {}

        public abstract char GetShape();
    }
}
