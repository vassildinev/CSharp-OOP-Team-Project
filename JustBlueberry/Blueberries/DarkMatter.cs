namespace JustBlueberry.Blueberries
{
    using System.Linq;
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;

    public class DarkMatter : IMatter
    {
        protected IEnumerable<IHadron> particles;

        public DarkMatter(IEnumerable<IHadron> particles)
        {
            this.Particles = particles;
        }

        public IEnumerable<IHadron> Particles
        {
            get { return this.particles; }
            protected set { this.particles = value; }
        }
    }
}
