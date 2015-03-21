namespace JustBlueberry
{
    using System.Collections.Generic;
    public class Operator : IOperator
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
