namespace JustBlueberry.Renderer
{
    using System;
    using System.Threading;
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Renderer.Contracts;
    using JustBlueberry.Common;
    using System.Text;

    public class AdvancedConsoleRenderer : ConsoleRenderer, IRenderer
    {
        private ICollection<IRenderable> renderableObjects;

        public AdvancedConsoleRenderer(int rows, int cols)
            :base(rows, cols)
        {
            this.renderableObjects = new List<IRenderable>();
        }

        public override void Push(IRenderable objectToRender)
        {
            this.renderableObjects.Add(objectToRender);

            base.Push(objectToRender);
        }

        public override void Print()
        {
            base.Print();

            foreach (var objectToRender in this.renderableObjects)
            {
                var objectToRenderShape = objectToRender.GetShape();
                var objectToRenderPosition = objectToRender.GetPosition();
                var objectToRenderColor = objectToRender.ProjectColor();

                if (objectToRenderPosition.Row < this.GameWorldRows && objectToRenderPosition.Col < this.GameWorldCols
                && objectToRenderPosition.Row >= 0 && objectToRenderPosition.Col >= 0)
                {

                    Console.SetCursorPosition(objectToRenderPosition.Col, objectToRenderPosition.Row);
                    Console.ForegroundColor = objectToRenderColor;
                    Console.Write(objectToRenderShape);
                }
            }
        }

        public new void Release()
        {
            this.renderableObjects.Clear();
            base.Release();
        }

        public void RenderWelcomeScreen()
        {
            string[] startScreenTextSplit = GlobalConstants.StartScreenText.Split(new []{'\n'}, StringSplitOptions.RemoveEmptyEntries);
            int charArrayCols = GlobalConstants.StartScreenText.IndexOf('\n');
            int charArrayRows = startScreenTextSplit.Length;

            char[,] startScreenTextAsCharArray = new char[charArrayRows, charArrayCols];

            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < charArrayRows; row++)
            {
                for (int col = 0; col < charArrayCols; col++)
                {
                    var currentChar = startScreenTextSplit[row][col];
                    switch(currentChar)
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
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}
