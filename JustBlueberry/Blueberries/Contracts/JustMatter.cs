using JustBlueberry.Common;
using JustBlueberry.Particles;
using JustBlueberry.Particles.Contracts;
using System.Collections.Generic;
namespace JustBlueberry.Blueberries.Contracts
{
    public abstract class JustMatter : IMatter
    {
        private IEnumerable<IHadron> particles;

        public JustMatter(IList<IHadron> particles)
        {
            this.particles = particles;
        }

        public IEnumerable<IHadron> Particles
        {
            get { return new List<IHadron>(this.particles); }
            private set { this.particles = value; }
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
