namespace JustBlueberry.ApplicationExceptions
{
    using System;

    public class HadronMissingException : ApplicationException
    {
        public HadronMissingException(string message) 
            : base(message)
        {
        }
    }
}
