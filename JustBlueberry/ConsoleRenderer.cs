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
            this.gameWorldRows = rows;
            this.gameWorldCols = cols;
            this.gameWorld = new char[rows, cols];
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
