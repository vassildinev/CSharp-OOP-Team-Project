using JustBlueberry.Common;
using JustBlueberry.Particles;
using JustBlueberry.Particles.Contracts;
using System.Collections.Generic;
namespace JustBlueberry.Blueberries.Contracts
{
    public abstract class JustMatter : Matter, IMatter
    {
        public JustMatter(IList<IHadron> particles)
            :base(particles)
        { }
    }
}
