namespace JustBlueberry
{
    using System;
    using System.Text;
    public class ConsoleRenderer : IRenderer
    {
        private int gameWorldRows;
        private int gameWorldCols;
        private char[,] gameWorld;

        public ConsoleRenderer(int rows, int cols)
        {
            this.GameWorldRows = rows;
            this.GameWorldCols = cols;
            this.gameWorld = new char[rows, cols];
        }

        public int GameWorldRows
        {
            get { return this.gameWorldRows;}
            set
            {
                if(value <0)
                {
                    throw new InvalidBlueberryException("Can't set Render with less than 0");
                }
                this.gameWorldRows = value;
            }
        }

        public int GameWorldCols
        {
            get { return this.gameWorldCols; }
            set
            {
                if(value <0)
                {
                    throw new InvalidBlueberryException("Can't set Render with less than 0");
                }
                this.gameWorldCols = value;
            }
        }

        public char[,] GameWorld
        {
            get { return this.gameWorld; }
        }

        public void Push(IRenderable objectToRender)
        {
            char objectToRenderShape = objectToRender.GetShape();
            Point objectToRenderPosition = objectToRender.GetPosition();
            if (objectToRenderPosition.Row < gameWorldRows && objectToRenderPosition.Col < gameWorldCols
                && objectToRenderPosition.Row >= 0 && objectToRenderPosition.Col >= 0)
            {
                this.gameWorld[objectToRenderPosition.Row, objectToRenderPosition.Col] = objectToRenderShape;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder frameBuilder = new StringBuilder();
            for (int row = 0; row < this.gameWorldRows; row++)
            {
                for (int col = 0; col < this.gameWorldCols; col++)
                {
                    frameBuilder.Append(this.gameWorld[row, col]);
                }
                frameBuilder.AppendLine();
            }

            Console.WriteLine(frameBuilder.ToString());
        }

        public void Release()
        {
            for (int row = 0; row < this.gameWorldRows; row++)
            {
                for (int col = 0; col < this.gameWorldCols; col++)
                {
                    this.gameWorld[row, col] = ' ';
                }
            }
        }
    }
}
