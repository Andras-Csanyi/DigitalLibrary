namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.PeopleEventLog
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogGetAllAsyncOperationException : Exception
    {
        public PeopleEventLogGetAllAsyncOperationException()
        {
        }

        protected PeopleEventLogGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public PeopleEventLogGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogGetAllAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}