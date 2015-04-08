namespace JustBlueberry.Blueberries
{
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;
    using System.Collections.Generic;

    public class Hydroberry : JustMatter, IMatter
    {
        public Hydroberry(IList<IHadron> particles)
            :base(particles)
        { }


    }
}
