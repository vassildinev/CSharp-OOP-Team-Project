namespace JustBlueberry.Blueberries
{
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles;

    public class DarkBlueberry : DarkMatter, IMatter
    {
        public DarkBlueberry(IList<IHadron> particles)
            : base(particles)
        {
        }

        public override Point GetPosition()
        {
            Point result = new Point();
            int count = 0;

            foreach (var particle in this.Particles)
            {
                if (particle is Proton)
                {
                    count++;
                    result += particle.Position;
                }
            }

            result /= count;

            return result;
        }
        public override string GetInfo()
        {
            return "The darkbluberry is a blueberry with dark berries!";
        }
    }
}
