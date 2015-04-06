namespace JustBlueberry.Blueberries.Contracts
{
    using System.Linq;
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Particles;

    public abstract class DarkMatter : IMatter
    {
        protected IEnumerable<IHadron> particles;

        protected DarkMatter(IEnumerable<IHadron> particles)
        {
            this.Particles = particles;
        }

        public IEnumerable<IHadron> Particles
        {
            get { return this.particles; }
            protected set { this.particles = value; }
        }

        public Point GetPosition()
        {
            foreach (var item in this.particles)
            {
                if (item is Proton)
                {
                    return item.Position;
                }
            }
            return new Point();
        }
    }
}
