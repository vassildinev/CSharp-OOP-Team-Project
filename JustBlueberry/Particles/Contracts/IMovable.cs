namespace JustBlueberry.Particles.Contracts
{
    using JustBlueberry.Commons;

    public interface IMovable
    {
        Vector Speed { get; set; }

        void Move();
    }
}
