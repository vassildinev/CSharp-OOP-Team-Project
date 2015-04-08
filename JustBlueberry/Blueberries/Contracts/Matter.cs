﻿namespace JustBlueberry.Blueberries.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Common;
    using JustBlueberry.Particles;
    using JustBlueberry.Particles.Contracts;

    public abstract class Matter : IMatter
    {
        private IEnumerable<IHadron> particles;
        private Point startBlueberryPosition;

        public Matter(IList<IHadron> particles)
        {
            this.particles = particles;
            this.startBlueberryPosition = this.GetStartPosition();
        }

        public IEnumerable<IHadron> Particles
        {
            get { return new List<IHadron>(this.particles); }
            private set { this.particles = value; }
        }

        public virtual Point GetPosition()
        {
            return this.startBlueberryPosition;
        }

        protected virtual Point GetStartPosition()
        {
            foreach (var item in this.particles)
            {
                if (item is Proton)
                {
                    return item.Position;
                }
            }
            return new Point();
        }


        public virtual string GetInfo()
        {
            return "Battle formations in case of attack by another Alien species.";
            /*return "Blueberries are essential for our health. One must never underestimate the power of the blueberries. After all, they give us an absolutely delicious ice-cream. Meow.";*/
        }
    }
}