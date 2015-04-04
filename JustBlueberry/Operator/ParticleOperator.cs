namespace JustBlueberry.Operator
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
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

        public void OperateOn(IMatter matter)
        {
            if (matter as IRadioactive != null)
            {
                if ((matter as IRadioactive).CheckState())
                {
                    (matter as IRadioactive).ChangeState();
                }
            }
        }

        public void EndFrame()
        {
            // TODO: Implement code as end of frame.
        }
    }
}
