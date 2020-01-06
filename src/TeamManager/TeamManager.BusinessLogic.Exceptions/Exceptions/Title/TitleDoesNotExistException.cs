namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleDoesNotExistException : Exception
    {
        public TitleDoesNotExistException()
        {
        }

        protected TitleDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleDoesNotExistException(string message) : base(message)
        {
        }

        public TitleDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}