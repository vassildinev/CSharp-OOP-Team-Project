namespace JustBlueberry.Engine.Operation
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator.Contracts;

    public class BlueberryOperationStrategy
    {
        private const int TimeInterval = 60; // Time interval for switching between different instances of IMatter.

        private Stack<IMatter> instancesFromFactory;
        private IEnumerable<IMatter> instancesToEngine;

        private IOperator particleOperator;

        private BlueberryOperationStrategy(IOperator particleOperator)
        {
            this.particleOperator = particleOperator;
            this.instancesFromFactory = BlueberryFactory.ListAvailableBlueberries();
            this.InstancesToEngine = new List<IMatter>() { this.instancesFromFactory.Pop() };
        }

        public IEnumerable<IMatter> InstancesToEngine
        {
            get { return new List<IMatter>(this.instancesToEngine); }
            private set { this.instancesToEngine = value; }
        }

        public IEnumerable<IMatter> SendInstancesToEngine()
        {
            if (this.particleOperator.GetElapsedFrames() == TimeInterval)
            {
                this.InstancesToEngine = new List<IMatter>() { this.instancesFromFactory.Pop() };
            }

            return this.InstancesToEngine;
        }
    }
}
