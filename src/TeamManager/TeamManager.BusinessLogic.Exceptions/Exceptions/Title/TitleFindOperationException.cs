namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleFindOperationException : Exception
    {
        public TitleFindOperationException()
        {
        }

        protected TitleFindOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleFindOperationException(string message) : base(message)
        {
        }

        public TitleFindOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}