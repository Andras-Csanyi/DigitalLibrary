namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.PeopleEventLog
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogDeleteOperationException : Exception
    {
        public PeopleEventLogDeleteOperationException()
        {
        }

        protected PeopleEventLogDeleteOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PeopleEventLogDeleteOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogDeleteOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}