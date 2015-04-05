namespace JustBlueberry
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Engine;
    using JustBlueberry.Engine.Operation;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator;
    using JustBlueberry.Particles;
    using JustBlueberry.Renderer;

    public static class BlueberryFaçade
    {
        public static void StartApplication()
        {
            var renderer = new AdvancedConsoleRenderer(GlobalConstants.DefaultWorldRows, GlobalConstants.DefaultWorldCols);

            renderer.RenderWelcomeScreen();

            var particleOperator = new ParticleOperator();

            var operationStrategy = new BlueberryOperationStrategy(particleOperator);

            var engine = new BlueberryEngine(renderer, particleOperator, operationStrategy, 50);

            engine.Run();
        }
    }
}
