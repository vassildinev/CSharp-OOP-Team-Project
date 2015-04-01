namespace JustBlueberry.Operator
{
    using System.Collections.Generic;

    using JustBlueberry.Operator.Contracts;
    using JustBlueberry.Particles.Contracts;

    public class ParticleOperator : IOperator
    {
        public void OperateOn(IHadron particle)
        {
            if (particle as IMovable != null)
            {
                (particle as IMovable).Move();
            }
        }

        public void EndFrame()
        {
            // TODO: Implement code as end of frame.
        }
    }
}
