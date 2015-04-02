namespace JustBlueberry.Particles.Contracts
{
    // Interface for objects that have to implement rendering.

    using JustBlueberry.Common;

    public interface IRenderable
    {
        Point GetPosition();

        char GetShape();
    }
}
