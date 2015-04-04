namespace JustBlueberry.Blueberries
{
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common.Extensions;
    public class DarkBlueberry : DarkMatter
    {
        public DarkBlueberry(IList<IHadron> particles)
            : base(particles)
        {
        }
    }
}
