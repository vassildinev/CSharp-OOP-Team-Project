namespace JustBlueberry.Renderer
{
    using System;
    using System.Threading;
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Renderer.Contracts;
    using JustBlueberry.Common;

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
            Console.CursorVisible = false;
            Console.SetCursorPosition(0,0);
            Console.WriteLine(GlobalConstants.WelcomeScreen);
            Thread.Sleep(3000);
        }
    }
}
