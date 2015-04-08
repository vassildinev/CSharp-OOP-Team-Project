﻿namespace JustBlueberry.Blueberries
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
            return "This blueberry is the fuel of all the stars in the universe - infinite ice-cream for all! So hydro, so flexible!";
        }
    }
}
