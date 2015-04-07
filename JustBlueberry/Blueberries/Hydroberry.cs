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
        public override string GetInfo()
        {
            return "This blueberry is hydro and it is so flexible!";
        }
    }
}
