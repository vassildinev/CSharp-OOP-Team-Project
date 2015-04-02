namespace JustBlueberry.Particles.Contracts
{
    using JustBlueberry.Common;

    public interface IMovable
    {
        Vector Speed { get; set; }

        void Move();
    }
}
