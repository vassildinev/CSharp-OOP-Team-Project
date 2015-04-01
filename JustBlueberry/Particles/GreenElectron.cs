namespace JustBlueberry.Particles
{
    using System;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Commons;

    public class GreenElectron : Electron, IRenderable, IMovable, ISound
    {
        const int GREEN_ELECTRON_SIZE_OF_MOVEMENT_PATTERN = 8;
        const char GREEN_ELECTRON_SHAPE = '~';

        private uint lifetime; // measured in frames
        private bool isDead;
        private bool mustProjectSound;
        private int startR;
        private int startC;

        public GreenElectron(Point position)
            : base(position, new Vector(-1, 0))
        {
            this.lifetime = 300;
            this.isDead = false;
            this.MustProjectSound = true;

            this.startR = this.Position.Row;
            this.startC = this.Position.Col;
        }

        public uint Life
        {
            get { return lifetime; }
            private set { this.lifetime = value; }
        }

        public bool IsDead 
        {
            get { return this.isDead; }
            set { this.isDead = value; }
        }

        public bool MustProjectSound 
        {
            get { return this.mustProjectSound; }
            set { this.mustProjectSound = value; }
        }

        public override char GetShape()
        {
            if (this.IsDead)
            {
                if (this.MustProjectSound)
                {
                    this.ProjectSound();
                    this.MustProjectSound = false;
                }
                return ' ';
            }
            return GREEN_ELECTRON_SHAPE;
        }

        public override void Move()
        {
            this.Position -= this.Speed;
            --this.Life;
            if (this.Life==0)
            {
                this.IsDead = true;
            }
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                    && this.Position.Row - this.startR > GREEN_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed.DeltaR = 0;
                this.Speed.DeltaC = 1;
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col - this.startC > GREEN_ELECTRON_SIZE_OF_MOVEMENT_PATTERN + 2)
            {
                this.Speed.DeltaR = -1;
                this.Speed.DeltaC = 0;
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row - this.startR < -GREEN_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed.DeltaR = 0;
                this.Speed.DeltaC = -1;
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col - this.startC < -GREEN_ELECTRON_SIZE_OF_MOVEMENT_PATTERN - 2)
            {
                this.Speed.DeltaR = 1;
                this.Speed.DeltaC = 0;
            }
        }

        public void ProjectSound()
        {
            Console.Beep(800, 100);
        }
    }
}
