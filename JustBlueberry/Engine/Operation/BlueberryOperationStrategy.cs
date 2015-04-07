namespace JustBlueberry.Engine.Operation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator.Contracts;


    public class BlueberryOperationStrategy : IOperationStrategy
    {
        private Stack<IMatter> localCopyOfInstancesFromFactory;
        private IList<IMatter> instancesToEngine;

        private IOperator particleOperator;

        public BlueberryOperationStrategy(IOperator particleOperator)
        {
            this.particleOperator = particleOperator;
            this.localCopyOfInstancesFromFactory = BlueberryFactory.ListAvailableBlueberries();
        }

        public IList<IMatter> InstancesToEngine
        {
            get { return new List<IMatter>(this.instancesToEngine); }
            private set { this.instancesToEngine = value; }
        }

        public IList<IMatter> SendInstancesToEngine()
        {
                if (this.localCopyOfInstancesFromFactory.Count != 0)
                {
                    this.InstancesToEngine = new List<IMatter>() { this.localCopyOfInstancesFromFactory.Pop() };
                }

            return this.InstancesToEngine;
        }
    }
}
