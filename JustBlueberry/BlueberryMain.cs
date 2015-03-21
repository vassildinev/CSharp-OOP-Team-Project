namespace JustBlueberry
{
    using System.Collections.Generic;
    public class BlueberryMain
    {
        // Define constant dimensions for the game world.
        const int DEFAULT_WORLD_ROWS = 30;
        const int DEFAULT_WORLD_COLS = 40;

        public static void Main()
        {
            var renderer = new ConsoleRenderer(DEFAULT_WORLD_ROWS, DEFAULT_WORLD_COLS);

            var hadronOperator = new Operator();

            var hadrons = new List<IHadron>()
            {
              new Proton(new Point(16, 15)),
              new Proton(new Point(16, 14)),
              new RedElectron(new Point(17, 18), new Vector(-1, -1)),
              new GreenElectron(new Point(16, 15), new Vector(-1, 0)),
              new BlueElectron(new Point(16, 15), new Vector(1, 0))

            };

            var engine = new Engine(renderer, hadronOperator, hadrons, 40);

            engine.Run();
        }
    }
}
