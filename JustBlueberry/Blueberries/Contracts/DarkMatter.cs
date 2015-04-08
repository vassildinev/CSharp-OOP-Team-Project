namespace JustBlueberry.Blueberries.Contracts
{
    using System.Linq;
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Particles;

    public abstract class DarkMatter : Matter, IMatter
    {

        protected DarkMatter(IList<IHadron> particles)
            : base(particles, MeaningOfLife.DestroyTheUniverse)
        { }
    }
}
