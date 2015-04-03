namespace JustBlueberry
{
    using System.Collections.Generic;

    using JustBlueberry.Particles;
    using JustBlueberry.Engine;
    using JustBlueberry.Renderer;
    using JustBlueberry.Operator;
    using JustBlueberry.Factory;
    using JustBlueberry.Common;
    using JustBlueberry.Blueberries.Contracts;

    public class BlueberryMain
    {
        // Define constant dimensions for the game world.
        const int DEFAULT_WORLD_ROWS = 30;
        const int DEFAULT_WORLD_COLS = 99;

        public static void Main()
        {
            var renderer = new ConsoleRenderer(DEFAULT_WORLD_ROWS, DEFAULT_WORLD_COLS);

            var hadronOperator = new ParticleOperator();

            var physicalWorldObjects = new List<IMatter>()
            {
                BlueberryFactory.CreateDarkBlueberry(new Vector()),
                BlueberryFactory.CreateNervousBlueberry(new Vector(10, 30))
            };


            var engine = new BlueberryEngine(renderer, hadronOperator, physicalWorldObjects, 100);

            engine.Run();
        }
    }
}
