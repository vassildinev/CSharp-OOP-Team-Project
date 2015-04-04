namespace JustBlueberry
{
    using System.Collections.Generic;

    using JustBlueberry.Particles;
    using JustBlueberry.Engine;
    using JustBlueberry.Engine.Operation;
    using JustBlueberry.Renderer;
    using JustBlueberry.Operator;
    using JustBlueberry.Factory;
    using JustBlueberry.Common;
    using JustBlueberry.Blueberries.Contracts;

    public class BlueberryMain
    {
        // Define constant dimensions for the game world.

        public static void Main()
        {
            var renderer = new AdvancedConsoleRenderer(GlobalConstants.DefaultWorldRows, GlobalConstants.DefaultWorldCols);

            renderer.RenderWelcomeScreen();

            var hadronOperator = new ParticleOperator();

            var operationStrategy = new BlueberryOperationStrategy(hadronOperator);

            var physicalWorldObjects = new List<IMatter>()
            {
                BlueberryFactory.CreateDarkBlueberry(new Vector(5, 5)),
                BlueberryFactory.CreateNervousBlueberry(new Vector(10, 40))
            };

            var engine = new BlueberryEngine(renderer, hadronOperator, operationStrategy, 50);

            engine.Run();
        }
    }
}
