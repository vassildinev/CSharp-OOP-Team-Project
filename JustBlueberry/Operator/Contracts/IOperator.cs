namespace JustBlueberry.Operator.Contracts
{
    using System;
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;

    public interface IOperator
    {
        event EventHandler OperationCyclesTresholdReached;

        void OperateOn(IHadron particle);

        void OperateOn(IMatter matter);

        void EndOperationCycle();

        int GetElapsedCycles();
    }
}
