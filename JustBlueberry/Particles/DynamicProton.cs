namespace JustBlueberry.Particles
{
    using System;

    using JustBlueberry.Common;
    using JustBlueberry.Particles.Contracts;

    public class DynamicProton : Proton, IRenderable, IMovable, IDynamic, IColor
    {
        private int startC;
        private int startR;

        public DynamicProton(Point position)
            : base(position)
        {
            this.Speed = new Vector(0, 1);

            this.startC = this.Position.Col;
            this.startR = this.Position.Row;
        }

        public Vector Speed { get; set; }

        public void Move()
        {
            this.Position += this.Speed;
            this.ApplyMovementPattern();
        }

        private void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR == 0 && this.Speed.DeltaC == 1
                && this.Position.Col > this.startC)
            {
                this.Speed = new Vector(0, -1);
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC == -1
                && this.Position.Col == this.startC)
            {
                this.Speed = new Vector(0, 1);
            }
        }

        public override ConsoleColor ProjectColor()
        {
            return ConsoleColor.DarkCyan;
        }

        public void ResetSpeed()
        {
            this.Speed = new Vector();
        }

        public void ResetPosition()
        {
            this.Position = new Point(startR, startC);
        }
    }
}
