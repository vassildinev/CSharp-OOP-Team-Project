namespace JustBlueberry.Engine.Contracts
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries.Contracts;

    public interface IEngine
    {
        void Run();
        IList<IMatter> Substance { get; }
    }
}
