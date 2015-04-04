namespace JustBlueberry.Renderer
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using JustBlueberry.ApplicationExceptions;
    using JustBlueberry.Common;
    using JustBlueberry.Renderer.Contracts;
    using JustBlueberry.Particles.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private int gameWorldRows;
        private int gameWorldCols;
        private char[,] gameWorld;

        public ConsoleRenderer(int rows, int cols)
        {
            this.GameWorldRows = rows;
            this.GameWorldCols = cols;
            this.GameWorld = new char[this.GameWorldRows, this.GameWorldCols];
        }

        protected int GameWorldRows
        {
            get { return this.gameWorldRows; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidBlueberryException("Number of renderer rows must be a positive integer.");
                }
                this.gameWorldRows = value;
            }
        }
        
        protected int GameWorldCols
        {
            get { return this.gameWorldCols; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidBlueberryException("Number of renderer cols must be a positive integer.");
                }
                this.gameWorldCols = value;
            }
        }
        
        protected char[,] GameWorld
        {
            get { return this.gameWorld; }
            set { this.gameWorld = value; }
        }

        public virtual void Push(IRenderable objectToRender)
        {
            char objectToRenderShape = objectToRender.GetShape();
            Point objectToRenderPosition = objectToRender.GetPosition();
            if (objectToRenderPosition.Row < gameWorldRows && objectToRenderPosition.Col < gameWorldCols
                && objectToRenderPosition.Row >= 0 && objectToRenderPosition.Col >= 0)
            {
                this.gameWorld[objectToRenderPosition.Row, objectToRenderPosition.Col] = objectToRenderShape;
            }
        }

        public virtual void Print()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder frameBuilder = new StringBuilder();
            for (int row = 0; row < this.GameWorldRows; row++)
            {
                for (int col = 0; col < this.GameWorldCols; col++)
                {
                    frameBuilder.Append(this.GameWorld[row, col]);
                }
                frameBuilder.AppendLine();
            }

            Console.WriteLine(frameBuilder.ToString());
        }

        public virtual void Release()
        {
            this.GameWorld = new char[this.GameWorldRows, this.GameWorldCols];
        }
    }
}
