namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleFindOperationException : Exception
    {
        public PeopleFindOperationException()
        {
        }

        protected PeopleFindOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PeopleFindOperationException(string message) : base(message)
        {
        }

        public PeopleFindOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}