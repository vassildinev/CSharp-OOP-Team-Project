namespace JustBlueberry.Renderer.Contracts
{
    // Interface for rendering objects on an output source.

    using JustBlueberry.Particles.Contracts;

    public interface IRenderer
    {
        void Push(IRenderable objectToRender);
        void Print();
        void Release();
    }
}
