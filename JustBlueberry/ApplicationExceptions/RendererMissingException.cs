namespace JustBlueberry.ApplicationExceptions
{
    using System;

    public class RendererMissingException : ApplicationException
    {
        public RendererMissingException(string message)
            : base(message)
        {
        }
    }
}
