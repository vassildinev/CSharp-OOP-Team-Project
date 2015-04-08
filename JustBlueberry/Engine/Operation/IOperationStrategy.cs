namespace JustBlueberry.Engine.Operation
{
    using System;
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;
    
    public interface IOperationStrategy
    {
        IList<IMatter> SendInstancesToEngine();
    }
}
