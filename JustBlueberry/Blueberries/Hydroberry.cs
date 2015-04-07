namespace JustBlueberry.Blueberries
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;

    public class Hydroberry : JustMatter, IMatter
    {
        public Hydroberry(IList<IHadron> particles)
            :base(particles)
        { }
    }
}
