namespace JustBlueberry.Particles.Contracts.BaseParticles
{
    using System;
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public abstract class Electron : Baryon, IHadron, IRenderable, IMovable, IColor
    {
        const char ELECTRON_SHAPE = '-';

        public Vector speed;

        public Electron(Point position, Vector speed)
            : base(position)
        {
            this.Speed = speed;
        }

        public override char GetShape()
        {
            return ELECTRON_SHAPE;
        }

        public Vector Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public virtual void Move()
        {
            this.Position += this.Speed;
        }

        public abstract void ApplyMovementPattern();

        public override ConsoleColor ProjectColor()
        {
            return GlobalConstants.DefaultElectronRenderColor;
        }
    }
}
