namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleDeleteOperationException : Exception
    {
        public TitleDeleteOperationException()
        {
        }

        protected TitleDeleteOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleDeleteOperationException(string message) : base(message)
        {
        }

        public TitleDeleteOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}