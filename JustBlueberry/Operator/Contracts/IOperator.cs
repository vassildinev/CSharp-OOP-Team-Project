namespace JustBlueberry.Operator.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;

    public interface IOperator
    {
        void OperateOn(IHadron particle);

        void OperateOn(IMatter matter);

        void EndFrame();

        int GetElapsedFrames();
    }
}
