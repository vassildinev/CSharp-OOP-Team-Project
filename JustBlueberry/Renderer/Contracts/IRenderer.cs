namespace JustBlueberry.Renderer.Contracts
{
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Particles.Contracts;

    /// <summary>
    /// Interface for rendering objects on an output source.
    /// </summary>
    public interface IRenderer
    {
        void RenderStartScreen();

        void Push(IRenderable objectToRender);

        void Print();

        void Release();

        void RenderBlueberryInformation(IMatter blueberry);
    }
}
