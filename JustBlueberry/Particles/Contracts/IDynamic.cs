namespace JustBlueberry.Particles.Contracts
{
    public interface IDynamic : IHadron, IMovable
    {
        void ResetPosition();

        void ResetSpeed();
    }
}
