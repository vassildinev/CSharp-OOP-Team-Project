using JustBlueberry.Blueberries.Contracts;
using System.Collections.Generic;
namespace JustBlueberry.Engine.Contracts
{
    public interface IEngine
    {
        void Run();
        IList<IMatter> Substance { get; }
    }
}
