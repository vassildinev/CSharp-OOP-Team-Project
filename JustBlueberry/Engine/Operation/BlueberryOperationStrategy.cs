namespace JustBlueberry.Engine.Operation
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator.Contracts;
using System;

    public class BlueberryOperationStrategy : IOperationStrategy
    {
        private const int FrameInterval = 60; // Frame interval for switching between different instances of IMatter.

        private Stack<IMatter> localCopyOfInstancesFromFactory;
        private IList<IMatter> instancesToEngine;

        private IOperator particleOperator;

        public BlueberryOperationStrategy(IOperator particleOperator)
        {
            this.particleOperator = particleOperator;
            this.localCopyOfInstancesFromFactory = BlueberryFactory.ListAvailableBlueberries();
            this.InstancesToEngine = new List<IMatter>() { this.localCopyOfInstancesFromFactory.Pop() };
        }

        public IList<IMatter> InstancesToEngine
        {
            get { return new List<IMatter>(this.instancesToEngine); }
            private set { this.instancesToEngine = value; }
        }

        public IList<IMatter> SendInstancesToEngine()
        {
            //if (this.particleOperator.GetElapsedFrames() == FrameInterval)
            //{
                if (this.localCopyOfInstancesFromFactory.Count != 0)
                {
                    this.InstancesToEngine = new List<IMatter>() { this.localCopyOfInstancesFromFactory.Pop() };
                }
           //}

            return this.InstancesToEngine;
        }
    }
}
