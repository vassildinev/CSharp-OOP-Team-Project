namespace JustBlueberry.Blueberries.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Common;
    using JustBlueberry.Particles;
    using JustBlueberry.Particles.Contracts;

    public abstract class JustMatter : Matter, IMatter
    {
        public JustMatter(IList<IHadron> particles)
            :base(particles)
        { }
    }
}
