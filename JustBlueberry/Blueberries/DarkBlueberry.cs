namespace JustBlueberry.Blueberries
{
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Blueberries.Contracts;
    public class DarkBlueberry : DarkMatter
    {
        public DarkBlueberry(IList<IHadron> particles)
            : base(particles)
        {
        }
    }
}
