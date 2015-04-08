namespace JustBlueberry
{
    using System;
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Engine;
    using JustBlueberry.Engine.Operation;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator;
    using JustBlueberry.Operator.Contracts;
    using JustBlueberry.Particles;
    using JustBlueberry.Renderer;
    using JustBlueberry.Renderer.Contracts;

    public sealed class BlueberryFaçade
    {
        private static readonly BlueberryFaçade SingleInstance = new BlueberryFaçade();

        private IRenderer renderer;
        private IOperator particleOperator;
        private IOperationStrategy operationStrategy;
        private BlueberryEngine engine;

        private BlueberryFaçade()
        { }

        public static BlueberryFaçade Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        /// <summary>
        ///  Prepare the application for execution
        /// </summary>
        public void Initialize()
        {
            // Instantiate all required objects to run the application.
            this.renderer = new AdvancedConsoleRenderer(GlobalConstants.DefaultWorldRows, GlobalConstants.DefaultWorldCols);
            this.particleOperator = new ParticleOperator();
            this.operationStrategy = new PrimaryEngineOperationStrategy(particleOperator);
            this.engine = new BlueberryEngine(renderer, particleOperator, operationStrategy);

            // Engage the event handler for the change of blueberries.
            this.particleOperator.OperationCyclesTresholdReached += new EventHandler(engine.OperatorCyclesElapsed);
        }

        /// <summary>
        /// Execute the application
        /// </summary>
        public void Start()
        {
            // Render start screen frame.
            this.renderer.RenderStartScreen();

            // Run the application logic
            engine.Run();

            // Render end of application screen.
            this.renderer.RenderEndScreen();
        }
    }
}
