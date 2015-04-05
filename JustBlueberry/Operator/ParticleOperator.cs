namespace JustBlueberry.Operator
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Operator.Contracts;
    using JustBlueberry.Particles.Contracts;

    public class ParticleOperator : IOperator
    {
        private int framesElapsed;

        public ParticleOperator()
        {
            this.framesElapsed = 0;
        }

        public int GetElapsedFrames()
        {
            return this.framesElapsed;
        }

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
            this.framesElapsed = (++this.framesElapsed) % 61;
        }
    }
}
