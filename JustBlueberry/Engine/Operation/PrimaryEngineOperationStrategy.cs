namespace JustBlueberry.Engine.Operation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator.Contracts;


    public class PrimaryEngineOperationStrategy : IOperationStrategy
    {
        private const int InstancesCountLimit = 0;

        private Stack<IMatter> localCopyOfInstancesFromFactory;
        private IList<IMatter> instancesToEngine;

        private IOperator particleOperator;

        public PrimaryEngineOperationStrategy(IOperator particleOperator)
        {
            this.particleOperator = particleOperator;
            this.ReceiveInstancesFromFactory();

        }

        private void ReceiveInstancesFromFactory()
        {
            this.localCopyOfInstancesFromFactory = BlueberryFactory.GetStackedSortedAvailableBlueberries();
        }

        public IList<IMatter> InstancesToEngine
        {
            get { return new List<IMatter>(this.instancesToEngine); }
            private set { this.instancesToEngine = value; }
        }

        public IList<IMatter> SendInstancesToEngine()
        {
            if (this.localCopyOfInstancesFromFactory.Count > InstancesCountLimit)
            {
                this.InstancesToEngine = new List<IMatter>() { this.localCopyOfInstancesFromFactory.Pop() };
            }

            return this.InstancesToEngine;
        }

    }
}
