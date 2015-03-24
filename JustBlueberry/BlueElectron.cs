namespace JustBlueberry
{
    public class BlueElectron : Electron, IRenderable, IMovable
    {
        const int BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN = 4;

        private int startX;
        private int startY;

        public BlueElectron(Point position, Vector speed)
            : base(position, speed)
        {
            this.StartX = this.Position.Row;
            this.StartY = this.Position.Col;
        }

        public int StartX
        {
            get { return this.startX; }
            private set
            {
                if(value < 0)
                {
                    throw new InvalidBlueberryException("Can't set start Point to less than 0");
                }
                this.startX = value;
            }
        }

        public int StartY
        {
            get { return this.startY; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidBlueberryException("Can't set start Point to less than 0");
                }
                this.startY = value;
            }
        }

        public override void Move()
        {
            base.Move();
            this.ApplyMovementPattern();
        }

        public override void ApplyMovementPattern()
        {
            if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                    && this.Position.Row - this.startX > BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed.DeltaR = 0;
                this.Speed.DeltaC = 1;
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col - this.startY > BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN + 2)
            {
                this.Speed.DeltaR = -1;
                this.Speed.DeltaC = 0;
            }
            else if (this.Speed.DeltaR != 0 && this.Speed.DeltaC == 0
                && this.Position.Row - this.startX < -BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN)
            {
                this.Speed.DeltaR = 0;
                this.Speed.DeltaC = -1;
            }
            else if (this.Speed.DeltaR == 0 && this.Speed.DeltaC != 0
                && this.Position.Col - this.startY < -BLUE_ELECTRON_SIZE_OF_MOVEMENT_PATTERN - 2)
            {
                this.Speed.DeltaR = 1;
                this.Speed.DeltaC = 0;
            }
        }
    }
}
