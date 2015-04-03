﻿namespace JustBlueberry.Particles
{
    using System;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Common;

    public class BlackElectron : Electron, IRenderable, IMovable, IColor
    {
        const char BLACK_PARTICLE_SHAPE = '$';

        private int startR;
        private int startC;

        public BlackElectron(Point position)
            : base(position, new Vector(1, 0))
        {
            this.StartR = position.Row;
            this.StartC = position.Col;
        }

        public int StartR
        {
            get { return this.startR; }
            private set { this.startR = value; }
        }

        public int StartC
        {
            get { return this.startC; }
            private set { this.startC = value; }
        }

        public override char GetShape()
        {
            return BLACK_PARTICLE_SHAPE;
        }

        public override void Move()
        {
            base.Move();
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row > this.StartR + 4 && this.Position.Col == this.StartC)
            {
                this.Speed = new Vector(-1, 4);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC != 0
                && this.Position.Row == this.StartR && this.Position.Col != this.StartC)
            {
                this.Speed = new Vector(1, 0);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row > this.StartR + 4 && this.Position.Col != this.StartC)
            {
                this.Speed = new Vector(-1, -4);
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC != 0
                && this.Position.Row == this.StartR && this.Position.Col == this.StartC)
            {
                this.Speed = new Vector(1, 0);
            }
        }

        ConsoleColor IColor.ProjectColor()
        {
            return System.ConsoleColor.Black;
        }
    }
}
