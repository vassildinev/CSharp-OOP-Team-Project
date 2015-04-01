namespace JustBlueberry.Operator.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Particles.Contracts;

    public interface IOperator
    {
        void OperateOn(IHadron particle);
        void EndFrame(); // indicate end of frame - currently no code
    }
}
