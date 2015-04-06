namespace JustBlueberry.Operator
{
    using System;
    using System.Collections.Generic;
    
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Operator.Contracts;
    using JustBlueberry.Particles.Contracts;


    public delegate void MyEventHandler(object source, EventArgs e);

    public class ParticleOperator : IOperator
    {

        public event EventHandler OperationCyclesTresholdReached;

        public virtual void OnOperationCyclesTresholdReached(EventArgs e)
        {
            if (OperationCyclesTresholdReached != null)
            {
                OperationCyclesTresholdReached(this, e);
            }
        }

        private int framesElapsed;

        public ParticleOperator()
        {
            this.framesElapsed = 0;
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

        public void EndOperationCycle()
        {
            this.framesElapsed = (++this.framesElapsed) % GlobalConstants.FramesCycleDuration;
            if (this.framesElapsed == GlobalConstants.FramesCycleDuration - 1)
            {
                OnOperationCyclesTresholdReached(new EventArgs());
            }
        }
    }
}
