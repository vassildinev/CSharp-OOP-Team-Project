namespace JustBlueberry.Renderer
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using JustBlueberry.ApplicationExceptions;
    using JustBlueberry.Common;
    using JustBlueberry.Renderer.Contracts;
    using JustBlueberry.Particles.Contracts;
    using System.Threading;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common.Helpers;

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

            this.SetConsole();
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

        protected void SetConsole()
        {

            Console.WindowHeight = GlobalConstants.DefaultConsoleWindowHeight;
            Console.WindowWidth = GlobalConstants.DefaultConsoleWindowWidth;
            Console.BufferHeight = GlobalConstants.DefaultConsoleBufferHeight;
            Console.BufferWidth = GlobalConstants.DefaultConsoleBufferWidth;
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "JustBlueberry";
        }

        public virtual void RenderStartScreen()
        {
            string[] startScreenTextSplit = GlobalConstants.StartScreenText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int charArrayCols = GlobalConstants.StartScreenText.IndexOf('\n');
            int charArrayRows = startScreenTextSplit.Length;

            char[,] startScreenTextAsCharArray = new char[charArrayRows, charArrayCols];

            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < charArrayRows; row++)
            {
                for (int col = 0; col < charArrayCols; col++)
                {
                    var currentChar = startScreenTextSplit[row][col];
                    switch (currentChar)
                    {
                        case '░':
                        case '*':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '#':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '█':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case '@':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                    Console.Write(currentChar);
                }

                Console.WriteLine();
            }
            Console.CursorVisible = false;
            Thread.Sleep(GlobalConstants.StartScreenShowDuration);
            Console.Clear();
        }

        public virtual void RenderBlueberryInformation(IMatter blueberry)
        {
            Point postionForInfo = GlobalConstants.NervousBlueberryProtonStartPosition +GlobalConstants.DefaultBlueberryPosistionOnScreen + new Vector(12, -5);
            Console.SetCursorPosition(postionForInfo.Col, postionForInfo.Row);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(blueberry.GetType().Name);
            Console.WriteLine(TextJustifier.Justify(blueberry.GetInfo()));
        }
    }
}
